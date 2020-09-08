using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string shopName;
    public float timePlayed;
    public int[] mushroomAmounts; //Determines which mushroom player has for index slot
    public int[] onDisplay; //Set mushroom index number for each display slot
    public string[] mushroomNames;
    public bool[] mushroomsSold; //tracks if mushrooms have been sold before to show prices
    public bool[] tasksCompleted;
    public int shelvesMade;
    public int currentPayments;
    public int backpackUpgradeNumber; //what upgrade number it's currently at
    public int binocularUpgradeNumber;//what upgrade number it's currently at
    //public bool[] areasUnlocked; //If we get to it
}
