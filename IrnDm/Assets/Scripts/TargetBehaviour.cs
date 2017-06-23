using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour//, IRayTarget
{

    public GameObject ExplosionPrefab;
    public GameObject SmokeOnGround;
    public GameObject ContainingCreature;

    private Vector3 Impact;

    private bool isHitByRay = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (ContainingCreature != null)
            {
                Impact = gameObject.transform.position;
                Impact.y = 0;
                GameObject Creature = Instantiate(ContainingCreature, Impact, Quaternion.identity);
                Destroy(Creature, 60f);
                GameObject particleSystemOnGround = Instantiate(SmokeOnGround, Impact, Quaternion.identity);
                Destroy(particleSystemOnGround, particleSystemOnGround.GetComponent<ParticleSystem>().main.duration - 0.2f);
            }
            //zombieSpawner.Spawn(gameObject, ContainingCreature, ExplosionOnGround);
        }
        if (collision.collider.tag == "Projectile")
        {
            FindObjectOfType<GameController>().ScorePoints(10);
        }
        Debug.Log(collision.collider.tag.ToString());
        FireDestroyParticleSystem();
        Destroy(gameObject);

    }

    /*public void RayHit()
    {
        if (!isHitByRay)
        {
            FireDestroyParticleSystem();
            isHitByRay = true;
            Destroy(gameObject);
        }
    }*/

    private void FireDestroyParticleSystem()
    {
        if (ExplosionPrefab != null)
        {
            GameObject particleSystem = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration - 0.2f);
        }
    }
}
