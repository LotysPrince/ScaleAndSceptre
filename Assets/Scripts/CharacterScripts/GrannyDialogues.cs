using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrannyDialogues : MonoBehaviour
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
        potentialDialogues[0].name = "Shelly";
        potentialDialogues[0].beginningDialogue = new string[4];
        potentialDialogues[0].beginningDialogue[0] = "You know dear I don't mean to be a bother.";
        potentialDialogues[0].beginningDialogue[1] = "My daugters are in town today.. Do you mind if I borrow a few pearls to go out with them tonight?";
        potentialDialogues[0].beginningDialogue[2] = "They've been thinking about moving back into the kingdom and I wanna show em around. You'll sure make this old cod the happiest fish in the kingdom";
        potentialDialogues[0].beginningDialogue[3] = "CHOICE";

        potentialDialogues[0].yesDialogue = new string[3];
        potentialDialogues[0].yesDialogue[0] = "Oh your majesty you've made me so happy!";
        potentialDialogues[0].yesDialogue[1] = "I promise I'll pay you back my dear ~~";
        potentialDialogues[0].yesDialogue[2] = "And just you wait until the girls hear about this, heheh.";
        potentialDialogues[0].yesHappChange = 3;
        potentialDialogues[0].yesMonChange = -10;
        potentialDialogues[0].yesPopChange = 3;

        potentialDialogues[0].noDialogue = new string[2];
        potentialDialogues[0].noDialogue[0] = "Aww heheh, well no worries dear, I'm sure we'll find something to do";
        potentialDialogues[0].noDialogue[1] = "Thank you anyways! And sorry for being a bother";
        potentialDialogues[0].noHappChange = 3;
        potentialDialogues[0].noMonChange = -10;
        potentialDialogues[0].noPopChange = 3;





        potentialDialogues[1] = new Dialogue();
        potentialDialogues[1].name = "Shelly";
        potentialDialogues[1].beginningDialogue = new string[6];
        potentialDialogues[1].beginningDialogue[0] = "Hello my dear king!";
        potentialDialogues[1].beginningDialogue[1] = "I couldn't help but notice how brilliant the coral is looking today";
        potentialDialogues[1].beginningDialogue[2] = "And how even more brilliant you're looking as well!";
        potentialDialogues[1].beginningDialogue[3] = "Say, would you be willing to go with me to game night with the other ladies in the kingdom?";
        potentialDialogues[1].beginningDialogue[4] = "Who knows, you may even win something! Us old cods are not above playing for a few shells around here heheh.";
        potentialDialogues[1].beginningDialogue[5] = "CHOICE";

        potentialDialogues[1].yesDialogue = new string[2];
        potentialDialogues[1].yesDialogue[0] = "Heheh, I'm gonna be the talk of the town for having you as my date";
        potentialDialogues[1].yesDialogue[1] = "Let's hope we win!";
        potentialDialogues[1].yesHappChange = 2;
        potentialDialogues[1].yesMonChange = Random.Range(0,10);
        potentialDialogues[1].yesPopChange = 0;

        potentialDialogues[1].noDialogue = new string[2];
        potentialDialogues[1].noDialogue[0] = "Aw booo, well as much as I'd love to have gone with you, it's your loss!";
        potentialDialogues[1].noDialogue[1] = "Margerite makes a mean kelp pie!";
        potentialDialogues[1].noHappChange = -1;
        potentialDialogues[1].noMonChange = 0;
        potentialDialogues[1].noPopChange = 0;




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
