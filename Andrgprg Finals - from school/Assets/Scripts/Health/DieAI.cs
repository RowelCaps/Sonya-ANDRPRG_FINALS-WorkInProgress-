using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DieAI : MonoBehaviour {

    private Health health;
    private AttackPlayerAI ai;
    private TakeDamage takeDmg;
    private RoamAI roamAi;
    private Animator anim;

    private bool isDissappearing = false;
    private bool isCoroutineStarted = false;

	// Use this for initialization
	void Start () {

        health = GetComponent<Health>();
        ai = GetComponent<AttackPlayerAI>();
        roamAi = GetComponent<RoamAI>();
        takeDmg = GetComponent<TakeDamage>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (health.IsDead() && !isCoroutineStarted)
        {
            die();
            GameObject.Find("SpawnWave").GetComponent<SpawnWave>().unregeisterEnemy();
        }

        if (isDissappearing)
            transform.Translate(Vector3.down * 2f * Time.deltaTime);
	}

    private void die()
    {
        ai.enabled = false;

        if(roamAi != null)
            roamAi.enabled = false;

        takeDmg.enabled = false;

        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<NavMeshAgent>().enabled = false;

        anim.SetBool("isDead", true);
        StartCoroutine(fadeAway());
        isCoroutineStarted = true;
    }

    IEnumerator fadeAway()
    {
        yield return new WaitForSeconds(4f);
        isDissappearing = true;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
