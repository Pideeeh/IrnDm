using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { MENU, PLAYING, PAUSED, ENDED }
public class GameController : MonoBehaviour {


    public float BaseSpeedms = 1000.0f;
    public int Score;
    public TargetSpawner targetSpawner;

    private GameState gameState = GameState.MENU;
    private MenuController menuController;
    private int difficulty;

	// Use this for initialization
	void Start () {
        targetSpawner.SpawnSpeed = BaseSpeedms/1000;
        menuController = FindObjectOfType<MenuController>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Cancel"))
        {
            TogglePause();
        }
	}

    public void StartGame(int difficulty) {
        this.difficulty = difficulty;
        menuController.HideMenu();
        targetSpawner.StartSpawning(this.difficulty);
        this.gameState = GameState.PLAYING;
    }

    public void PauseGame() {
        menuController.ShowMenu();
        targetSpawner.StopSpawning();
        //Show pause screen (e.g. HUD) with possibility to go to Menu
        this.gameState = GameState.PAUSED;
    }

    public void EndGame() {
        menuController.ShowMenu();
        targetSpawner.StopSpawning();
        //Show result screen (e.g. HUD) with possibility to go to Menu
        this.gameState = GameState.ENDED;
    }

    private void TogglePause() {
        if (gameState == GameState.PLAYING)
        {
            PauseGame();
        }
        else if (gameState == GameState.PAUSED) {
            StartGame(difficulty);
        }
    }

    public void OnMenu()
    {
        this.gameState = GameState.MENU;
    }

    public void IncScore() {
        Score++;
    }

    public void DecScore()
    {
        Score--;
    }

}
