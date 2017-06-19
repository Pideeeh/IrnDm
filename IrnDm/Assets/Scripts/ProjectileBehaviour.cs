using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    public GameObject explosionParticle;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (explosionParticle != null)
        {
            GameObject particleSystem = Instantiate(explosionParticle, gameObject.transform.position,Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration);
        }
        Destroy(gameObject);
    }
}
