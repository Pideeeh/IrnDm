using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMoving : MonoBehaviour {

    public GameObject Finish;
    public float speed = 20;

    private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        direction = Finish.transform.position-gameObject.transform.position;
        if (Mathf.Pow(direction.x, 2f) + Mathf.Pow(direction.y, 2) > 1)
            gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * speed;
        else
            gameObject.GetComponent<Animation>().GetClip("walk");
	}
}
