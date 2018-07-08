using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamAI : MonoBehaviour {

    private GameObject [] nodes;
    private SpawnerIdle spawner;
    private Coroutine behaviorIdle;
    private AttackPlayerAI aiAttack = null;

	// Use this for initialization
	void Start () {
        spawner = GetComponentInParent<SpawnerIdle>();
        behaviorIdle = StartCoroutine(move());
        nodes = GameObject.FindGameObjectsWithTag("Node");

        if (GetComponent<AttackPlayerAI>() != null)
        {
            aiAttack = GetComponent<AttackPlayerAI>();
            aiAttack.enabled = false;
        }

        StartCoroutine(move());
	}
	
	// Update is called once per frame
	void Update () {

        if (spawner.IsPlayerEnteringArea)
        {
            StopCoroutine(behaviorIdle);

            if (aiAttack != null)
                aiAttack.enabled = true;
        }
        else
        {
            if (aiAttack != null)
                aiAttack.enabled = false;

            StartCoroutine(move());
        }
	}

    IEnumerator move()
    {
        while(!spawner.IsPlayerEnteringArea)
        {
            int index = Random.Range(0, nodes.Length - 1);
            transform.position = Vector3.MoveTowards(transform.position, nodes[index].transform.position, 3 * Time.deltaTime);

            Vector3 direction = nodes[index].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = rotation;
        }

        yield return null;
        StartCoroutine(move());
    }
}
