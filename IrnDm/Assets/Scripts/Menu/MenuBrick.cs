using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBrick : MonoBehaviour, IRayTarget {

    public float FloatingSpeed;
    public float Amplitude;
    public MenuItemType itemType;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, Amplitude * Mathf.Sin(Time.time * FloatingSpeed)));
	}

    public void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<MenuController>().MenuItemHit(this.itemType);
    }
    public void ChangeDisplayText(string text) {
        GetComponentInChildren<TextMesh>().text = text;
    }

    public void RayHit()
    {
        FindObjectOfType<MenuController>().MenuItemHit(this.itemType);
    }
}
