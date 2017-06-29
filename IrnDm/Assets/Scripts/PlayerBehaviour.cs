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
        if(EquippedWeaponRight != null)
        {
        EquippedWeaponRight.Equip();
        }
        EquippedWeaponLeft = DefaultWeaponLeft;
        if (EquippedWeaponLeft != null) {
        EquippedWeaponLeft.Equip();
        }
    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            GameObject.Find("LeftHand").transform.GetComponentInChildren<AWeapon>().StartFire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Find("RightHand").transform.GetComponentInChildren<AWeapon>().StartFire();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject.Find("LeftHand").transform.GetComponentInChildren<AWeapon>().StopFire();
        }
        if (Input.GetMouseButtonUp(1))
        {
            GameObject.Find("RightHand").transform.GetComponentInChildren<AWeapon>().StopFire();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            SwitchLeftWeapon();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            SwitchRightWeapon();
        }
    }


    public void SwitchLeftWeapon()
    {
        AWeapon[] Weapons = GameObject.Find("LeftHand").transform.GetComponentsInChildren<AWeapon>(true);
        foreach (AWeapon current in Weapons)
        {
            current.gameObject.SetActive(!current.gameObject.activeSelf);

        }
    }

    public void SwitchRightWeapon()
    {
        AWeapon[] Weapons = GameObject.Find("RightHand").transform.GetComponentsInChildren<AWeapon>(true);
        foreach (AWeapon current in Weapons)
        {
            current.gameObject.SetActive(!current.gameObject.activeSelf);

        }
    }
}
