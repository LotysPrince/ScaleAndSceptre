using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmerDIalogue : MonoBehaviour
{
    private DialogueTrigger triggerScript;
    private Dialogue currentDialogue;
    private Dialogue newDialogue;
    private Dialogue[] potentialDialogues;
    private bool firstDialogue;

    public GameObject populationObj;
    public GameObject happinessObj;
    public GameObject moneyObj;
    public bool farmsBuilt;

    // Start is called before the first frame update
    void Start()
    {
        farmsBuilt = false;
        firstDialogue = true;
        triggerScript = gameObject.GetComponent<DialogueTrigger>();
        currentDialogue = triggerScript.dialogue;

        potentialDialogues = new Dialogue[3];

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (firstDialogue)
        {
            firstDialogue = false;
        }
        else
        {
            createNewDialogues();
            newDialogue = potentialDialogues[Random.Range(0, potentialDialogues.Length)];
            changeDialogue();
        }
    }

    private void createNewDialogues()
    {

        potentialDialogues[0] = new Dialogue();
        potentialDialogues[0].name = "Gill";
        potentialDialogues[0].beginningDialogue = new string[4];
        potentialDialogues[0].beginningDialogue[0] = "Welll well well I got some good news! Crops have been MIGHTY plentiful the last few days!";
        potentialDialogues[0].beginningDialogue[1] = "Since ya were so kind to sow me these farmlands, I thought I'd offer ya some of the extra profits we been gettin' ";
        potentialDialogues[0].beginningDialogue[2] = "Would greatly appreciate you takin some of it off ma hands";
        potentialDialogues[0].beginningDialogue[3] = "CHOICE";

        potentialDialogues[0].yesDialogue = new string[1];
        potentialDialogues[0].yesDialogue[0] = "Har har har! Hopefully the harvest continues to be this massive in the coming days as well!";
 
        potentialDialogues[0].yesHappChange = 3;
        potentialDialogues[0].yesMonChange = 50;
        potentialDialogues[0].yesPopChange = 0;

        potentialDialogues[0].noDialogue = new string[3];
        potentialDialogues[0].noDialogue[0] = "Aww shucks, ya  say ya want me to keep it?";
        potentialDialogues[0].noDialogue[1] = "Now how am I gonna ever pay ya back for yur favors if ya decline all my money!";
        potentialDialogues[0].noDialogue[2] = "Haww well I'm still grateful.";

        potentialDialogues[0].noHappChange = 1;
        potentialDialogues[0].noMonChange = 0;
        potentialDialogues[0].noPopChange = 0;





        potentialDialogues[1] = new Dialogue();
        potentialDialogues[1].name = "Gill";
        potentialDialogues[1].beginningDialogue = new string[3];
        potentialDialogues[1].beginningDialogue[0] = "Aw shell, we got some nematodes eattin all the crops!";
        potentialDialogues[1].beginningDialogue[1] = "I need some money for ferilizers 'for they eat all of our food!";
        potentialDialogues[1].beginningDialogue[2] = "CHOICE";

        potentialDialogues[1].yesDialogue = new string[1];
        potentialDialogues[1].yesDialogue[0] = "Hopefully this'll run those suckers out of my darn fields";
        potentialDialogues[1].yesHappChange = 2;
        potentialDialogues[1].yesMonChange = -10;
        potentialDialogues[1].yesPopChange = 0;

        potentialDialogues[1].noDialogue = new string[2];
        potentialDialogues[1].noDialogue[0] = "Huh? There's not gonna be enough food for everyone at this rate!?";
        potentialDialogues[1].noDialogue[1] = "I gotta find some way to get rid of these suckers and quick!";
        potentialDialogues[1].noHappChange = -5;
        potentialDialogues[1].noMonChange = 0;
        potentialDialogues[1].noPopChange = -5;




        /*int currentMoney = int.Parse(moneyObj.GetComponent<Text>().text);
        int currentPop = int.Parse(populationObj.GetComponent<Text>().text);
        int currentHapp = int.Parse(happinessObj.GetComponent<Text>().text);

        if (currentMoney > 200)
        {
            potentialDialogues[2] = new Dialogue();
            potentialDialogues[2].name = "Gill";
            potentialDialogues[2].beginningDialogue = new string[2];
            potentialDialogues[2].beginningDialogue[0] = "Build me a home";
            potentialDialogues[2].beginningDialogue[1] = "I'm old";
        }*/



    }

    public void changeDialogue()
    {
        currentDialogue = newDialogue;
        triggerScript.dialogue = currentDialogue;
    }

}
