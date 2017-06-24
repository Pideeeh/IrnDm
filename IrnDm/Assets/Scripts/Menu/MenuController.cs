using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuItemType {StartGame, Difficulty, Exit, Score}

public enum DifficultyType {
    EASY = 0, NORMAL =1 , HARD= 2, BRING_IT_ON=3
}

public class MenuController : MonoBehaviour {

    DifficultyType difficulty = 0;
    private string[] difficulties = new string[] { "Easy", "Normal",  "Hard", "Bring it on" };
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuItemHit(MenuItemType itemType) {
        switch (itemType)
        {
            case MenuItemType.StartGame:
                FindObjectOfType<GameController>().StartGame();
                break;
            case MenuItemType.Difficulty:
                difficulty = (int)difficulty < 3 ? difficulty + 1 : 0;
                FindObjectOfType<GameController>().difficulty = difficulty;
                foreach (var item in GetComponentsInChildren<MenuBrick>())
                {
                    if (item.itemType == MenuItemType.Difficulty)
                    {
                        item.ChangeDisplayText("Difficulty:\n" + difficulties[(int)difficulty]);
                    }
                }
                break;
            case MenuItemType.Exit:
                Debug.Log("EXIT"); //TODO swapped out with halt command
                break;
        }
    }

    public void HideMenu() {
        gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    public void ShowScore(int Score) {
        foreach (var item in GetComponentsInChildren<MenuBrick>())
        {
            item.gameObject.GetComponent<MeshRenderer>().enabled = true;
            if (item.itemType == MenuItemType.Score)
            {
                item.ChangeDisplayText("Last Score:\n" + Score);
            }
        }
        
    }

    
}
