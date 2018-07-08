using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRanged : MonoBehaviour {

    [SerializeField] private GameObject Arrow;
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] Transform fireLocation;
    [SerializeField] private Transform player;
    [SerializeField] private int baseMinDamage = 5, baseMaxDamage = 10;

    private float timeAttackCounter = 0f;
    private Animator anim;
    private Stats stats;

    public int Damage
    {
        get
        {
            int damage = Random.Range(baseMinDamage, baseMaxDamage);

            if (stats != null)
                damage += (int)Mathf.Ceil((stats.Level * stats.Strength) / 2);
            return damage;
        }
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timeAttackCounter += Time.deltaTime;
	}

    public void Attack(string animation)
    {
        if (timeAttackCounter > timeBetweenAttacks)
        {
            anim.Play(animation);
            timeAttackCounter = 0f;
        }
    }

    public void ReleaseArrow()
    {
        GameObject instantiatedArrow = Instantiate(Arrow, fireLocation.position, transform.rotation) as GameObject;
        instantiatedArrow.GetComponent<Rigidbody>().velocity = transform.forward * 100f;

        instantiatedArrow.GetComponentInChildren<Arrow>().Damage = this.Damage;
    }


}
