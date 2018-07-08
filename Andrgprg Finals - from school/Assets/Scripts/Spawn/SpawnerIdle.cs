using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnerIdle : MonoBehaviour {

    [SerializeField] private int numberOfEnemies;
    [SerializeField] private List<GameObject> objectToSpawn;
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceEnterPlayer = 25f;

    private bool isPLayerEnteringArea = false;

    public bool IsPlayerEnteringArea
    {
        get { return isPLayerEnteringArea; }
    }

    private void Awake()
    {
        Assert.IsNotNull(objectToSpawn[0]);
    }
    // Use this for initialization
    void Start () {

		for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject obj = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Count)]) as GameObject;
            obj.transform.position = transform.position;
            obj.transform.parent = this.transform;
        }
	}

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceEnterPlayer)
            isPLayerEnteringArea = true;
        else
            isPLayerEnteringArea = false;
    }
}
