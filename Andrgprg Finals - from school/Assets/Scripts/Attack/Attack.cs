using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    [SerializeField] private int baseMinDamage = 5, baseMaxDamage = 10;
    [SerializeField] private float timeBetweenAttacks = 1.5f;

    protected BoxCollider[] weaponCollider;
    protected Animator anim;
    private float counterTimeAttack = 0;

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


    void Start()
    {

        weaponCollider = GetComponentsInChildren<BoxCollider>();
        anim = GetComponent<Animator>();
        stats = GetComponent<Stats>();

    }

    private void Update()
    {
        counterTimeAttack += Time.deltaTime;
    }

    public void attack(string animation)
    {
        if (counterTimeAttack > timeBetweenAttacks)
        {
            anim.Play(animation);
            counterTimeAttack = 0;
        }
    }

    public void BeginAttack()
    {
        foreach (BoxCollider weapon in weaponCollider)
        {
            weapon.enabled = true;
        }
    }

    public void EndAttack()
    {
        foreach (BoxCollider weapon in weaponCollider)
        {
            weapon.enabled = false;
        }
    }
}
