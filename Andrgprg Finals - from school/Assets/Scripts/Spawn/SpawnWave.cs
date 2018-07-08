using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour {

    [SerializeField] List<Transform> nodes;
    [SerializeField] List<GameObject> objectToSpawn;
    [SerializeField] float timeBetweenSpawn = 1f;
    [SerializeField] int numberOfSpawn = 2;
    [SerializeField] private int maxWave = 5;

    private int currentWave = 1;
    private int EnemyOnScene = 0;
    private bool waveClear = false;

	// Use this for initialization
	void Start () {

        StartCoroutine(spawn());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawn()
    {
        while(currentWave * numberOfSpawn > EnemyOnScene) 
        {
            int indexSpawnObj = Random.Range(0, objectToSpawn.Count);
            int indexSpawnPos = Random.Range(0, nodes.Count);

            GameObject obj = Instantiate(objectToSpawn[indexSpawnObj]) as GameObject;
            obj.transform.position = nodes[indexSpawnPos].position;

            EnemyOnScene++;

            yield return new WaitForSeconds(timeBetweenSpawn);
        }

        yield return new WaitUntil(() => EnemyOnScene <= 0);

        currentWave++;

        yield return new WaitForSeconds(4f);

        if (currentWave < maxWave)
            StartCoroutine(spawn());
        else
            waveClear = true;
    }

    public void unregeisterEnemy()
    {
        EnemyOnScene--;
    }
}
