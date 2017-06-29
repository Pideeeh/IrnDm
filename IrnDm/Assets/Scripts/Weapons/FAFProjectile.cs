using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAFProjectile : AProjectile {

    private Vector3 direction;
    public GameObject Target;
    private bool hasheight = false;

	// Use this for initialization
	void Start () {
        if (Target == null)
            Destroy(gameObject);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 120, 0);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hasheight)
        {
            UpdateDirection();
            gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * Speed;
        }
        else
            if (transform.position.y > 80) { hasheight = true; }
	}

    void UpdateDirection()
    {
        if (Target != null)
        {
            direction = Target.transform.position - gameObject.transform.position;
            gameObject.transform.rotation = Quaternion.LookRotation(direction);
            gameObject.transform.Rotate(new Vector3(0, 1, 0), 180);
        }
    }
}
