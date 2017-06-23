using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorAI : MonoBehaviour {

    public float speed;
    public GameObject BloodPrefab;


    private GameObject Finish;
    private Vector3 direction;
    private Animator anim;
    private bool ready = true;

    private bool isHitByRay = false;
    private int Health = 100;

    // Use this for initialization
    void Start () {
        Finish = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        Hit();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateDirection(Finish);

        if (ready)
            if (!IsNear()) 
                Walk();
            else
                Hit();
	}

    private bool IsNear()
    {
        return (Mathf.Abs(Finish.transform.position.x - gameObject.transform.position.x)*Mathf.Abs(Finish.transform.position.z - gameObject.transform.position.z) < 5);

    }



    // Ongoing Actions
    private void Walk()
    {
        anim.SetBool("Attack", false);
        anim.SetInteger("State", 3);
        gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * speed;
    }

    private void Hit()
    {
        Debug.Log("near");
        anim.SetInteger("State", 0);
        anim.SetBool("Attack", true);
        gameObject.GetComponent<Rigidbody>().velocity = direction * 0;
    }


    // Onetime Actions
    public void Dies()
    {
        ready = false;
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().velocity = direction * 0;
        anim.SetBool("Attack", false);
        anim.SetInteger("State", 0);
        anim.SetInteger("Idle", -1);
        Destroy(gameObject, 5f);
    }

    public void UpdateDirection(GameObject facing) {
        direction = facing.transform.position - gameObject.transform.position;
        direction.y = 0;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }




    // Collision
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            AdjustHealth(50);
        }
    }

    public void RayHit()
    {
        if (!isHitByRay)
        {
            AdjustHealth(10);
            isHitByRay = true;
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

    private void AdjustHealth(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            FindObjectOfType<GameController>().IncScore();
            FireDestroyParticleSystem();
            Dies();
        }
    }
}
