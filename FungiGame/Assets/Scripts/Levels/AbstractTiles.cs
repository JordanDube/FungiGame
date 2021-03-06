﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTiles : MonoBehaviour, ISetListNumber
{
    public bool canHoldMushroom;
    public int listNumber;
    [SerializeField] private bool inBackyard = true; //can add other checks for other levels in the future
    [SerializeField] private Sprite sprite;
    public GameObject highlightAnim;
    private BackyardLevel backyard;
    private GameManager gameManager;
    private GatherMushroomHandler gatherHandler;
    private int binocularUpgradeNum;
    private int mushroomTiles = 0;
    private bool outerMush = false;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        highlightAnim.SetActive(false);
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        gatherHandler = FindObjectOfType<GatherMushroomHandler>().GetComponent<GatherMushroomHandler>();
        binocularUpgradeNum = gameManager.binocularUpgradeNumber;
        if (inBackyard)
        {
            backyard = FindObjectOfType<BackyardLevel>().GetComponent<BackyardLevel>();
        }
    }

    public void SetListNumber(int num)
    {
        listNumber = num;
    }
    private void OnMouseEnter()
    {
        switch (binocularUpgradeNum)
        {
            case 0: TurnOnHighlight();
                break;
            case 1: RowThreeAreaOn();
                break;
            case 2: SquareFourAreaOn();
                break;
            case 3: CrossFiveAreaOn();
                break;
            case 4: BoxNineAreaOn();
                break;
        }
    }

    private void OnMouseExit()
    {
        outerMush = false;
        switch (binocularUpgradeNum)
        {
            case 0: TurnOffHighlight();
                break;
            case 1: RowThreeAreaOff();
                break;
            case 2: SquareFourAreaOff();
                break;
            case 3: CrossFiveAreaOff();
                break;
            case 4: BoxNineAreaOff();
                break;
        }
    }

    private void OnMouseDown()
    {
        switch (binocularUpgradeNum)
            {
                case 0: CheckOne();
                    break;
                case 1: CheckThree();
                    break;
                case 2: CheckFour();
                    break;
                case 3: CheckFive();
                    break;
                case 4: CheckNine();
                    break;
            }
        }

    public void TurnOnHighlight()
    {
        highlightAnim.SetActive(true);
    }
    public void TurnOffHighlight()
    {
        highlightAnim.SetActive(false);
    }

    public void CheckOne()
    {
        if (canHoldMushroom)
        {
            mushroomTiles++;
            gatherHandler.HuntArea(mushroomTiles);
        }
    }

    #region "Area Sizes"

    private void RowThreeAreaOn()
    {
        TurnOnHighlight();
        
            if (inBackyard)
            {
                BackyardThreeOn();
                
            }
    }

    private void BackyardThreeOn()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }
    }
    
    private void RowThreeAreaOff()
    {
        TurnOffHighlight();
        
        if (inBackyard)
        {
            BackyardThreeOff();
                
        }
    }

    private void BackyardThreeOff()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }
    }

    private void CheckThree()
    {
        if (listNumber % backyard.cols != 0)
        {
            if (backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            if (backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }

        if (outerMush || canHoldMushroom)
        {
            gatherHandler.HuntArea(mushroomTiles);
        }
    }
    private void SquareFourAreaOn()
    {
        TurnOnHighlight();
        
        if (inBackyard)
        {
            BackyardFourOn();
        }
    }

    private void BackyardFourOn()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }

        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().TurnOnHighlight();
            if (listNumber % backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber + backyard.cols - 1].GetComponent<BackyardTile>().TurnOnHighlight();
            }
            
        }
    }
    
    private void SquareFourAreaOff()
    {
        TurnOffHighlight();
        
        if (inBackyard)
        {
            BackyardFourOff();
                
        }
    }

    private void BackyardFourOff()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }

        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().TurnOffHighlight();
            if (listNumber % backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber + backyard.cols - 1].GetComponent<BackyardTile>().TurnOffHighlight();
            }
        }
    }

    private void CheckFour()
    {
        if (listNumber % backyard.cols != 0)
        {
            if (backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }

        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            if (backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
            if (listNumber % backyard.cols != 0)
            {
                if (backyard.tilesInPlay[listNumber + backyard.cols - 1].GetComponent<BackyardTile>().canHoldMushroom)
                {
                    mushroomTiles++;
                    outerMush = true;
                }
            }
        }
        
        if (outerMush || canHoldMushroom)
        {
            gatherHandler.HuntArea(mushroomTiles);
        }
    }
    
    private void BoxNineAreaOn()
    {
        TurnOnHighlight();
        
        if (inBackyard)
        {
            BackyardNineOn();
                
        }
    }

    private void BackyardNineOn()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }
        
        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().TurnOnHighlight();
            if (listNumber % backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber + backyard.cols - 1].GetComponent<BackyardTile>().TurnOnHighlight();
            }
            if ((listNumber + 1) %backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber + backyard.cols + 1].GetComponent<BackyardTile>().TurnOnHighlight();
            }
        }
        
        if (listNumber - backyard.cols >= 0)
        {
            backyard.tilesInPlay[listNumber - backyard.cols].GetComponent<BackyardTile>().TurnOnHighlight();
            if (listNumber % backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber - backyard.cols - 1].GetComponent<BackyardTile>().TurnOnHighlight();
            }
            if ((listNumber + 1) %backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber - backyard.cols + 1].GetComponent<BackyardTile>().TurnOnHighlight();
            }
        }
    }
    
    private void BoxNineAreaOff()
    {
        TurnOffHighlight();
        
        if (inBackyard)
        {
            BackyardNineOff();
                
        }
    }

    private void BackyardNineOff()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }
        
        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().TurnOffHighlight();
            if (listNumber % backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber + backyard.cols - 1].GetComponent<BackyardTile>().TurnOffHighlight();
            }
            if ((listNumber + 1) %backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber + backyard.cols + 1].GetComponent<BackyardTile>().TurnOffHighlight();
            }
        }
        
        if (listNumber - backyard.cols >= 0)
        {
            backyard.tilesInPlay[listNumber - backyard.cols].GetComponent<BackyardTile>().TurnOffHighlight();
            if (listNumber % backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber - backyard.cols - 1].GetComponent<BackyardTile>().TurnOffHighlight();
            }
            if ((listNumber + 1) %backyard.cols != 0)
            {
                backyard.tilesInPlay[listNumber - backyard.cols + 1].GetComponent<BackyardTile>().TurnOffHighlight();
            }
        }
    }

    private void CheckNine()
    {
        if (listNumber % backyard.cols != 0)
        {
            if (backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            if (backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }
        
        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            if (backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
            if (listNumber % backyard.cols != 0)
            {
                if (backyard.tilesInPlay[listNumber + backyard.cols - 1].GetComponent<BackyardTile>().canHoldMushroom)
                {
                    mushroomTiles++;
                    outerMush = true;
                }
            }
            if ((listNumber + 1) %backyard.cols != 0)
            {
                if (backyard.tilesInPlay[listNumber + backyard.cols + 1].GetComponent<BackyardTile>().canHoldMushroom)
                {
                    mushroomTiles++;
                    outerMush = true;
                }
            }
        }
        
        if (listNumber - backyard.cols >= 0)
        {
            if (backyard.tilesInPlay[listNumber - backyard.cols].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
            if (listNumber % backyard.cols != 0)
            {
                if (backyard.tilesInPlay[listNumber - backyard.cols - 1].GetComponent<BackyardTile>().canHoldMushroom)
                {
                    mushroomTiles++;
                    outerMush = true;
                }
            }
            if ((listNumber + 1) %backyard.cols != 0)
            {
                if (backyard.tilesInPlay[listNumber - backyard.cols + 1].GetComponent<BackyardTile>().canHoldMushroom)
                {
                    mushroomTiles++;
                    outerMush = true;
                }
            }
            
        }
        if (outerMush || canHoldMushroom)
        {
            gatherHandler.HuntArea(mushroomTiles);
        }
    }
    
    private void CrossFiveAreaOn()
    {
        TurnOnHighlight();
        
        if (inBackyard)
        {
            BackyardFiveOn();
                
        }
    }

    private void BackyardFiveOn()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().TurnOnHighlight();
        }
        
        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().TurnOnHighlight();
        }
        
        if (listNumber - backyard.cols >= 0)
        {
            backyard.tilesInPlay[listNumber - backyard.cols].GetComponent<BackyardTile>().TurnOnHighlight();
        }
    }
    
    private void CrossFiveAreaOff()
    {
        TurnOffHighlight();
        
        if (inBackyard)
        {
            BackyardFiveOff();
                
        }
    }

    private void BackyardFiveOff()
    {
        if (listNumber % backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().TurnOffHighlight();
        }
        
        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().TurnOffHighlight();
        }
        
        if (listNumber - backyard.cols >= 0)
        {
            backyard.tilesInPlay[listNumber - backyard.cols].GetComponent<BackyardTile>().TurnOffHighlight();
        }
    }

    private void CheckFive()
    {
        if (listNumber % backyard.cols != 0)
        {
            if (backyard.tilesInPlay[listNumber - 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }

        if ((listNumber + 1) %backyard.cols != 0)
        {
            if(backyard.tilesInPlay[listNumber + 1].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }
        
        if (listNumber + backyard.cols < backyard.tilesInPlay.Length)
        {
            if(backyard.tilesInPlay[listNumber + backyard.cols].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }
        
        if (listNumber - backyard.cols >= 0)
        {
            if(backyard.tilesInPlay[listNumber - backyard.cols].GetComponent<BackyardTile>().canHoldMushroom)
            {
                mushroomTiles++;
                outerMush = true;
            }
        }
        
        if (outerMush || canHoldMushroom)
        {
            gatherHandler.HuntArea(mushroomTiles);
        }
    }
    #endregion
}
