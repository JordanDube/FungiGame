using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class AbstractLevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    public int rows;
    public int cols;
    public GameObject[] tilesInPlay;
    private void Awake()
    {
        tilesInPlay = new GameObject[rows * cols];
        CreateLevel(); //ToDo: Remove after testing
    }

    public void CreateLevel()
    {
        int rand = Random.Range(0, tiles.Length);
        int tileCounter = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = Instantiate(tiles[rand], transform);
                tile.transform.position = new Vector2(col, -row);
                tilesInPlay[tileCounter] = tile;
                tile.GetComponent<ISetListNumber>().SetListNumber(tileCounter);
                tileCounter++;
            }
        }
        
        transform.position = new Vector2(-cols/2 + .5f, rows/2 - .5f);
    }
    
}
