using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AttackType
{
    Melee, Ranged
};

public class AttackPlayerAI : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private string attackAnimation;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private AttackType attackType;
    

    private NavMeshAgent nav;

	// Use this for initialization
	void Start () {

        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        attackToTarget();
		
	}

    private void attackToTarget()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < distanceToAttack)
        {
            if (attackType == AttackType.Melee)
                GetComponent<Attack>().attack(attackAnimation);
            else if (attackType == AttackType.Ranged)
                GetComponent<AttackRanged>().Attack(attackAnimation);

            GetComponent<Animator>().SetBool("isPlayerNear", true);
            nav.isStopped = true;

            Vector3 targetpos = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetpos);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        else if (distance > distanceToAttack)
        {
            nav.isStopped = false;
            nav.SetDestination(target.position);
            GetComponent<Animator>().SetBool("isPlayerNear", false);
        }
    }


}
