using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelPhinDialogue : MonoBehaviour
{
    private DialogueTrigger triggerScript;
    private Dialogue currentDialogue;
    private Dialogue newDialogue;
    private Dialogue[] potentialDialogues;
    private bool firstDialogue;

    public GameObject populationObj;
    public GameObject happinessObj;
    public GameObject moneyObj;


    // Start is called before the first frame update
    void Start()
    {
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
        potentialDialogues[0].name = "Del Phin";
        potentialDialogues[0].beginningDialogue = new string[5];
        potentialDialogues[0].beginningDialogue[0] = " My Liege";
        potentialDialogues[0].beginningDialogue[1] = " I have noticed some of King Orctavius’ whales patrolling near our border";
        potentialDialogues[0].beginningDialogue[2] = " I might be able to persuade them to go swim somewhere else";
        potentialDialogues[0].beginningDialogue[3] = " That is of course, if I was to be properly motivated";
        potentialDialogues[0].beginningDialogue[4] = "CHOICE";



        potentialDialogues[0].yesDialogue = new string[2];
        potentialDialogues[0].yesDialogue[0] = " Ah excellent choice my liege";
        potentialDialogues[0].yesDialogue[1] = " I’ll make sure those whales leave your poor citizens alone ";
        potentialDialogues[0].yesHappChange = 0;
        potentialDialogues[0].yesMonChange = -10;
        potentialDialogues[0].yesPopChange = 2;


        potentialDialogues[0].noDialogue = new string[2];
        potentialDialogues[0].noDialogue[0] = " Ah of course my liege.";
        potentialDialogues[0].noDialogue[1] = " I’m sure your keen intellect will be enough to keep those pesky whales at bay";
        potentialDialogues[0].noHappChange = 0;
        potentialDialogues[0].noMonChange = 0;
        potentialDialogues[0].noPopChange = -5;






        potentialDialogues[1] = new Dialogue();
        potentialDialogues[1].name = "Del Phin";
        potentialDialogues[1].beginningDialogue = new string[5];
        potentialDialogues[1].beginningDialogue[0] = " My Liege. ";
        potentialDialogues[1].beginningDialogue[1] = " It has come to my attention that king Orctavius has sent spies among our people ";
        potentialDialogues[1].beginningDialogue[2] = " Of course, I’d love to root them out";
        potentialDialogues[1].beginningDialogue[3] = " but I keep on losing my coin purse! Unless you'd willingly offer me a new one heheh";
        potentialDialogues[1].beginningDialogue[4] = "CHOICE";


        potentialDialogues[1].yesDialogue = new string[2];
        potentialDialogues[1].yesDialogue[0] = " Oh my! This new coin purse is exactly what I needed. ";
        potentialDialogues[1].yesDialogue[1] = " Consider these spies dealt with. ";
        potentialDialogues[1].yesHappChange = 3;
        potentialDialogues[1].yesMonChange = -10;
        potentialDialogues[1].yesPopChange = -2;


        potentialDialogues[1].noDialogue = new string[2];
        potentialDialogues[1].noDialogue[0] = " Hmm, perhaps King Orctavius found my coin purse";
        potentialDialogues[1].noDialogue[1] = " I’ll go ask him ";
        potentialDialogues[1].noHappChange = -2;
        potentialDialogues[1].noMonChange = 0;
        potentialDialogues[1].noPopChange = -5;






        potentialDialogues[2] = new Dialogue();
        potentialDialogues[2].name = "Del Phin";
        potentialDialogues[2].beginningDialogue = new string[5];
        potentialDialogues[2].beginningDialogue[0] = " ...  ";
        potentialDialogues[2].beginningDialogue[1] = " The grand coral is sleeping... ";
        potentialDialogues[2].beginningDialogue[2] = " You're waking it. But that's not a bad thing. ";
        potentialDialogues[2].beginningDialogue[3] = " Have a boon I found in the seaforest. ";
        potentialDialogues[2].beginningDialogue[4] = "CHOICE";

        potentialDialogues[2].yesDialogue = new string[3];
        potentialDialogues[2].yesDialogue[0] = " Enjoy... ";
        potentialDialogues[2].yesDialogue[1] = "  ";
        potentialDialogues[2].yesDialogue[2] = " ";
        potentialDialogues[2].yesHappChange = 0;
        potentialDialogues[2].yesMonChange = 20;
        potentialDialogues[2].yesPopChange = 0;

        potentialDialogues[2].noDialogue = new string[2];
        potentialDialogues[2].noDialogue[0] = " ... ";
        potentialDialogues[2].noDialogue[1] = " ...Okay... ";
        potentialDialogues[2].noHappChange = -5;
        potentialDialogues[2].noMonChange = 0;
        potentialDialogues[2].noPopChange = 0;




        /*int currentMoney = int.Parse(moneyObj.GetComponent<Text>().text);
        int currentPop = int.Parse(populationObj.GetComponent<Text>().text);
        int currentHapp = int.Parse(happinessObj.GetComponent<Text>().text);

        if (currentMoney > 300)
        {
            potentialDialogues[2] = new Dialogue();
            potentialDialogues[2].name = "Shelly";
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
