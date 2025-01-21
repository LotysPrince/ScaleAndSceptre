using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{

    public GameObject[] tile;
    public int gridHeight;
    public int gridWidth;
    public float tileSize;
    private int tileFlip;
    // Start is called before the first frame update
    void Start()
    {
        tileFlip = 0;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var randomTile = tile[tileFlip];
                GameObject newTile = Instantiate(randomTile, transform);

                float posx = (x * tileSize + y * tileSize) / 2f - 5;
                float posY = (x * tileSize - y * tileSize) / 4f;

                newTile.transform.position = new Vector3(gameObject.transform.position.x + posx, gameObject.transform.position.y - posY, -5);
                newTile.transform.SetParent(GameObject.Find("TileGrid").transform);

                if (tileFlip == 0)
                {
                    tileFlip = 1;
                    newTile.name = "tile1";
                }
                else
                {
                    tileFlip = 0;
                    newTile.name = "tile";
                }
            }
        }
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
