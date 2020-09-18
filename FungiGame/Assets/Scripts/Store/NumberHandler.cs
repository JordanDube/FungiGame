using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberHandler : MonoBehaviour
{
    private GameManager gameManager;
    private int shelfNum;
    private int mushroomsDisplayedNum;
    private int rentRemaining;
    private int money;
    private int bagNum;
    private int sightNum;

    
    //Todo add ALL prices and calculate earnings
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        SetFields();
    }

    public void SetFields()
    {
        SetShelf();
        SetMushroomDisplayNum();
        SetRent();
        SetMoney();
        SetBagNum();
        SetSightNum();
    }
    
    #region "Public Methods"
    public void UpgradeShelf()
    {
        gameManager.shelvesMade++;
        SetShelf();
    }
    public void UpdateDisplayMushroomNum(int item, int slot)
    {
        gameManager.onDisplay[slot] = item;
        SetMushroomDisplayNum();
    }
    public void UpdateRent(int rentSubtract)
    {
        gameManager.currentPayments -= rentSubtract;
        SetRent();
    }
    public void UpdateMoney(bool earn, int amount)
    {
        if (earn)
        {
            gameManager.totalMoney += amount;
        }
        else
        {
            gameManager.totalMoney -= amount;
        }

        SetMoney();
    }
    public void UpgradeBag()
    {
        gameManager.backpackUpgradeNumber++;
        SetBagNum();
    }
    public void UpgradeSight()
    {
        gameManager.binocularUpgradeNumber++;
        SetSightNum();
    }
    #endregion

    #region SetNums
    private void SetShelf()
    {
        shelfNum = gameManager.shelvesMade;
    }
    private void SetMushroomDisplayNum()
    {
        int temp = 0;
        foreach (var mushroom in gameManager.onDisplay)
        {
            if (mushroom > 0)
            {
                temp++;
            }
        }

        mushroomsDisplayedNum = temp;
    }
    private void SetRent()
    {
        rentRemaining = gameManager.currentPayments;
    }
    private void SetMoney()
    {
        money = gameManager.totalMoney;
    }
    private void SetBagNum()
    {
        bagNum = gameManager.backpackUpgradeNumber;
    }
    private void SetSightNum()
    {
        sightNum = gameManager.binocularUpgradeNumber;
    }
    

    #endregion

    #region GetMethods

    public int GetShelfNum()
    {
        return shelfNum;
    }
    
    public int GetRent()
    {
        return rentRemaining;
    }
    public int GetMoney()
    {
        return money;
    }
    public int GetBagNum()
    {
        return bagNum;
    }
    public int GetSightNum()
    {
        return sightNum;
    }

    #endregion
}
