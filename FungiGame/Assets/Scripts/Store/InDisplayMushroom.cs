using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDisplayMushroom : MonoBehaviour
{
    [SerializeField] private int itemNum;
    private int location; //locations must be single digit numbers
    public void SendInfo()
    {
        location = Int32.Parse(gameObject.GetComponentInParent<GameObject>().name);
        FindObjectOfType<StoreDisplayHandler>().GetComponent<StoreDisplayHandler>().RemoveMushroomDisplay(itemNum, location);
    }
}
