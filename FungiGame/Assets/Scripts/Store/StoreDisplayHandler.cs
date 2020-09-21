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
    private BagHandler bagHandler;
    
    [Header("Info Screens")]
    [SerializeField] private GameObject payScreen;
    [SerializeField] private GameObject bagScreen;
    [SerializeField] private GameObject bagPriceAcceptButton;
    [SerializeField] private GameObject sightsScreen;
    [SerializeField] private GameObject sightPriceAcceptButton;
    [SerializeField] private GameObject sellScreen;
    [SerializeField] private GameObject shelfScreen;
    [SerializeField] private GameObject shelfPriceAcceptButton;
    [SerializeField] private GameObject removeScreen;
    [SerializeField] private GameObject keyboardScreen;

    [Header("Number Texts")] 
    [SerializeField] private TextMeshProUGUI moneyTotalText;
    [SerializeField] private TextMeshProUGUI shelfPriceText;
    [SerializeField] private TextMeshProUGUI bagPriceText;
    [SerializeField] private TextMeshProUGUI sightPriceText;
    [SerializeField] private TextMeshProUGUI sellPriceText;
    [SerializeField] private TextMeshProUGUI bonusPercentText;
    [SerializeField] private TextMeshProUGUI rentText;
    
    [Header("Shelf Displays")]
    [SerializeField] private TextMeshProUGUI[] displayNames;
    [SerializeField] private GameObject[] shelfDisplayPosition;
    
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
    int bagState;
    int sightState;
    int shelfState;
    int numOnDisplay;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        numberHandler = FindObjectOfType<NumberHandler>().GetComponent<NumberHandler>();
        bagHandler = FindObjectOfType<BagHandler>().GetComponent<BagHandler>();
    }

    private void CloseScreens()
    {
        payScreen.SetActive(false);
        bagScreen.SetActive(false);
        sightsScreen.SetActive(false);
        sellScreen.SetActive(false);
        shelfScreen.SetActive(false);
        removeScreen.SetActive(false);
    }
    public void OpenStoreFront()
    {
        //bagHandler setup
        //Setup displays, rent
    }

    public void SetupDisplayShelves()
    {
        for(int i = 0; i < gameManager.onDisplay.Length; i++)
        {
            if(gameManager.onDisplay[i] > 0)
            {
                //make a displayed item script that holds public item number and opens remove item screen
            }
        }
    }

    #region DisplayPriceScreen
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
        numOnDisplay = temp;
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
        CloseScreens();
        SetItem(item);
        sellPriceText.text = mushroomPrice.ToString();
        mushroomNameSell.text = mushroomNames[item];
        previewImageLocation.sprite = mushroomImages[item];
        bonusPercentText.text = sellBonus.ToString();
        sellScreen.SetActive(true);
    }

    public void DisplayItem()
    {
        CloseScreens();
        if(numOnDisplay < numberHandler.GetShelfNum()*2)
        {
            //find open spot in shelf
            int slotNumber = 0;
            for(int i = 0; i < gameManager.onDisplay.Length; i++)
            {
                if(gameManager.onDisplay[i] == 0)
                {
                    slotNumber = i;
                    gameManager.onDisplay[i] = mushroomItem;
                    break;
                }
            }
            //open keyboard, send name index
            //create display method
            //Refresh display
        }
    }

    #endregion

    #region DisplayBagScreen
    public void DisplayBagScreen()
    {
        CloseScreens();
        bagScreen.SetActive(true);
        bagState = gameManager.backpackUpgradeNumber;
        bagPriceText.text = (bagPrices[bagState + 1]).ToString();
        bagPriceAcceptButton.SetActive(false);
        if (numberHandler.GetMoney() > bagPrices[bagState + 1])
        {
            bagPriceAcceptButton.SetActive(true);
        }
    }

    public void BuyBagUpgrade()
    {
        numberHandler.UpdateMoney(false, bagPrices[bagState + 1]);
        numberHandler.UpgradeBag();
        SetMoney();
        bagHandler.DisplayBagContents();
        bagScreen.SetActive(false);
    }

    public void CloseBagUpgrade()
    {
        bagScreen.SetActive(false);
    }
    #endregion

    #region DisplaySightScreen

    public void DisplaySightScreen()
    {
        CloseScreens();
        sightsScreen.SetActive(true);
        sightState = gameManager.binocularUpgradeNumber;
        sightPriceText.text = (sightPrices[sightState + 1]).ToString();
        sightPriceAcceptButton.SetActive(false);
        if (numberHandler.GetMoney() > sightPrices[sightState + 1])
        {
            sightPriceAcceptButton.SetActive(true);
        }
    }

    public void BuySightUpgrade()
    {
        numberHandler.UpdateMoney(false, sightPrices[sightState + 1]);
        numberHandler.UpgradeSight();
        SetMoney();
        sightsScreen.SetActive(false);
    }

    public void CloseSightUpgrade()
    {
        sightsScreen.SetActive(false);
    }

    #endregion

    #region DisplayShelfScreen

    public void DisplayShelfScreen()
    {
        CloseScreens();
        shelfScreen.SetActive(true);
        shelfState = gameManager.shelvesMade;
        shelfPriceText.text = shelfPrices[shelfState + 1].ToString();
        shelfPriceAcceptButton.SetActive(false);
        if(numberHandler.GetMoney() > shelfPrices[shelfState + 1])
        {
            shelfPriceAcceptButton.SetActive(true);
        }
    }

    public void BuyShelfUpgrade()
    {
        numberHandler.UpdateMoney(false, shelfPrices[shelfState + 1]);
        numberHandler.UpgradeShelf();
        SetMoney();
        shelfScreen.SetActive(false);
    }

    public void CloseShelfUpgrade()
    {
        shelfScreen.SetActive(false);
    }

    #endregion

    #region RemoveMushroomDisplay

    //call bagHandler.IsBagFull();

    #endregion

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
