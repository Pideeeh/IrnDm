using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour {

    private AWeapon EquippedWeaponRight;
    private AWeapon EquippedWeaponLeft;
    private int WeaponCount = 0;

    public AWeapon DefaultWeapon;

    void Start () {
        EquippedWeaponRight = DefaultWeapon;
        EquippedWeaponRight.Equip();
        EquippedWeaponLeft = DefaultWeapon;
        EquippedWeaponLeft.Equip();
    }

    void Update () {
        if (Input.GetMouseButtonUp(0)) { 
            FireRight();
            Debug.Log("Pressed left click.");
        }
        if (Input.GetMouseButtonUp(1))
        {
            //Fire right
            Debug.Log("Pressed right click.");
        }
    }

    private void FireLeft() {
        EquippedWeaponLeft.Fire();
        if (EquippedWeaponLeft.IsEmpty())
        {
            EquippedWeaponLeft.UnEquip();
            EquippedWeaponLeft = DefaultWeapon;
            EquippedWeaponLeft.Equip();
        }
    }
    private void FireRight() {
        EquippedWeaponRight.Fire();
        if (EquippedWeaponRight.IsEmpty())
        {
            EquippedWeaponRight.UnEquip();
            EquippedWeaponRight = DefaultWeapon;
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
