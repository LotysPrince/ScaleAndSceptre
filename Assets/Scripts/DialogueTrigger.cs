using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
    public GameObject dialogueBox;


    public bool startOnActive;
    public int yesPopChange;
    public int yesHappChange;
    public int yesMonChange;

    public int noPopChange;
    public int noHappChange;
    public int noMonChange;

    public AudioClip[] voiceClips;

    public GameObject questUI;


    private void Start()
    {
        //not used yet but set to trigger dialogue immediately when an object becomes active for the first time in the game
        // startOnActive set in editor
        if (startOnActive)
        {
            TriggerDialogue();
        }
    }
    private void Update()
    {

    }

    //triggers dialogue on releasing the mouse button, opposed to mouse down
    //to give time for other dialogue scripts to load and begin processing before
    //this one, as it was starting too fast before I guess????
    private void OnMouseUp()
    {

        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //sets the dialogue letter audios to the ones for the current character
        FindObjectOfType<DialogueSystem>().dialogueAudios = voiceClips;


        if (dialogueBox.activeSelf == false && !startOnActive)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
	{
        DialogueSystem dialogueSystem = FindObjectOfType<DialogueSystem>();
        //updates the dialogue system with potential currency changes, then starts dialogue
        dialogueSystem.yesPopChange = dialogue.yesPopChange;
        dialogueSystem.yesHappChange = dialogue.yesHappChange;
        dialogueSystem.yesMonChange = dialogue.yesMonChange;
        dialogueSystem.noPopChange = dialogue.noPopChange;
        dialogueSystem.noHappChange = dialogue.noHappChange;
        dialogueSystem.noMonChange = dialogue.noMonChange;

        if (dialogue.isQuest)
        {
            questUI.GetComponent<TextMeshProUGUI>().text = questUI.GetComponent<TextMeshProUGUI>().text + "<br>" + dialogue.name + ": " + dialogue.questCompletionType + " built - " + dialogueSystem.HousesBuilt + "/" + dialogue.questCompletionAmount;
        }
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);




    }
}
