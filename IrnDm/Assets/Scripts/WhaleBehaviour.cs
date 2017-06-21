using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleBehaviour : MonoBehaviour {

    public GameObject BloodPrefab;

    private bool isHitByRay = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
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
        if (BloodPrefab != null)
        {
            GameObject particleSystem = Instantiate(BloodPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration - 0.2f);
        }
    }
}
