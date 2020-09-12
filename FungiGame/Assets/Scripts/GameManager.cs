using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string shopName;
    public float timePlayed;
    public bool chestUnlocked;
    public int[] mushroomAmounts; //Determines which mushroom player has for index slot
    public int[] onDisplay; //Set mushroom index number for each display slot
    public string[] mushroomNames;
    public bool[] mushroomsSold; //tracks if mushrooms have been sold before to show prices
    public bool[] tasksCompleted;
    public int shelvesMade;
    public int currentPayments;
    public int backpackUpgradeNumber; //what upgrade number it's currently at
    public int binocularUpgradeNumber = 1;//what upgrade number it's currently at ToDo: reset to zero when done testing
    //public bool[] areasUnlocked; //If we get to it\

    #region "Save/Load"
    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadGame();
        
        shopName = data.shopName;
        timePlayed = data.timePlayed;
        chestUnlocked = data.chestUnlocked;
        mushroomAmounts = new int[10]; //One for each kind, adjust as needed
        for(int i = 0; i < mushroomAmounts.Length; i++)
        {
            mushroomAmounts[i] = data.mushroomAmounts[i];
        }
        onDisplay = new int[10]; //One for each display slot
        for(int i = 0; i < onDisplay.Length; i++)
        {
            onDisplay[i] = data.onDisplay[i];
        }
        mushroomNames = new string[10]; //One for each display slot
        for(int i = 0; i < mushroomNames.Length; i++)
        {
            mushroomNames[i] = data.mushroomNames[i];
        }
        mushroomsSold = new bool[10]; //One for each kind, adjust as needed
        for(int i = 0; i < mushroomsSold.Length; i++)
        {
            mushroomsSold[i] = data.mushroomsSold[i];
        }
        tasksCompleted = new bool[10]; //One for each task, adjust as needed
        for(int i = 0; i < tasksCompleted.Length; i++)
        {
            tasksCompleted[i] = data.tasksCompleted[i];
        }
        shelvesMade = data.shelvesMade; //One for each kind, adjust as needed
        currentPayments = data.currentPayments;
        backpackUpgradeNumber = data.backpackUpgradeNumber;
        binocularUpgradeNumber = data.binocularUpgradeNumber;
    }
    #endregion

    public void SaveMushroomName(int index, string name)
    {
        mushroomNames[index] = name;
        //ToDo: UpdateDisplayNames();
    }
}
