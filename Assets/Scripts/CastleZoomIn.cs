using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleZoomIn : MonoBehaviour
{
    /// <summary>
    /// SCRIPT TO TRANSITION BETWEEN SCREENS
    /// SWAPS THE MUSIC, BACKGROUNDS, AND UI
    /// </summary>
    private bool castleClicked;
    [SerializeField] private Camera cam;

    private float camSize;
    private bool zoomFinished;

    //Object references to enable/disable as the transitions occur
    [SerializeField] private GameObject bgDay;
    [SerializeField] private GameObject bgCastle;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject castleObject;
    [SerializeField] private GameObject exitCastleBttn;
    [SerializeField] private GameObject currenciesObj;
    [SerializeField] private GameObject exitButtonFish;
    [SerializeField] private GameObject buildMenu;

    //Audio source for castle music
    [SerializeField] private AudioSource castleBGM;
    private float castleVolumeBGM;


    //variables for failsafes to make sure it only works when it needs to
    private bool isStartingGame = false;
    private bool transitionFin = false;
    private bool isExiting = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
        castleClicked = false;
        camSize = 5;
        zoomFinished = false;
        castleVolumeBGM = 0;


        // checks if the start button is clicked, starts the intro with squizard
        if (gameObject.name == "StartButton")
        {
            isStartingGame = true;
            //FindObjectOfType<VisitorSystem>().currentVisitor = GameObject.Find("Backgrounds/castleBG/Squizard");
            FindObjectOfType<VisitorSystem>().VisitorWalkIn();

        }

        //check if you're exiting the castle
        if (gameObject.name == "exitButton")
        {
            isExiting = true;
        }
    }


    //On clicking the different transition objects, differentiates which object is clicked
    //And does the appropriate transition for it
    private void OnMouseDown()
    {
        castleClicked = true;
        transitionFin = false;
        zoomFinished = false;


        //makes the objects clicked invisible without disabling them because it would stop the script from running through
        if (isStartingGame)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
        if (isExiting)
        {
            exitButtonFish.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (castleClicked)
        {
            //different transitions

            //starting game
            if (isStartingGame)
            {
                startGame();
            }

            //exiting castle
            if (isExiting)
            {
                exitCastle();
            }

            //entering castle
            else if (!isStartingGame && !isExiting)
            {
                enterCastle();
            }
        }
    }

    private void startGame()
    {
        //zooms in
        if (!zoomFinished)
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(0.0900000036f, 2.22000003f, -9f), 20 * Time.deltaTime);

            camSize -= 13f * Time.deltaTime;
            camSize = Mathf.Clamp(camSize, .1f, 5f);
            cam.orthographicSize = camSize;
        }

        //when zoomed in, changes scene and UI
        if (cam.gameObject.transform.position == new Vector3(0.0900000036f, 2.22000003f, -9) && cam.orthographicSize == .1f)
        {
            zoomFinished = true;

            bgDay.SetActive(false);
            bgCastle.SetActive(true);
            castleObject.SetActive(false);
            exitCastleBttn.SetActive(false);
            titleScreen.SetActive(false);
            buildMenu.SetActive(false);

        }

        //begins zooming out
        if (zoomFinished)
        {

            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(0,0,-10), 20 * Time.deltaTime);
            camSize += 13f * Time.deltaTime;
            camSize = Mathf.Clamp(camSize, .1f, 5f);
            cam.orthographicSize = camSize;


            //raises volume of the castle music so it can be heard
            castleVolumeBGM += 1f * Time.deltaTime;
            castleVolumeBGM = Mathf.Clamp(castleVolumeBGM, 0, .08f);
            castleBGM.volume = castleVolumeBGM;


            if (cam.gameObject.transform.position == new Vector3(0, 0, -10) && cam.orthographicSize == 5f)
            {
                transitionFin = true;
                castleClicked = false;
            }


            //starts beginning Dialogue with Squizard
            if (isStartingGame && transitionFin == true)
            {
                currenciesObj.SetActive(true);
                gameObject.GetComponent<DialogueTrigger>().enabled = true;
                FindObjectOfType<VisitorSystem>().citizenVisiting = true;
                FindObjectOfType<VisitorSystem>().gameStarted = true;
            }
        }
    }

    //exits the castle
    private void exitCastle()
    {
        //zooms in
        if (!zoomFinished)
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(0.0900000036f, 2.22000003f, -9f), 20 * Time.deltaTime);

            camSize -= 13f * Time.deltaTime;
            camSize = Mathf.Clamp(camSize, .1f, 5f);
            cam.orthographicSize = camSize;
        }

        //when zoomed in, changes scenes
        if (cam.gameObject.transform.position == new Vector3(0.0900000036f, 2.22000003f, -9) && cam.orthographicSize == .1f)
        {
            zoomFinished = true;


            bgDay.SetActive(true);
            bgCastle.SetActive(false);
            buildMenu.SetActive(true);

        }

        //begins zooming out
        if (zoomFinished)
        {

            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(0, 0, -10), 20 * Time.deltaTime);
            camSize += 13f * Time.deltaTime;
            camSize = Mathf.Clamp(camSize, .1f, 5f);
            cam.orthographicSize = camSize;

            //mutes the castle music
            castleVolumeBGM -= 1f * Time.deltaTime;
            castleVolumeBGM = Mathf.Clamp(castleVolumeBGM, 0, .08f);
            castleBGM.volume = castleVolumeBGM;

            if (cam.gameObject.transform.position == new Vector3(0, 0, -10) && cam.orthographicSize == 5f)
            {
                transitionFin = true;
                castleClicked = false;
            }

            //finishes transition, activates UI
            if (isExiting && transitionFin == true)
            {
                currenciesObj.SetActive(true);
                castleObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    //enters the castle
    private void enterCastle()
    {
        //zooms in
        if (!zoomFinished)
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(0.0900000036f, 2.22000003f, -9f), 20 * Time.deltaTime);

            camSize -= 13f * Time.deltaTime;
            camSize = Mathf.Clamp(camSize, .1f, 5f);
            cam.orthographicSize = camSize;
        }

        //when zoomed in, changes scenes
        if (cam.gameObject.transform.position == new Vector3(0.0900000036f, 2.22000003f, -9) && cam.orthographicSize == .1f)
        {
            zoomFinished = true;

            bgDay.SetActive(false);
            bgCastle.SetActive(true);
            buildMenu.SetActive(false);

        }

        //begins zooming out
        if (zoomFinished)
        {

            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, new Vector3(0, 0, -10), 20 * Time.deltaTime);
            camSize += 13f * Time.deltaTime;
            camSize = Mathf.Clamp(camSize, .1f, 5f);
            cam.orthographicSize = camSize;

            //activates castle music
            castleVolumeBGM += .5f * Time.deltaTime;
            castleVolumeBGM = Mathf.Clamp(castleVolumeBGM, 0, .08f);
            castleBGM.volume = castleVolumeBGM;


            if (cam.gameObject.transform.position == new Vector3(0, 0, -10) && cam.orthographicSize == 5f)
            {
                transitionFin = true;
                castleClicked = false;
            }

            if (transitionFin == true)
            {
                currenciesObj.SetActive(true);
                exitCastleBttn.SetActive(true);
                exitCastleBttn.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0.6333122f, 1);
                exitButtonFish.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                gameObject.SetActive(false);
            }
        }
    }
}
