using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{

    public bool dayTime;
    public float dayRatio;
    public GameObject dayBG;
    //public SpriteRenderer[] dayChildren;
    public GameObject nightBG;
    private SpriteRenderer dayBGSprite;

    public SpriteRenderer overlay;
    public float colorIncrement;

    /*
    public GameObject housesLevel1;
    public GameObject housesLevel2;
    public GameObject housesLevel3;
    public GameObject farms;*/



    //FMOD STUFF
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;
    public float dayFMODparam;
    public float nightFMODparam;
    private float volume;



    public GameObject moneyObj;
    public GameObject populationObject;
    // Start is called before the first frame update
    void Start()
    {
        dayRatio = 0;
        dayBGSprite = dayBG.GetComponent<SpriteRenderer>();
        colorIncrement = 0f;


        //launches FMOD music
        volume = 1f;
        dayFMODparam = 0f;
        nightFMODparam = 0f;
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
        instance.setVolume(0.3f);

        //sets all buildings on nightbg to right color
        /*nightChildren = nightBG.GetComponentsInChildren<SpriteRenderer>();
        dayChildren = dayBG.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in nightChildren)
        {
            child.color = new Color(0.2164471f, 0.4999985f, 0.754717f, 1);
        }*/
        /*var children = new ArrayList();
        SpriteRenderer[] childObjects;
        childObjects = GetComponentsInChildren<SpriteRenderer>(); 
        foreach(SpriteRenderer renderers in childObjects)
        {

        }*/
    }

    // Update is called once per frame
    void Update()
    {

        //pauses the music when the kingdom screen isnt activated
        if (dayBG.activeSelf)
        {
            instance.setPaused(false);
            CycleFMOD();
            CycleDayTime();
        }

        else if (!dayBG.activeSelf)
        {
            instance.setPaused(true);
            CycleFMOD();
            CycleDayTime();
            dayRatio += (.02f * Time.deltaTime) / 2;

        }
        //Debug.Log(dayRatio);
        



    }

    private void CycleDayTime()
    {
        if (dayRatio < 1f && dayRatio > 0.75f || dayRatio < 0.25f ) //daytime
        {

            colorIncrement -= (.028f * Time.deltaTime) /2;

        }
        else if (dayRatio > 0.25f && dayRatio < 0.75f) //nightTime
        {

            colorIncrement += (.028f * Time.deltaTime) /2;

        }
        else if (dayRatio > 1f) //reset to daytime
        {

            dayRatio = 0f;
            /*
            if (farms.activeSelf == true)
            {
                var currMoney = int.Parse(moneyObj.GetComponent<Text>().text);
                currMoney += 50;
                moneyObj.GetComponent<Text>().text = currMoney.ToString();
            }
            if (housesLevel1.activeSelf == true)
            {
                var currPop = int.Parse(populationObject.GetComponent<Text>().text);
                currPop += 10;
                populationObject.GetComponent<Text>().text = currPop.ToString();
            }
            if (housesLevel2.activeSelf == true)
            {
                var currPop = int.Parse(populationObject.GetComponent<Text>().text);
                currPop += 25;
                populationObject.GetComponent<Text>().text = currPop.ToString();
            }
            if (housesLevel3.activeSelf == true)
            {
                var currPop = int.Parse(populationObject.GetComponent<Text>().text);
                currPop += 50;
                populationObject.GetComponent<Text>().text = currPop.ToString();
            }*/


            //colorIncrement = 1f;

        }
        colorIncrement = Mathf.Clamp(colorIncrement, 0, .65f);
        

        //Debug.Log(dayRatio);

        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, colorIncrement);
        /*foreach (SpriteRenderer child in dayChildren)
        {
            child.color = new Color(1, 1, 1, colorIncrement);
        }*/

    }

    //Cycles music
    private void CycleFMOD()
    {
        //during daytime sets night factor to 0, increments day factor
        if (dayRatio < .5f)
        {
            nightFMODparam = 0f;

            //volume += .01f * Time.deltaTime;
            //volume = Mathf.Clamp(volume, 0.5f, 1);
            dayFMODparam += (4f * Time.deltaTime) / 2;
            dayFMODparam = Mathf.Clamp(dayFMODparam, 0, 100);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Day", dayFMODparam);

        }
        //during nighttime, sets day factor to 0, increments night factor
        else if (dayRatio > .5f && dayRatio < 1f)
        {
            dayFMODparam = 0f;

            //volume -= .01f * Time.deltaTime;
            //volume = Mathf.Clamp(volume, 0.5f, 1);
            nightFMODparam += (.04f * Time.deltaTime) / 2;
            nightFMODparam = Mathf.Clamp(nightFMODparam, 0, 1);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Night", nightFMODparam);

        }

    }
}
