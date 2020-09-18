using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreDisplayHandler : MonoBehaviour
{
    private GameManager gameManager;
    private NumberHandler numberHandler;
    
    [Header("Info Screens")]
    [SerializeField] private GameObject payScreen;
    [SerializeField] private GameObject bagScreen;
    [SerializeField] private GameObject sightsScreen;
    [SerializeField] private GameObject sellScreen;
    [SerializeField] private GameObject shelfScreen;
    [SerializeField] private GameObject removeScreen;

    [Header("Number Texts")] 
    [SerializeField] private TextMeshProUGUI moneyTotalText;
    [SerializeField] private TextMeshProUGUI shelfPriceText;
    [SerializeField] private TextMeshProUGUI bagPriceText;
    [SerializeField] private TextMeshProUGUI sightPriceText;
    [SerializeField] private TextMeshProUGUI sellPriceText;
    [SerializeField] private TextMeshProUGUI bonusPercentText;
    [SerializeField] private TextMeshProUGUI rentText;
    
    [Header("Shelf Text")]
    [SerializeField] private TextMeshProUGUI[] displayNames;
    
    [Header("Mushroom Images")]
    [SerializeField] private Sprite[] mushroomImages;
    [SerializeField] private Image previewImageLocation;
    [SerializeField] private TextMeshProUGUI mushroomNameSell;
    
    private string[] mushroomNames =
        {"Rover", "Tickler", "Swizbee", "Plumpuff", "Blunch", "Struffle", "Gibb", "Snoozer", "Fredinni", "Muckle"};
    private int[] mushroomPrices = {10, 10, 15, 20, 25, 30, 35, 40, 45, 50};
    private int[] shelfPrices = {100, 250, 500, 1000, 1500, 2000};
    private int[] shelfBonus = {0, 10, 20, 30, 40, 50, 60};
    private int[] sightPrices = {0, 100, 250, 500, 1000};
    private int[] bagPrices = {0, 250, 500, 1000, 1500};

    private int mushroomItem;
    private int mushroomPrice;
    private int sellBonus;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        numberHandler = FindObjectOfType<NumberHandler>().GetComponent<NumberHandler>();
    }

    private void SetItem(int item)
    {
        mushroomItem = item;
        mushroomPrice = mushroomPrices[item];
        int temp = 0;
        for (int i = 0; i < gameManager.onDisplay.Length; i++)
        {
            if (gameManager.onDisplay[i] > 0)
            {
                temp++;
            }
            
        }

        sellBonus = shelfBonus[temp % 2];
    }

    public void SellItem()
    {
        numberHandler.UpdateMoney(true, sellBonus + mushroomPrice);
        sellScreen.SetActive(false);
        SetMoney();
    }

    public void DisplayPriceScreen(int item)
    {
        SetItem(item);
        sellPriceText.text = mushroomPrice.ToString();
        mushroomNameSell.text = mushroomNames[item];
        previewImageLocation.sprite = mushroomImages[item];
        bonusPercentText.text = sellBonus.ToString();
        sellScreen.SetActive(true);
    }

    public void DisplayBagScreen()
    {
        
    }

    #region SetDisplays

    private void SetMoney()
    {
        moneyTotalText.text = numberHandler.GetMoney().ToString();
    }
    private void SetRent()
    {
        rentText.text = numberHandler.GetRent().ToString();
    }

    #endregion
}
