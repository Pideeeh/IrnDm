using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAFWeapon : AWeapon {

    private bool aimed;
    private GameObject target;
    private LineRenderer Laser;
    public GameObject Backpack;

    // Use this for initialization
    void Start()
    {
        Laser = transform.GetComponentInChildren<LineRenderer>();
        WeaponAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        Aiming();
        if (isFiring && Time.time - lastfired > CoolDown && aimed)
        {
            NoTarget();
            lastfired = Time.time;
            FireProjectile();
        }
    }

    private void Aiming()
    {
        RaycastHit rayCast = CastRay();
        if (rayCast.collider != null) {
        target = rayCast.collider.gameObject;
        }
        if (target != null)
        {
            if (target.tag == "Target")
            {
                Target();
            }
            else
            {
                NoTarget();
            }
        }
        else
        {
            NoTarget();
        }
    }

    void Target()
    {
        aimed = true;
        Laser.startColor = Color.green;
        Laser.endColor = Color.green;
    }
    void NoTarget()
    {
        aimed = false;
        Laser.startColor = Color.red;
        Laser.endColor = Color.red;
    }

    private RaycastHit CastRay()
    {
        Vector3 RayVector = GetAimVector();
        Ray ray = new Ray(gameObject.transform.position, RayVector);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit;
        }
        return new RaycastHit();
    }

    protected override void LaunchProjectile()
    {
        Quaternion direction = transform.parent.rotation;
        FAFProjectile projectile = (FAFProjectile) InstantiateProjectile(gameObject.transform.position);
        projectile.transform.rotation = direction;
        projectile.transform.Rotate(new Vector3(0, 1, 0), 180);
        projectile.Target = target;
        projectile.GetComponent<Rigidbody>().velocity = GetAimVector() * projectile.Speed;
    }

}
