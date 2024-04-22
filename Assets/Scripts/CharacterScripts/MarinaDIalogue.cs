using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarinaDIalogue : MonoBehaviour
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

        potentialDialogues = new Dialogue[4];

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
        potentialDialogues[0].name = "Marina";
        potentialDialogues[0].beginningDialogue = new string[5];
        potentialDialogues[0].beginningDialogue[0] = " Hi, Blobking. ";
        potentialDialogues[0].beginningDialogue[1] = " It's me again. ";
        potentialDialogues[0].beginningDialogue[2] = " I'm desperate. I need some money. ";
        potentialDialogues[0].beginningDialogue[3] = " You must be swimming in cash, right? ";
        potentialDialogues[0].beginningDialogue[4] = "CHOICE";


        potentialDialogues[0].yesDialogue = new string[3];
        potentialDialogues[0].yesDialogue[0] = " Thanks! Maybe you're not so useless after all! ";
        potentialDialogues[0].yesHappChange = 3;
        potentialDialogues[0].yesMonChange = -10;
        potentialDialogues[0].yesPopChange = 3;

        potentialDialogues[0].noDialogue = new string[2];
        potentialDialogues[0].noDialogue[0] = " I should've known... ";
        potentialDialogues[0].noDialogue[0] = " Don't count on my vote in the next election! Do we even elect kings? ....WELL IF WE DO YOU WONT BE GETTING MY VOTE!";
        potentialDialogues[0].noHappChange = -2;
        potentialDialogues[0].noMonChange = 0;
        potentialDialogues[0].noPopChange = 0;







        potentialDialogues[1] = new Dialogue();
        potentialDialogues[1].name = "Marina";
        potentialDialogues[1].beginningDialogue = new string[6];
        potentialDialogues[1].beginningDialogue[0] = " Okay. ";
        potentialDialogues[1].beginningDialogue[1] = " I haven’t slept in 13 days. ";
        potentialDialogues[1].beginningDialogue[2] = " If I'm not helping the kids I'm trying to repair our house that's practically in shambles";
        potentialDialogues[1].beginningDialogue[3] = " I need you to upgrade my house, or it will turn to rubble...";
        potentialDialogues[1].beginningDialogue[4] = " I know its alot to ask but I brought the blueprints just in case.. they're yours to keep";
        potentialDialogues[1].beginningDialogue[5] = "HOUSE1 BLUEPRINT";







        potentialDialogues[2] = new Dialogue();
        potentialDialogues[2].name = "Marina";
        potentialDialogues[2].beginningDialogue = new string[12];
        potentialDialogues[2].beginningDialogue[0] = " Hello my liege. ";
        potentialDialogues[2].beginningDialogue[1] = " SO HELP ME PLANK! I AM GIVING YOU TO THE COUNT OF 5 TO GET YOUR BROTHER OUT OF YOUR MOUTH!";
        potentialDialogues[2].beginningDialogue[2] = " you’ve been doing some great things lately… ";
        potentialDialogues[2].beginningDialogue[3] = " 4  ";
        potentialDialogues[2].beginningDialogue[4] = " for our kingdom  ";
        potentialDialogues[2].beginningDialogue[5] = " 3  ";
        potentialDialogues[2].beginningDialogue[6] = " But I was wondering  ";
        potentialDialogues[2].beginningDialogue[7] = " 2  ";
        potentialDialogues[2].beginningDialogue[8] = " If you would be willing to make a donation";
        potentialDialogues[2].beginningDialogue[9] = " 1 ";
        potentialDialogues[2].beginningDialogue[10] = " To the widow’s society  ";
        potentialDialogues[2].beginningDialogue[11] = "CHOICE";

        potentialDialogues[2].yesDialogue = new string[2];
        potentialDialogues[2].yesDialogue[0] = " Oh, Thank you my king! ";
        potentialDialogues[2].yesDialogue[1] = " C’mon kids lets go get ice-krill! ";
        potentialDialogues[2].yesHappChange = 4;
        potentialDialogues[2].yesMonChange = -10;
        potentialDialogues[2].yesPopChange = 0;

        potentialDialogues[2].noDialogue = new string[2];
        potentialDialogues[2].noDialogue[0] = " Oh, well that’s a little disappointing ";
        potentialDialogues[2].noDialogue[1] = " THAT’S IT YOU TWO, YOU’VE LOST SEA-V PRIVILEGES FOR TWO WEEKS ";
        potentialDialogues[2].noHappChange = -2;
        potentialDialogues[2].noMonChange = 0;
        potentialDialogues[2].noPopChange = 0;





        potentialDialogues[3] = new Dialogue();
        potentialDialogues[3].name = "Marina";
        potentialDialogues[3].beginningDialogue = new string[5];
        potentialDialogues[3].beginningDialogue[0] = " Hello again my liege";
        potentialDialogues[3].beginningDialogue[1] = " PLANK AND TON! BOYS! I’VE TOLD YOU A MILLION TIMES PLEASE LEAVE THAT POOR SQUID ALONE ";
        potentialDialogues[3].beginningDialogue[2] = " I just came by to let you know how much we appreciate everything you’ve been doing for this kingdom";
        potentialDialogues[3].beginningDialogue[3] = " YES I KNOW HIS FACE LOOKS FUNNY NOW LEAVE THE POOR SQUID ALONE";
        potentialDialogues[3].beginningDialogue[4] = " Anyway, I was just wondering if you would be able to babysit this friday.. I know its alot but I desperately need a break..";
        potentialDialogues[3].beginningDialogue[5] = "CHOICE";


        potentialDialogues[3].yesDialogue = new string[3];
        potentialDialogues[3].yesDialogue[0] = " Oh you will?";
        potentialDialogues[3].yesDialogue[1] = " Thank you so much! The kids will be so excited";
        potentialDialogues[3].yesDialogue[2] = " They’re always telling me how you’re their favourite blobfish!";
        potentialDialogues[3].yesHappChange = 5;
        potentialDialogues[3].yesMonChange = -1;
        potentialDialogues[3].yesPopChange = 0;

        potentialDialogues[3].noDialogue = new string[2];
        potentialDialogues[3].noDialogue[0] = " Oh that’s OK";
        potentialDialogues[3].noDialogue[1] = " I know it was a lot to ask for";
        potentialDialogues[3].noHappChange = -1;
        potentialDialogues[3].noMonChange = 0;
        potentialDialogues[3].noPopChange = 0;






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
