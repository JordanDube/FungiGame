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
    private bool firstCreate = true;
    private void Awake()
    {
        tilesInPlay = new GameObject[rows * cols];
        CreateLevel(); //ToDo: Remove after testing
    }

    public void CreateLevel()
    {
        for (int i = 0; i < tilesInPlay.Length; i++)
        {
            Destroy(tilesInPlay[i]);
        }
        int rand = Random.Range(0, tiles.Length);
        int tileCounter = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = Instantiate(tiles[rand], transform);
                tile.transform.position = new Vector2(col +transform.position.x, -row + transform.position.y);
                tilesInPlay[tileCounter] = tile;
                tile.GetComponent<ISetListNumber>().SetListNumber(tileCounter);
                tileCounter++;
                rand = Random.Range(0, tiles.Length);
            }
        }

        //transform.position = new Vector2(0,0);
            //transform.position = new Vector2(-cols/2 + .5f, rows/2 - .5f);
        
        
    }

    public void ClearLevel()
    {
        for (int i = 0; i < tilesInPlay.Length; i++)
        {
            Destroy(tilesInPlay[i]);
        }
    }
    
}
