using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour {

    private AWeapon EquippedWeaponRight;
    private AWeapon EquippedWeaponLeft;
    private int WeaponCount = 0;

    public AWeapon DefaultWeaponRight;
    public AWeapon DefaultWeaponLeft;

    public AWeapon SecondaryWeapon;

    void Start () {
        EquippedWeaponRight = DefaultWeaponRight;
        EquippedWeaponRight.Equip();
        EquippedWeaponLeft = DefaultWeaponLeft;
        EquippedWeaponLeft.Equip();
    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            FireLeft();
        }
        if (Input.GetMouseButtonDown(1))
        {
            FireRight();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            SwitchLeftWeapon(SecondaryWeapon);
        }
    }

    private void FireLeft() {
        EquippedWeaponLeft.Fire();
        if (EquippedWeaponLeft.IsEmpty())
        {
            EquippedWeaponLeft.UnEquip();
            EquippedWeaponLeft = DefaultWeaponLeft;
            EquippedWeaponLeft.Equip();
        }
    }
    private void FireRight() {
        EquippedWeaponRight.Fire();
        if (EquippedWeaponRight.IsEmpty())
        {
            EquippedWeaponRight.UnEquip();
            EquippedWeaponRight = DefaultWeaponRight;
            EquippedWeaponRight.Equip();
        }
    }

    public void SwitchLeftWeapon(AWeapon weapon)
    {
        GameObject old = GameObject.FindGameObjectWithTag("Hitscan Weapon");
        Destroy(old);
        EquippedWeaponLeft = Instantiate(weapon, gameObject.transform);
        EquippedWeaponLeft.Equip();
    }
}
