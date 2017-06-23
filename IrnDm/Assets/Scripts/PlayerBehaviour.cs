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

    void Start () {
        EquippedWeaponRight = DefaultWeaponRight;
        EquippedWeaponRight.Equip();
        EquippedWeaponLeft = DefaultWeaponLeft;
        EquippedWeaponLeft.Equip();
    }

    void Update () {
        if (Input.GetMouseButtonUp(0)) { 
            FireLeft();
        }
        if (Input.GetMouseButtonUp(1))
        {
            FireRight();
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

    public void PickUpWeapon(AWeapon weapon)
    {
        while (!EquippedWeaponRight.UnEquip() & EquippedWeaponLeft.UnEquip()) {
            
        }
        EquippedWeaponLeft = Instantiate(weapon);
        EquippedWeaponRight = Instantiate(weapon);
        Destroy(weapon);
        EquippedWeaponLeft.Equip();
        EquippedWeaponRight.Equip();
    }
}
