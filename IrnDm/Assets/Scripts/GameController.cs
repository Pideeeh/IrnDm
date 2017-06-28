using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { MENU, PLAYING, PAUSED, ENDED }
public class GameController : MonoBehaviour {

    public DifficultyParamSet[] difficultyParams;

    public TargetSpawner targetSpawner;

    private GameState gameState = GameState.MENU;
    private MenuController menuController;
    public DifficultyType difficulty;
    public int Score = 0;
    public float Health = 100;
    public float Armor = 100;

    // Use this for initialization
    void Start () {
        menuController = FindObjectOfType<MenuController>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Cancel"))
        {
            TogglePause();
        }
	}

    public void StartGame() {
        this.Score = 0;
        this.Armor = 100;
        this.Health = 100;
        ResumeGame();
    }

    public void PauseGame() {
        menuController.ShowMenu();
        targetSpawner.StopSpawning();
        this.gameState = GameState.PAUSED;
    }

    public void ResumeGame() {
        menuController.HideMenu();
        targetSpawner.StartSpawning(difficultyParams[(int)this.difficulty]);
        this.gameState = GameState.PLAYING;
    }

    public void EndGame() {
        menuController.ShowMenu();
        menuController.ShowScore(this.Score);
        targetSpawner.StopSpawning();
        Array.ForEach(GameObject.FindGameObjectsWithTag("Dino"), dino => Destroy(dino));
        Array.ForEach(GameObject.FindGameObjectsWithTag("Target"), target => Destroy(target));
        this.gameState = GameState.ENDED;
    }


    private void TogglePause() {
        if (gameState == GameState.PLAYING)
        {
            PauseGame();
        }
        else if (gameState == GameState.PAUSED) {
            ResumeGame();
        }
    }

    public void OnMenu()
    {
        this.gameState = GameState.MENU;
    }

    public void ScorePoints(int amount) {
        Score += amount;
    }

    public void TakeDamage(float damage)
    {
        Armor -= damage;
        if (Armor < 0)
        {
            Health += Armor;
            Armor = 0;
        }
        if (Health <= 0)
        {
            EndGame();
        }
    }

    public void ArmorRegeneration()
    {
        if (Armor < 100)
        {
            Armor += 0.02f;
        }
    }

}
