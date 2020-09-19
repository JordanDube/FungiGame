using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject mushroomBase1;
    public GameObject mushroomBase2;
    public GameObject mushroomBase3;
    public GameObject mushroomBase4;
    public GameObject mushroomBase5;
    public List<GameObject> spawnPool = new List<GameObject>();
    public List<GameObject> mutableSpawnPool = new List<GameObject>();
    private float random;

    private int spawntime = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        mutableSpawnPool = spawnPool;
        //Move the mushroom to the left;
        for (int i = 0; i < mutableSpawnPool.Count; i++)
        {
            GameObject mushroom = mutableSpawnPool[i];

            mushroom.transform.position -= new Vector3(0.01f, 0f);
            if (mushroom.transform.position.x <= -15)
            {
                Destroy(mushroom);
                spawnPool.RemoveAt(i);
            }
        }

        if (Time.time >= spawntime)
        {
            spawntime += 1;
            random = Random.Range(0, 5);
            if (0 <= random && random < 1)
            {
                GameObject tmp = Instantiate(mushroomBase1, new Vector3(15, Random.Range(-3, 4)), Quaternion.identity);
                spawnPool.Add(tmp);
            }
            else if (1 <= random && random < 2)
            {
                GameObject tmp = Instantiate(mushroomBase2, new Vector3(15, Random.Range(-3, 4)), Quaternion.identity);
                spawnPool.Add(tmp);
            }
            else if(2 <= random && random < 3)
            {
                GameObject tmp = Instantiate(mushroomBase3, new Vector3(15, Random.Range(-3, 4)), Quaternion.identity);
                spawnPool.Add(tmp);
            }
            else if(3 <= random && random < 4)
            {
                GameObject tmp = Instantiate(mushroomBase4, new Vector3(15, Random.Range(-3, 4)), Quaternion.identity);
                spawnPool.Add(tmp);
            }
            else if(4 <= random && random < 5)
            {
                GameObject tmp = Instantiate(mushroomBase5, new Vector3(15, Random.Range(-3, 4)), Quaternion.identity);
                spawnPool.Add(tmp);
            }
        }

    }
}
