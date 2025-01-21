using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorSystem : MonoBehaviour
{

    public GameObject[] potentialVisitors; //array of all the currently potential visitors
    public GameObject removedVisitor; //doesnt work very well rn, need to figure something else out
    public GameObject currentVisitor; //visitor currently in the throne room
    public GameObject lastVisitor; //used to make sure the same visitor doesnt keep returning over and over back to back
    public GameObject exitPoint; //point they walk to while leaving
    public GameObject entryPoint; // point they walk to while entering
    public bool citizenVisiting; //current visitor
    public bool gameStarted; //waits until the game starts for the squizard to walk in

    // Start is called before the first frame update
    void Start()
    {
        citizenVisiting = false;
        //gameStarted = false;
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!citizenVisiting && gameStarted)
        {
            VisitorWalkOut();
        }

        if (citizenVisiting && gameStarted)
        {
            VisitorWalkIn();
        }
    }

    public void VisitorWalkIn()
    {
        currentVisitor.transform.position = Vector3.MoveTowards(currentVisitor.transform.position, entryPoint.transform.position, 4 * Time.deltaTime);
        currentVisitor.transform.rotation = Quaternion.Euler(new Vector3(currentVisitor.transform.rotation.x, 0, currentVisitor.transform.rotation.z));
       // currentVisitor.GetComponent<BoxCollider2D>().enabled = true;


    }

    public void VisitorWalkOut()
    {
        currentVisitor.transform.rotation = Quaternion.Euler(new Vector3(currentVisitor.transform.rotation.x, 180, currentVisitor.transform.rotation.z));
        currentVisitor.transform.position = Vector3.MoveTowards(currentVisitor.transform.position, exitPoint.transform.position, 4 * Time.deltaTime);

        //when visitor enters and stops walking, activated the trigger to talk to them
        if(currentVisitor.transform.position == exitPoint.transform.position)
        {
            currentVisitor.GetComponent<BoxCollider2D>().enabled = true;
            if (currentVisitor == potentialVisitors[2])
            {
                removedVisitor = currentVisitor;
            }
            citizenVisiting = false;


            //currentVisitor = potentialVisitors[2];
           
            //citizenVisiting = true;

            NewVisitor();
        }
    }


    private void NewVisitor()
    {
        lastVisitor = currentVisitor;
        currentVisitor = potentialVisitors[3];
        citizenVisiting = true;
        /*currentVisitor = potentialVisitors[Random.Range(0, potentialVisitors.Length)];

        //if its the same visitor twice in a row, rerolls the new visitor
        if(currentVisitor == lastVisitor || currentVisitor == null || currentVisitor == removedVisitor)
        {
            currentVisitor = potentialVisitors[Random.Range(0, potentialVisitors.Length)];

        }
        else
        {
            citizenVisiting = true;
        }*/
    }
}
