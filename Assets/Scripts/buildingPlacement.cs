using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingPlacement : MonoBehaviour
{

    private Vector3 mousePosition;
    private bool followMouse;

    private int collisionCount;

    public PolygonCollider2D placementCircle;
    public PolygonCollider2D spawnCircle;

    public GameObject farmlandPrefab;
    private int spawnedBuildings;
    private int spawnAttempts;
    private List<Transform> spawningTiles = new List<Transform>();
    public bool hoveringOnTile;
    public GameObject tileHoveringOn;
    public GameObject tileGridObject;
    private bool isPlaced;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.name = "Farm";
        tileGridObject = GameObject.Find("TileGrid");
        tileGridObject.SetActive(true);
        var allTiles = GameObject.Find("TileGrid").GetComponentsInChildren<tileManager>();
        foreach (var tile in allTiles)
        {
            tile.GetComponent<tileManager>().tileGridHidden = false;
            tile.GetComponent<SpriteRenderer>().color = tile.GetComponent<tileManager>().originalColor;

        }
        followMouse = true;
        //spawnCircle.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (followMouse)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (!hoveringOnTile)
            {
                gameObject.transform.position = Vector3.Lerp(new Vector3(gameObject.transform.position.x, transform.position.y, -5), new Vector3(mousePosition.x, mousePosition.y + .8f, -5), 5);
            }
        }

        if (!followMouse)
        {

        }

        if (Input.GetMouseButtonDown(0) && tileHoveringOn != null)
        {
            if (collisionCount == 0 && spawnCircle.enabled == true && !isPlaced && tileHoveringOn.GetComponent<tileManager>().buildingContained == null)
            {
                //spawnCircle.enabled = true;
                followMouse = false;
                isPlaced = true;
                gameObject.tag = "Untagged";
                
                var allTiles = GameObject.Find("TileGrid").GetComponentsInChildren<tileManager>();
                foreach (var tile in allTiles)
                {
                    if (tile.highlighted && tile.redHighlighted)
                    {
                        tile.buildingContained = gameObject;
                    }
                    if (tile.highlighted && !tile.redHighlighted && tile.buildingContained == null)
                    { 
                        spawningTiles.Add(tile.gameObject.transform);
                    }
                    var tileColor = tile.GetComponent<SpriteRenderer>().color;
                    tile.GetComponent<tileManager>().tileGridHidden = true;
                    tile.GetComponent<SpriteRenderer>().color = new Color(tileColor.r, tileColor.g, tileColor.b, 0);
                    

                }
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -15 - gameObject.transform.position.y);
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                StartCoroutine(SpawnBuildings());
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.transform.name == "placementZone")
        {
            collisionCount += 1;
        }

        if ( collision.transform.name == "tile" || collision.transform.name == "tile1")
        {
            collision.transform.GetComponent<tileManager>().redHighlighted = true;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.transform.name == "placementZone")
        {
            collisionCount -= 1;
        }
        if (collision.transform.name == "tile" || collision.transform.name == "tile1")
        {
            collision.transform.GetComponent<tileManager>().redHighlighted = false;
        }*/

    }

    private IEnumerator SpawnBuildings()
    {

        var tileToSpawn = spawningTiles[Random.Range(0, spawningTiles.Count)];
        if (tileToSpawn.GetComponent<tileManager>().buildingContained == null)
        {
            Instantiate(farmlandPrefab, new Vector3(tileToSpawn.position.x, tileToSpawn.position.y + .1f, -15 + tileToSpawn.position.y), Quaternion.identity);
            tileToSpawn.GetComponent<tileManager>().buildingContained = gameObject;
        }
        spawningTiles.Remove(tileToSpawn);
        
        /*var randomPoint = RandomPointInBounds(spawnCircle.bounds);
        RaycastHit2D hit = Physics2D.Raycast(randomPoint, -Vector2.up);
        if (hit.collider != null)
        {
            if (hit.collider.transform.name == "spawnZone")
            {
                Instantiate(farmlandPrefab, new Vector3(randomPoint.x, randomPoint.y, -5), Quaternion.identity);
            }

        }*/

        yield return new WaitForSecondsRealtime(1f);
        if (spawningTiles.Count == 0)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(SpawnBuildings());
        }
    }





    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            -10
        );
    }
}
