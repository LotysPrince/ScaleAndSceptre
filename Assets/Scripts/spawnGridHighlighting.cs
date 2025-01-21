using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGridHighlighting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.transform.name == "placementZone")
        {
            collisionCount += 1;
        }*/

        if (transform.name == "spawnZone" && (collision.transform.name == "tile" || collision.transform.name == "tile1") && collision.transform.GetComponent<tileManager>().buildingContained == null)
        {
            collision.transform.GetComponent<tileManager>().highlighted = true;
        }
        else if (transform.name == "placementZone" && (collision.transform.name == "tile" || collision.transform.name == "tile1") && collision.transform.GetComponent<tileManager>().buildingContained == null)
        {
            collision.transform.GetComponent<tileManager>().redHighlighted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.transform.name == "placementZone")
        {
            collisionCount -= 1;
        }*/
        if (transform.name == "spawnZone" && (collision.transform.name == "tile" || collision.transform.name == "tile1") && collision.transform.GetComponent<tileManager>().buildingContained == null)
        {
            collision.transform.GetComponent<tileManager>().highlighted = false;
        }
        else if (transform.name == "placementZone" && (collision.transform.name == "tile" || collision.transform.name == "tile1") && collision.transform.GetComponent<tileManager>().buildingContained == null)
        {
            collision.transform.GetComponent<tileManager>().redHighlighted = false;
        }

    }
}
