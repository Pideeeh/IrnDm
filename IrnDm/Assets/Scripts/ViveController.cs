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
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        GetComponentInChildren<AWeapon>().Fire();
        SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse();
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
