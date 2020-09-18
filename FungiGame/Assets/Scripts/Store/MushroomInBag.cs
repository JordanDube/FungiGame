using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomInBag : MonoBehaviour
{
    [SerializeField] private int itemNum;
    
    public void SendInfo()
    {
        FindObjectOfType<StoreDisplayHandler>().GetComponent<StoreDisplayHandler>().DisplayPriceScreen(itemNum);
    }
}
