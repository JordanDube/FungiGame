using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GatherMushroomHandler : MonoBehaviour
{
    private int mushroomsCollected = 1;
    [SerializeField] private GameObject gatherMenu;
    [SerializeField] private GameObject mushroomSpawnLocation;
    [SerializeField] private GameObject goHomePanel;
    [SerializeField] private GameObject explorePanel;
    [SerializeField] private TextMeshProUGUI remainingMushrooms;
    [SerializeField] private TextMeshProUGUI numberCollectedRemaining;
    [SerializeField] private GameObject[] mushroomSelectorButtons;
    [SerializeField] private TextMeshProUGUI mushroomNameDisplay;
    private int bagSize;
    private int bagAmount;
    private int mushroomItemNum;
    private string mushroomName;
    private GameManager gameManager;
    private GameObject currentSpawn;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        CalculateBagSize();
    }

    private void CalculateBagSize()
    {
        switch (gameManager.backpackUpgradeNumber)
        {
            case 0: bagSize = 5;
                break;
            case 1: bagSize = 10;
                break;
            case 2: bagSize = 15;
                break;
            case 3: bagSize = 20;
                break;
        }
        for (int i = 0; i < gameManager.backpackContents.Length; i++)
        {
            bagAmount += gameManager.backpackContents[i];
        }
    }
    
    private void AddMushroom()
    {
        int rand = Random.Range(1, 4);
        mushroomsCollected += rand;
    }

    public void HuntArea(int numberOfTiles)
    {
        FindObjectOfType<BackyardLevel>().ClearLevel();
        for (int i = 0; i < numberOfTiles; i++)
        {
            AddMushroom();
        }
        gatherMenu.SetActive(true);
        CalculateBagSize();
        DisplayMushroom();
        //mushroomButton.transform.SetParent(mushroomSpawnLocation.transform);
        
    }

    private void DisplayMushroom()
    {
        
        if (mushroomsCollected > 0)
        {
            numberCollectedRemaining.text = "";
            numberCollectedRemaining.text = "" + (mushroomsCollected - 1);
            if (mushroomsCollected - 1 <= 0)
            {
                numberCollectedRemaining.text = "0";
            }
            remainingMushrooms.text = "" + bagAmount + " / " + bagSize;
            GameObject mushroom =
                Instantiate(mushroomSelectorButtons[Random.Range(0, mushroomSelectorButtons.Length)]);
            mushroom.transform.SetParent(mushroomSpawnLocation.transform, false);
            mushroomItemNum = Int32.Parse(mushroom.name.Substring(0, 1));
            mushroomName = mushroom.name.Substring(1, 8);
            mushroomNameDisplay.text = mushroomName;
            currentSpawn = mushroom;
        }
        else
        {
            explorePanel.SetActive(true);
        } 
    }

    public void DiscardMushroom()
    {
        mushroomsCollected--;
        DisplayMushroom();
        Destroy(currentSpawn.gameObject);
    }

    public void GatherMushroom()
    {
        bagAmount++;
        remainingMushrooms.text = "" + bagAmount + " / " + bagSize;
        mushroomsCollected--;
        gameManager.backpackContents[mushroomItemNum]++;
        if (bagAmount == bagSize)
        {
            goHomePanel.SetActive(true);
        }
        DisplayMushroom();
        Destroy(currentSpawn.gameObject);
        
    }

    public void GoHome()
    {
        goHomePanel.SetActive(false);
        gatherMenu.SetActive(false);
        //ToDo: Open home UI
        
    }

    public void Explore()
    {
        explorePanel.SetActive(false);
        gatherMenu.SetActive(false);
        FindObjectOfType<BackyardLevel>().CreateLevel();
    }
    
}
