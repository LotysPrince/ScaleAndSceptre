using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public bool redHighlighted;
    public bool highlighted;
    public bool yellowHighlighted;
    public Color originalColor;
    public bool tileGridHidden;
    public GameObject buildingContained;

    // Start is called before the first frame update
    void Start()
    {
        highlighted = false;
        originalColor = gameObject.transform.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        tileGridHidden = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (yellowHighlighted)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
        }
        else
        {
            if (highlighted & !tileGridHidden && buildingContained == null)
            {
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, .5f);
            }
            if ((redHighlighted & !tileGridHidden) || (buildingContained != null && !tileGridHidden))
            {
                gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, .5f);
            }
            if (!highlighted && !redHighlighted && !tileGridHidden)
            {
                gameObject.transform.GetComponent<SpriteRenderer>().color = originalColor;
            }
        }
    }

    private void OnMouseEnter()
    {
        var currentBuildingBeingPlaced = GameObject.FindGameObjectWithTag("Building");
        if(currentBuildingBeingPlaced != null )
        {
            if (currentBuildingBeingPlaced.transform.name == "House")
            {
                currentBuildingBeingPlaced.GetComponent<HouseBuilding>().hoveringOnTile = true;
                currentBuildingBeingPlaced.GetComponent<HouseBuilding>().tileHoveringOn = gameObject;
                currentBuildingBeingPlaced.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .5f, -5);

            }
            else
            {
                currentBuildingBeingPlaced.GetComponent<buildingPlacement>().hoveringOnTile = true;
                currentBuildingBeingPlaced.GetComponent<buildingPlacement>().tileHoveringOn = gameObject;
                currentBuildingBeingPlaced.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .85f, -5);

            }


        }
    }

    private void OnMouseExit()
    {
        var currentBuildingBeingPlaced = GameObject.FindGameObjectWithTag("Building");
        if (currentBuildingBeingPlaced != null)
        {
            if (currentBuildingBeingPlaced.transform.name == "House")
            {
                currentBuildingBeingPlaced.GetComponent<HouseBuilding>().hoveringOnTile = false;
                currentBuildingBeingPlaced.GetComponent<HouseBuilding>().tileHoveringOn = null;
            }
            else
            {
                currentBuildingBeingPlaced.GetComponent<buildingPlacement>().hoveringOnTile = false;
                currentBuildingBeingPlaced.GetComponent<buildingPlacement>().tileHoveringOn = null;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.transform.name == "placementZone")
        {
            collisionCount += 1;
        }*/

        if (collision.transform.name == "BuildableZones" )
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {



    }
}
