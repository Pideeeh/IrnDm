using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour , IRayTarget{

    public GameObject ExplosionPrefab;

    private bool isHitByRay = false;

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
        FireDestroyParticleSystem();
        Destroy(gameObject);

    }

    public void RayHit()
    {
        if (!isHitByRay)
        {
            FindObjectOfType<GameController>().IncScore();
            FireDestroyParticleSystem();
            isHitByRay = true;
            Destroy(gameObject);
        }
    }

    private void FireDestroyParticleSystem()
    {
        if (ExplosionPrefab != null)
        {
            GameObject particleSystem = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration - 0.2f);
        }
    }
}
