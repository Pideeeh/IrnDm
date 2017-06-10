using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : AWeapon {

    public float Scattering;
    public int PelletAmount;

	// Use this for initialization
	void Start () {
        WeaponAudioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void LaunchProjectile()
    {
        for (int i = 0; i < PelletAmount; i++)
        {
            CastRay();
        }
    }

    private void CastRay() {
        Vector3 RayVector = Spread(GetAimVector());
        Ray ray = new Ray(gameObject.transform.position, RayVector);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            IRayTarget target = hit.collider.gameObject.GetComponent<IRayTarget>();
            if (target != null)
            {
                target.RayHit();
            }
        }
    }

    private Vector3 Spread(Vector3 aim)
    {
        aim.Normalize();
        Quaternion v = new Quaternion(aim.x, aim.y, aim.z, Mathf.Cos(UnityEngine.Random.Range(0f, 2 * Mathf.PI)));
        Vector3 point = new Vector3(aim.x + UnityEngine.Random.Range(0f, Scattering), aim.y, aim.z);
        return v * point;
    }
}
