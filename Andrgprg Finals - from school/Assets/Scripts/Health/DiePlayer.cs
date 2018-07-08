using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour {

    private Health health;
    private PlayerController playerController;
    private Attack attack;
    private TakeDamage takeDmg;
    private Animator anim;

	// Use this for initialization
	void Start () {

        health = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();
        attack = GetComponent<Attack>();
        anim = GetComponent<Animator>();
        takeDmg = GetComponent<TakeDamage>();
	}
	
	// Update is called once per frame
	void Update () {

        if (health.IsDead())
            die();
	}

    private void die()
    {
        //GameManager.shared.gameOver();
        playerController.enabled = false;
        attack.enabled = false;
        takeDmg.enabled = false;

        anim.SetBool("HeroDie", true);
    }
}
