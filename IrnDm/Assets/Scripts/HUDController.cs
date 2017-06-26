using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour {

    private int points = 0;
    private int health = 100;
    private AudioSource hud_audio;


	// Use this for initialization
	void Start () {
        hud_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateArmor();
        UpdateHealth();
        UpdateScore();
	}

    public void UpdateArmor()
    {
        FindObjectOfType<GameController>().ArmorRegeneration();
        GameObject.Find("Armorbar").GetComponent<UnityEngine.UI.Slider>().value = FindObjectOfType<GameController>().Armor;
    }

    public void UpdateHealth()
    {
        GameObject.Find("Healthbar").GetComponent<UnityEngine.UI.Slider>().value = FindObjectOfType<GameController>().Health;
    }

    public void UpdateScore()
    {
        GameObject.Find("ScoreBoard").GetComponent<UnityEngine.UI.Text>().text = FindObjectOfType<GameController>().Score.ToString();
    }
}
