using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    public GameObject explosionEffects;
    private bool damaged = true;


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 5 && damaged)
        {
            FindObjectOfType<GameController>().TakeDamage(40);
            damaged = false;
        }
        if (explosionEffects != null)
        {
            GameObject particleSystem = Instantiate(explosionEffects, gameObject.transform.position, Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration);
        }
        Destroy(gameObject);
    }
}
