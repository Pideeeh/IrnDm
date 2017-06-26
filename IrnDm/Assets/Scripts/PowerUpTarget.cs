using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTarget : MonoBehaviour {

    public AWeapon Weapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        //FindObjectOfType<PlayerBehaviour>().PickUpWeapon(Weapon);
        Destroy(gameObject);
    }
}
