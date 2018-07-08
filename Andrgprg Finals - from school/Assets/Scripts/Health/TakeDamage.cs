using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    [SerializeField] private string TagToAffectDamage;

    private Animator anim;
    [SerializeField]private Health health;
    private float counterTimeDamage = 0f;
    private float timeBetweenAttacks = 1.5f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        health = this.GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        counterTimeDamage += Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagToAffectDamage))
        {
            hurt(other);
        }
    }

    private void hurt(Collider weapon)
    {
        if (counterTimeDamage < timeBetweenAttacks)
            return;

        counterTimeDamage = 0f;
        anim.Play("Hurt");

        if(this.GetComponent<Health>() != null)
        {
            int damage = 0;

            if (weapon.GetComponentInParent<Attack>() != null)
                damage = weapon.GetComponentInParent<Attack>().Damage;
            else 
                damage = weapon.GetComponent<Arrow>().Damage;

            health.TakeDamage(damage);
        }
    }

}
