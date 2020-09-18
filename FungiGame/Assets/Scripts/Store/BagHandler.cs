using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagHandler : MonoBehaviour
{
   [SerializeField] private GameObject bagPanel;
   [SerializeField] private GameObject[] mushroomButtons;

   private GameManager gameManager;

   private void Awake()
   {
      gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
   }

   public void DisplayBagContents()
   {
      for (int i = 0; i < gameManager.backpackContents.Length; i++)
      {
         if (gameManager.backpackContents[i] > 0)
         {
            int amount = gameManager.backpackContents[i];
            for (int j = 0; j < amount; j++)
            {
               GameObject mushroom = Instantiate(mushroomButtons[i]);
               mushroom.transform.SetParent(bagPanel.transform, false);
            }
         }
      }
   }
   
}
