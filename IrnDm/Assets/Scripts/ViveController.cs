using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour {

    private SteamVR_TrackedController controller;

    private void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += HandleTriggerClicked;
        controller.TriggerUnclicked += HandleTriggerUnclicked;
        controller.Gripped += HandleGriped;
    }

    private void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        GetComponentInChildren<AWeapon>().StopFire();
        SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse();
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        GetComponentInChildren<AWeapon>().StartFire();
        SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse();
    }

    private void HandleGriped(object sender, ClickedEventArgs e)
    {
        Debug.Log("squeeze");
        AWeapon[] Weapons = GetComponentsInChildren<AWeapon>(true);
        foreach(AWeapon current in Weapons)
        {
            current.gameObject.SetActive(!current.gameObject.activeSelf);
                
        }
    }

    private void OnDisable()
    {
        controller.TriggerClicked -= HandleTriggerClicked;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
