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

    protected AudioSource WeaponAudioSource;

    // Use this for initialization
    void Start() {
        WeaponAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Fire() {
        Debug.Log("Fire");
        if (isEquiped)
        {
            Debug.Log("equip");
            if (!IsEmpty())
            {
                Debug.Log("notempty");
                if (!isReloading)
                {
                    Debug.Log("loaded");
                    StartCoroutine(FireProjectile());
                }
                else
                {
                    PlaySound(NotCooledDown);
                }
            }
            else
            {
                PlaySound(EmptySound);
            }
        }
    }

    IEnumerator FireProjectile()
    {
        PlaySound(FireSound);
        LaunchProjectile();
        Ammo--;
        PlaySound(ReloadSound);
        isReloading = true;
        yield return new WaitForSeconds(CoolDown);
        isReloading = false;
    }

    protected virtual void LaunchProjectile() {
        Quaternion direction = transform.parent.rotation;
        AProjectile projectile = InstantiateProjectile(gameObject.transform.position);
        projectile.transform.rotation= direction;
        projectile.transform.Rotate(new Vector3(0, 1, 0), 180);
        projectile.GetComponent<Rigidbody>().velocity = GetAimVector() * projectile.Speed;
    }

    protected AProjectile InstantiateProjectile(Vector3 direction) {
       return Instantiate(Projectile,direction, Quaternion.identity);
    }

    protected Vector3 GetAimVector()
    {
        return transform.parent.forward;
    }

    public void Equip() {
        PlaySound(EquipSound);
        Debug.Log("Equip");
        isEquiped = true;
    }

    public bool UnEquip() {
        Debug.Log("Unequip");
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
