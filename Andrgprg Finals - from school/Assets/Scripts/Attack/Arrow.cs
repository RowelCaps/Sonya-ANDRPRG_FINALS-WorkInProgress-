using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    [SerializeField] string objectTagToBeAffected;
    [SerializeField] float distanceToBeDestroyed;

    private int damage;
    private Vector3 initialPosition;
    private Rigidbody rigidBody;

    public int Damage { get { return damage; } set { damage = value; } }

	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, initialPosition) >= distanceToBeDestroyed)
            Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(objectTagToBeAffected))
        {
            Destroy(this.gameObject);
        }
    }
}
