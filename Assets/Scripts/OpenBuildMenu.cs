using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuildMenu : MonoBehaviour
{

    /// <summary>
    ///     scripts basically just for opening the building menu whenever you click on it
    /// </summary>

    public bool isOpen;
    public GameObject buildMenu;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen)
        {
            buildMenu.transform.position = Vector3.MoveTowards(buildMenu.transform.position, new Vector3(-150f, buildMenu.transform.position.y, -6), 1500 * Time.deltaTime);

        }
        else if (isOpen)
        {
            buildMenu.transform.position = Vector3.MoveTowards(buildMenu.transform.position, new Vector3(150f, buildMenu.transform.position.y, -6), 1500 * Time.deltaTime);
        }
    }

    public void openMenu()
    {
        if (!isOpen)
        {
            isOpen = true;
        }
        else if (isOpen)
        {
            isOpen = false;
        }
    }
}
