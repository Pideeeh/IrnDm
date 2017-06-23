using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorAI : MonoBehaviour, IRayTarget {

    public float speed;
    public GameObject BloodPrefab;

    public AudioClip raptor_attack, raptor_step, raptor_dies;
    public AudioClip alerta;


    GameObject Finish;
    Vector3 direction;
    Animator anim;
    AudioSource source;
    private bool reported = false;
    private bool alive = true;

    private int Health = 100;

    // Use this for initialization
    void Start () {
        Finish = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        source = gameObject.GetComponent<AudioSource>();
    }
	

	// Update is called once per frame
	void Update () {
        UpdateDirection(Finish);

        if (alive)
        {
            if (!reported && IsNear(2500f))
            {
                Report();
                reported = true;
            }
            if (!IsNear(15f))
                Walk();
            else
                Attack();
        }
    }

    private bool IsNear(float sqrdistance)
    {
        return (Mathf.Pow(Finish.transform.position.x - gameObject.transform.position.x,2) + Mathf.Pow(Finish.transform.position.z - gameObject.transform.position.z,2) < sqrdistance);
    }



    // Ongoing Actions
    private void Walk()
    {
        anim.SetBool("Attack", false);
        anim.SetInteger("State", 3);
        if (!source.isPlaying)
        {
            source.PlayOneShot(raptor_step);
        }
        gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * speed;
    }

    private void Attack()
    {
        anim.SetInteger("State", 0);
        anim.SetBool("Attack", true);
        gameObject.GetComponent<Rigidbody>().velocity = direction * 0;
        if (!source.isPlaying)
        {
            FindObjectOfType<GameController>().TakeDamage(5f);
            source.PlayOneShot(raptor_attack);
        }
    }


    // Onetime Actions
    public void Dies()
    {
        alive = false;
        anim.SetInteger("State", 0);
        anim.SetBool("Attack", false);
        anim.SetInteger("Idle", -1);
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().velocity = direction * 0;
        Destroy(gameObject, 5f);
        source.PlayOneShot(raptor_dies);
    }

    public void UpdateDirection(GameObject facing) {
        direction = facing.transform.position - gameObject.transform.position;
        direction.y = 0;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Report()
    {
        AudioSource HUD_audio = GameObject.Find("HUDCanvas").GetComponent<AudioSource>();
        if(!HUD_audio.isPlaying)
        HUD_audio.PlayOneShot(alerta);
    }


    // Collision
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            Hit(10);    
        }
    }

    public void RayHit()
    {
        Hit(40);
    }

    private void Hit(int dmg)
    {
        Health -= dmg;
        if (Health <= 0 && alive)
        {
            FindObjectOfType<GameController>().ScorePoints(7);
            FireDestroyParticleSystem();
            Dies();
        }
    }

    private void FireDestroyParticleSystem()
    {
        if (BloodPrefab != null)
        {
            GameObject particleSystem = Instantiate(BloodPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration + 1f);
        }
    }
}
