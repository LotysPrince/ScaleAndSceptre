using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingSystem : MonoBehaviour
{
    /// <summary>
    /// SCRIPT FOR BUILDING MENU
    /// WHEN CLICKING ON BUY BUTTONS, CHECKS IF YOU HAVE ENOUGH MONEY THEN BUYS THEM
    /// (CURRENTLY DISABLED BASICALLY WHILE I MAKE NEW BUILDING SYSTEM)
    /// </summary>
    /// 


    public GameObject currencyObj;
    public int currentMoney;
    public GameObject priceObj;
    public int currentPrice;
    public int currentLevel;
    public GameObject farmPrefab;
    public GameObject housePrefab;

    private Vector3 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnFarm()
    {
        currentMoney = int.Parse(currencyObj.GetComponent<Text>().text);
        currentPrice = int.Parse(priceObj.GetComponent<TextMeshProUGUI>().text);

        if (currentMoney >= currentPrice)
        {
            FindObjectOfType<OpenBuildMenu>().isOpen = false;

            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(farmPrefab, new Vector3(mousePosition.x, mousePosition.y, -5), Quaternion.identity);



            currentMoney -= currentPrice;
            currencyObj.GetComponent<Text>().text = currentMoney.ToString();

        }
    }

    public void spawnHouse()
    {
        currentMoney = int.Parse(currencyObj.GetComponent<Text>().text);
        currentPrice = int.Parse(priceObj.GetComponent<TextMeshProUGUI>().text);

        if (currentMoney >= currentPrice)
        {
            FindObjectOfType<OpenBuildMenu>().isOpen = false;

            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(housePrefab, new Vector3(mousePosition.x, mousePosition.y, -5), Quaternion.identity);


            currentMoney -= currentPrice;
            currencyObj.GetComponent<Text>().text = currentMoney.ToString();

        }
    }
}
