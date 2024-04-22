using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoving : MonoBehaviour
{
    private Vector3 randomLocation;
    private Vector3 worldPoint;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        pickRandomLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, worldPoint, 2 * Time.deltaTime);
        if (transform.position.x < worldPoint.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
        }
        else if (transform.position.x > worldPoint.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
        }

        if (transform.position == worldPoint)
        {
            pickRandomLocation();
        }
    }


    private void pickRandomLocation()
    {

        randomLocation = new Vector3(Random.Range(0f, camera.pixelWidth), Random.Range(0f, camera.pixelHeight), camera.nearClipPlane);
        worldPoint = camera.ScreenToWorldPoint(randomLocation);
    }
}
