using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : AWeapon {

    public float Scattering;
    public int PelletAmount;

    public GameObject rayHitParticle;
    public GameObject rayPelletParticle;

	// Use this for initialization
	void Start () {
        WeaponAudioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void LaunchProjectile()
    {
        List<RaycastHit> rayCastHitList = new List<RaycastHit>();
        List<GameObject> hitObjects = new List<GameObject>();
        for (int i = 0; i < PelletAmount; i++)
        {
            rayCastHitList.Add(CastRay());
        }
        foreach (var hit in rayCastHitList)
        {
            if (hit.collider != null)
            {
                IRayTarget target = hit.collider.gameObject.GetComponent<IRayTarget>();
                if (target != null && !hitObjects.Contains(hit.collider.gameObject))
                {
                    target.RayHit();
                    hitObjects.Add(hit.collider.gameObject);
                }
                GameObject particleSystem = Instantiate(rayHitParticle, hit.point, Quaternion.identity);
                Destroy(particleSystem, particleSystem.GetComponent<ParticleSystem>().main.duration);
            }
        }
    }

    private RaycastHit CastRay() {
        Vector3 RayVector = Spread(GetAimVector());
        if (UnityEngine.Random.Range(0, 1) == 0)
        {
            GameObject projectile = Instantiate(rayPelletParticle, gameObject.transform.position, Quaternion.identity);
            projectile.transform.forward = RayVector;
            projectile.GetComponent<Rigidbody>().AddForce(RayVector.normalized,ForceMode.Impulse);
            Destroy(projectile, 2);
        }
        Ray ray = new Ray(gameObject.transform.position, RayVector);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            return hit;
        }
        return new RaycastHit();
    }

    private Vector3 Spread(Vector3 aim)
    {
        aim.Normalize();
        Vector3 point = new Vector3(aim.x + UnityEngine.Random.Range(-Scattering, Scattering), aim.y + UnityEngine.Random.Range(-Scattering, Scattering), aim.z + UnityEngine.Random.Range(-Scattering, Scattering));
        return point;
    }

}
