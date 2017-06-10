using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour , IRayTarget{

    public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<GameController>().DecScore();
        }
        if (collision.collider.tag == "Projectile")
        {
            FindObjectOfType<GameController>().IncScore();
        }
        Destroy(gameObject);

    }

    public void RayHit()
    {
        FindObjectOfType<GameController>().IncScore();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (ExplosionPrefab != null)
        {
            GameObject particleSystem = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration - 0.2f);
        }
    }
}
