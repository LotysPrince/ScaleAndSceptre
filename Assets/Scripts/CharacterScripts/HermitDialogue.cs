using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HermitDialogue : MonoBehaviour
{
    private DialogueTrigger triggerScript;
    public DialogueSystem dialogueSystem;
    private Dialogue currentDialogue;
    private Dialogue newDialogue;
    private List<Dialogue> potentialDialogues = new List<Dialogue>();
    private bool firstDialogue;

    public GameObject populationObj;
    public GameObject happinessObj;
    public GameObject moneyObj;

    private List<Dialogue> questDialogues = new List<Dialogue>();


    // Start is called before the first frame update
    void Start()
    {
        firstDialogue = true;
        dialogueSystem = GameObject.Find("Scripts").GetComponent<DialogueSystem>();
        triggerScript = gameObject.GetComponent<DialogueTrigger>();
        currentDialogue = triggerScript.dialogue;


        

        createQuestDialogues();
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
            checkQuestTriggers();
            newDialogue = potentialDialogues[Random.Range(0, potentialDialogues.Count)];
            changeDialogue();
        }
    }

    private void createQuestDialogues()
    {
        questDialogues.Add(new Dialogue());
        questDialogues[0].name = "Hermit";
        questDialogues[0].beginningDialogue = new string[5];
        questDialogues[0].beginningDialogue[0] = "Hullo again...";
        questDialogues[0].beginningDialogue[1] = "I see the kingdom is becoming established again";
        questDialogues[0].beginningDialogue[2] = "I'd like if you could help me rebuild my home as well";
        questDialogues[0].beginningDialogue[3] = "It's fallen apart over the years... but I have the original plans for it...";
        questDialogues[0].beginningDialogue[4] = "I would greatly appreciate the help... but please keep it away from other buildings if you can...";
        questDialogues[0].unlockBlueprint = "HermitHouse";
        questDialogues[0].isQuest = true;
        questDialogues[0].questTriggerType = "Houses";
        questDialogues[0].questTriggerAmount = 10;
        questDialogues[0].questCompletionType = "HermitHouse";
        questDialogues[0].questCompletionAmount = 1;

    }


    private void checkQuestTriggers()
    {
        foreach (var dialogue in questDialogues)
        {
            if (dialogue.questTriggerType == "Houses")
            {
                if (dialogueSystem.HousesBuilt >= dialogue.questTriggerAmount && dialogue.questAdded == false)
                {
                    dialogue.questAdded = true;
                    potentialDialogues.Add(dialogue);
                }
            }
        }
    }
    private void createNewDialogues()
    {
        potentialDialogues.Add(new Dialogue());
        potentialDialogues[0].name = "Hermit";
        potentialDialogues[0].beginningDialogue = new string[4];
        potentialDialogues[0].beginningDialogue[0] = " Hullo...  ";
        potentialDialogues[0].beginningDialogue[1] = " I still live alone... ";
        potentialDialogues[0].beginningDialogue[2] = " And I want to keep it that way. ";
        potentialDialogues[0].beginningDialogue[3] = " I need you to stop building houses near my hut. ";
        //potentialDialogues[0].beginningDialogue[4] = "CHOICE";
        potentialDialogues[0].triggerChoice = true;

        potentialDialogues[0].yesDialogue = new string[2];
        potentialDialogues[0].yesDialogue[0] = " Glad to have your understanding. ";
        potentialDialogues[0].yesDialogue[1] = " I won't forget this. ";
        potentialDialogues[0].yesHappChange = 5;
        potentialDialogues[0].yesMonChange = 0;
        potentialDialogues[0].yesPopChange = 0;

        potentialDialogues[0].noDialogue = new string[2];
        potentialDialogues[0].noDialogue[0] = " ... ";
        potentialDialogues[0].noDialogue[1] = " You made an enemy today. ";
        potentialDialogues[0].noHappChange = -5;
        potentialDialogues[0].noMonChange = 0;
        potentialDialogues[0].noPopChange = 0;





        potentialDialogues.Add(new Dialogue());
        potentialDialogues[1].name = "Hermit";
        potentialDialogues[1].beginningDialogue = new string[4];
        potentialDialogues[1].beginningDialogue[0] = " ...  ";
        potentialDialogues[1].beginningDialogue[1] = " I was walking in the woods... ";
        potentialDialogues[1].beginningDialogue[2] = " And I found something that could help you make people happy. ";
        potentialDialogues[1].beginningDialogue[3] = " So let me help you out for once.  ";
        //potentialDialogues[1].beginningDialogue[4] = "CHOICE";
        potentialDialogues[1].triggerChoice = true;

        potentialDialogues[1].yesDialogue = new string[2];
        potentialDialogues[1].yesDialogue[0] = " Can you see it? ";
        potentialDialogues[1].yesDialogue[1] = " You will, soon enough... ";
        potentialDialogues[1].yesHappChange = 10;
        potentialDialogues[1].yesMonChange = 0;
        potentialDialogues[1].yesPopChange = 0;

        potentialDialogues[1].noDialogue = new string[2];
        potentialDialogues[1].noDialogue[0] = " Oh? You don't want my help? ";
        potentialDialogues[1].noDialogue[1] = " Well so be it..";
        potentialDialogues[1].noHappChange = 0;
        potentialDialogues[1].noMonChange = 0;
        potentialDialogues[1].noPopChange = 0;





        potentialDialogues.Add(new Dialogue());
        potentialDialogues[2].name = "Hermit";
        potentialDialogues[2].beginningDialogue = new string[4];
        potentialDialogues[2].beginningDialogue[0] = " ...  ";
        potentialDialogues[2].beginningDialogue[1] = " The grand coral is sleeping... ";
        potentialDialogues[2].beginningDialogue[2] = " You're waking it. But that's not a bad thing. ";
        potentialDialogues[2].beginningDialogue[3] = " Have a boon I found in the seaforest. ";
        //potentialDialogues[2].beginningDialogue[4] = "CHOICE";
        potentialDialogues[2].triggerChoice = true;

        potentialDialogues[2].yesDialogue = new string[3];
        potentialDialogues[2].yesDialogue[0] = " Enjoy... ";
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
