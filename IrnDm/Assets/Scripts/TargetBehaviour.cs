using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{

    public GameObject ExplosionPrefab;
    public GameObject SmokeOnGround;
    public AudioClip ExplosionOnImpact;
    public GameObject ContainingCreature;

    private Vector3 Impact;
    private bool IsImpact = false;

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
            if (ExplosionOnImpact != null)
            {
                IsImpact = true;
            }
            if (ContainingCreature != null)
            {
                TargetSpawner spawner = FindObjectOfType<TargetSpawner>();
                if (UnityEngine.Random.Range(0.0f,1.0f) < spawner.difficultyParams.RaptorProbability)
                {
                    Impact = gameObject.transform.position;
                    GameObject Creature = Instantiate(ContainingCreature, Impact, Quaternion.identity);
                    Destroy(Creature, 60f);
                    GameObject particleSystemOnGround = Instantiate(SmokeOnGround, Impact, Quaternion.identity);
                    Destroy(particleSystemOnGround, particleSystemOnGround.GetComponent<ParticleSystem>().main.duration - 0.2f);
                }
            }
        }
        if (collision.collider.tag == "Projectile")
        {
            FindObjectOfType<GameController>().ScorePoints(10);
        }
        if (Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 25)
        {
            FindObjectOfType<GameController>().Armor = 0;
            FindObjectOfType<GameController>().TakeDamage(60);
        }
        FireDestroyParticleSystem(IsImpact);
        Destroy(gameObject);

    }

    private void FireDestroyParticleSystem(bool onGround)
    {
        
        if (ExplosionPrefab != null)
        {
            GameObject particleSystem = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            if (onGround)
            {
                particleSystem.GetComponent<AudioSource>().PlayOneShot(ExplosionOnImpact);
            }
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration - 0.2f);
        }
    }
}
