using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

    //To do: Add all the levels into the GUI box
    int buttonHeight = 30, buttonWidth = 100, index = 0, nLevels = 9;
    private bool modeSelectorOpen, levelSelectorOpen, StoryModeSelected = false, HardmodeModeSelected = false, EndlessModeSelected = false;
    string boxText;

    
    void Start () {
	
	}

    
    void OnGUI()
    {
        if (GUI.Button(new Rect((Screen.width / 2) - (buttonWidth / 2), ((Screen.height / 2) - (buttonHeight / 2)), buttonWidth, buttonHeight), "Play"))
        {
            if (modeSelectorOpen == true) { modeSelectorOpen = false; }
            else { modeSelectorOpen = true; }
        }
        if (GUI.Button(new Rect((Screen.width / 2) - (buttonWidth / 2), ((Screen.height / 2 + (buttonHeight * 1)) - (buttonHeight / 2)), buttonWidth, buttonHeight), "Settings"))
        {

        }
        if (GUI.Button(new Rect((Screen.width / 2) - (buttonWidth / 2), ((Screen.height / 2 + (buttonHeight * 2)) - (buttonHeight / 2)), buttonWidth, buttonHeight), "Exit"))
        {
        }

        if (modeSelectorOpen == true)
        {


            if (GUI.Button(new Rect((Screen.width / 2) - (buttonWidth / 2) + buttonWidth, ((Screen.height / 2 + (buttonHeight * 0)) - (buttonHeight / 2)), buttonWidth, buttonHeight), "StoryMode"))
            {
                if (levelSelectorOpen == true && StoryModeSelected == true) {
                    levelSelectorOpen = false;
                   
                }
                else {
                    levelSelectorOpen = true;
                    StoryModeSelected = true;
                    HardmodeModeSelected = false;
                    EndlessModeSelected = false;
                }
            }
            if (GUI.Button(new Rect((Screen.width / 2) - (buttonWidth / 2) + buttonWidth, ((Screen.height / 2 + (buttonHeight * 1)) - (buttonHeight / 2)), buttonWidth, buttonHeight), "Hardmode"))
                {
                if (levelSelectorOpen == true && HardmodeModeSelected == true) {
                    levelSelectorOpen = false;
                }
                else { levelSelectorOpen = true;
                    StoryModeSelected = false;
                    HardmodeModeSelected = true;
                    EndlessModeSelected = false;
                }
            }
            if (GUI.Button(new Rect((Screen.width / 2) - (buttonWidth / 2) + buttonWidth, ((Screen.height / 2 + (buttonHeight * 2)) - (buttonHeight / 2)), buttonWidth, buttonHeight), "Endless"))
                {
                if (levelSelectorOpen == true && EndlessModeSelected == true) { levelSelectorOpen = false; }
                else { levelSelectorOpen = true;
                    StoryModeSelected = false;
                    HardmodeModeSelected = false;
                    EndlessModeSelected = true;
                }
            }

            if (StoryModeSelected) { boxText = "Story mode";  }
            else if (HardmodeModeSelected) { boxText = "Hardcore mode"; }
            else if (EndlessModeSelected){boxText = "Endless mode"; Application.LoadLevel(1); }
           
            if (levelSelectorOpen == true)
            {
                GUI.Box(new Rect(((Screen.width / 2) - (buttonWidth / 2)) + buttonWidth * 2, ((Screen.height / 2 + (buttonHeight * 0)) - (buttonHeight / 2)), buttonWidth * 3, buttonHeight * 3), boxText);
                if (StoryModeSelected)
                {
                    for(int i = 0; i < nLevels / 3; i++)
                    {
                        for(int j = 0; j < nLevels / 3; j++){
                            index++;
                            index = (index % 9);
                           
                        }
                    }
                }
            }
            

        }
    }
}
