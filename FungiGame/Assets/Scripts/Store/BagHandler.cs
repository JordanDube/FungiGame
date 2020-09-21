using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagHandler : MonoBehaviour
{
   [SerializeField] private GameObject bagPanel;
   [SerializeField] private GameObject[] mushroomButtons;
   [SerializeField] private GameObject emptyMushroomButton;
    private bool bagFull = false;
    private int[] bagSizes = { 5, 10, 15, 20, 25 };

    private GameManager gameManager;

   private void Awake()
   {
      gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
   }

   public void DisplayBagContents()
   {
        int counter = 0;
      for (int i = 0; i < gameManager.backpackContents.Length; i++)
      {
         if (gameManager.backpackContents[i] > 0)
         {
            int amount = gameManager.backpackContents[i];
            for (int j = 0; j < amount; j++)
            {
               GameObject mushroom = Instantiate(mushroomButtons[i]);
               mushroom.transform.SetParent(bagPanel.transform, false);
               counter++;
            }
         }
        
      }
      //prints leftover empties
        int leftOver = bagSizes[gameManager.backpackUpgradeNumber] - counter;
        for(int i = 0; i < leftOver; i++)
        {
            GameObject mushroom = Instantiate(emptyMushroomButton);
            mushroom.transform.SetParent(bagPanel.transform, false);
        }
        if(leftOver > 0)
        {
            bagFull = false;
        }
        else
        {
            bagFull = true;
        }
   }

   public bool IsBagFull()
   {
        return bagFull;
   }
   
}
