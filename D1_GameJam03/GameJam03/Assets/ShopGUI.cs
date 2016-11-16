using UnityEngine;
using System.Collections;
using System;

public class ShopGUI : MonoBehaviour {
    int buttonWidth = 100, buttonHeight = 30, labelWidth = 150, labelHeight = 20;
    int shopButtonWidth = 150, shopButtonHeight = 110;
    public bool noWaveActive = true;
    int curMoney = 10000, nEnemies = 10, curHealth = 5, curWave = 1, totalWaves = 9;
    public string[] towerNames;
    public int[] towerCosts;
    public GameManager gameManager;

	void Start () {
        
	}
	
        //Todo: take values from gamemanager and use them here instead of the now not changing values
	
	void OnGUI () {
        GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, Screen.height / 5), "Heads Up Display");
        GUI.Label(new Rect(50, labelHeight, labelWidth, labelHeight), "Score : " + gameManager.money);
        GUI.Label(new Rect(50, labelHeight * 2, labelWidth, labelHeight), "Wave " + (gameManager.currentTurn+1) + " / " + (totalWaves));
        GUI.Label(new Rect(50, Screen.height * 0.8f + 25 - labelHeight, labelWidth, labelHeight), "Health : " + gameManager.lives);
        GUI.Label(new Rect(50, Screen.height * 0.8f + 25, labelWidth, labelHeight), "Money : " + gameManager.money);
        GUI.Label(new Rect(50, Screen.height * 0.8f + 25 + labelHeight, labelWidth, labelHeight), "Aantal enemies : " + gameManager.Enemies.Count);

        for(int i = 0; i < towerNames.Length; i++)
        {
            if (noWaveActive)
            {
                if(GUI.Button(new Rect(Screen.width / 2 + i * (shopButtonWidth + 5) - 50, Screen.height * 0.8f + 25, shopButtonWidth, shopButtonHeight), towerNames[i]))
                {
                    gameManager.selectedElement = i;
                }
                GUI.Label(new Rect(Screen.width / 2 + i * shopButtonWidth - 25, Screen.height * 0.8f + shopButtonHeight, labelWidth, labelHeight), towerCosts[i].ToString());
            }
        }
        
    }
}