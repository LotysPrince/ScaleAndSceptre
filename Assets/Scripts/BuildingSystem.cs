using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        currentMoney = int.Parse(currencyObj.GetComponent<Text>().text);
        currentPrice = int.Parse(priceObj.GetComponent<TextMesh>().text);

        if (currentMoney >= currentPrice)
        {
            FindObjectOfType<OpenBuildMenu>().isOpen = false;

            currentLevel += 1;
            if (gameObject.name == "HousesBuyButton")
            {

                if (currentLevel == 1)
                {
                    level1.SetActive(true);
                    priceObj.GetComponent<TextMesh>().text = "300";
                }
                else if (currentLevel == 2)
                {
                    level1.SetActive(false);
                    level2.SetActive(true);
                    priceObj.GetComponent<TextMesh>().text = "600";

                }
                else if (currentLevel == 3)
                {
                    level2.SetActive(false);
                    level3.SetActive(true);
                    gameObject.SetActive(false);
                }


            }
            else if (gameObject.name == "HermitBuyButton")
            {
                if (currentLevel == 1)
                {
                    level1.SetActive(true);
                    gameObject.SetActive(false);

                }
            }
            else if (gameObject.name == "FarmBuyButton")
            {
                if (currentLevel == 1)
                {
                    level1.SetActive(true);
                    gameObject.SetActive(false);
                    //FindObjectOfType<FarmerDIalogue>().farmsBuilt = true;
                    FindObjectOfType<VisitorSystem>().removedVisitor = null;



                }
            }

            currentMoney -= currentPrice;
            currencyObj.GetComponent<Text>().text = currentMoney.ToString();

        }
    }
}
