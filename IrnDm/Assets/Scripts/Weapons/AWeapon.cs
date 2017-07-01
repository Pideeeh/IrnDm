using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWeapon : MonoBehaviour {

    public int Ammo;
    public bool Infinite;
    public float CoolDown;

    public AProjectile Projectile;
    public AudioClip FireSound;
    public AudioClip ReloadSound;
    public AudioClip EmptySound;
    public AudioClip NotCooledDown;
    public AudioClip EquipSound;

    private bool isEquiped = true;
    private bool isReloading = false;
    protected float lastfired;

    protected AudioSource WeaponAudioSource;
    protected bool isFiring = false;

    // Use this for initialization
    void Start() {
        WeaponAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (isFiring && Time.time - lastfired > CoolDown)
        {
            lastfired = Time.time;
            FireProjectile();
        }
    }

    public void StartFire() {
        isFiring = true;
    }
    public void StopFire()
    {
        isFiring = false;
    }

    protected void FireProjectile()
    {
        PlaySound(FireSound);
        LaunchProjectile();
        Ammo--;
        PlaySound(ReloadSound);
    }

    protected virtual void LaunchProjectile() {
        Quaternion direction = transform.parent.rotation;
        AProjectile projectile = InstantiateProjectile(gameObject.transform.position);
        projectile.transform.rotation= direction;
        projectile.transform.Rotate(new Vector3(0, 1, 0), 180);
        projectile.GetComponent<Rigidbody>().velocity = GetAimVector() * projectile.Speed;
    }

    protected virtual AProjectile InstantiateProjectile(Vector3 direction) {
       return Instantiate(Projectile,direction, Quaternion.identity);
    }

    protected Vector3 GetAimVector()
    {
        return transform.parent.forward;
    }


    public void Equip() {
        PlaySound(EquipSound);
        isEquiped = true;
    }

    public bool UnEquip() {
        if (!isReloading)
        {
            return true;
        }
        return false;
    }

    public bool IsEmpty()
    {
        return !(Ammo > 0 || Infinite);
    }

    private void PlaySound(AudioClip clip) {
        if (clip != null && WeaponAudioSource != null)
        {
            WeaponAudioSource.PlayOneShot(clip);
        }
    }


}
