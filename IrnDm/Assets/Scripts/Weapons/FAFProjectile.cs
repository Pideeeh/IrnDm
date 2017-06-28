using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAFProjectile : AProjectile {

    private Vector3 direction;
    public GameObject Target;

	// Use this for initialization
	void Start () {
        if (Target == null)
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDirection();
        gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * Speed;
	}

    void UpdateDirection()
    {
        if (Target != null) {
        direction = Target.transform.position - gameObject.transform.position;
        }
    }
}
