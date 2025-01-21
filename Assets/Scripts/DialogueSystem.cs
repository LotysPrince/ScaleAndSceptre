using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;
	public Text popText;
	public Text happText;
	public Text monText;


	public GameObject dialogueBox;
	public GameObject choiceButtons;
	public GameObject exitButton;
	public GameObject houseSprites;
	public GameObject hermitSprites;
	public GameObject farmSprites;

	//objects for the dialogue letter audios
	public AudioClip[] dialogueAudios;
	private AudioSource audioPlayer;


	//arrays for the dialogue structures
	private Queue<string> sentences;
	private Queue<string> yesSentences;
	private Queue<string> noSentences;

	//true/false selectors for triggering choices
	private bool triggerChoice;
	private bool yesTriggered;
	private bool noTriggered;

	//variables for how much to increment currencies
	public int yesPopChange;
	public int yesHappChange;
	public int yesMonChange;
	public int noPopChange;
	public int noHappChange;
	public int noMonChange;

	//portraits
	private GameObject currentPortrait;
	public GameObject SquizardPortrait;
	public GameObject FarmerPortrait;
	public GameObject GrannyPortrait;
	public GameObject DolphinPortrait;
	public GameObject KidPortrait;
	public GameObject MomPortrait;
	public GameObject HermitPortrait;

	// Use this for initialization
	void Start()
	{
		audioPlayer = gameObject.GetComponent<AudioSource>();
		sentences = new Queue<string>();
		yesSentences = new Queue<string>();
		noSentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		exitButton.SetActive(false);
		dialogueBox.SetActive(true);

		triggerChoice = dialogue.triggerChoice;
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.beginningDialogue)
		{
			sentences.Enqueue(sentence);
		}

		if (triggerChoice)
		{
			foreach (string sentence2 in dialogue.yesDialogue)
			{
				yesSentences.Enqueue(sentence2);

			}

			foreach (string sentence2 in dialogue.noDialogue)
			{
				noSentences.Enqueue(sentence2);
			}
		}


		DisplayNextSentence();

		/*
		//if sentence triggers a choice or unlocks a blueprint, does so
		else if (sentence == "CHOICE")
		{
			triggerChoice = true;

		}
		else if (sentence == "HOUSE1 BLUEPRINT")
		{
			houseSprites.SetActive(true);
		}

		else if (sentence == "HERMIT BLUEPRINT")
		{
			hermitSprites.SetActive(true);
		}
		else if (sentence == "FARM BLUEPRINT")
		{
			farmSprites.SetActive(true);
		}
	}*/

	}

	//queues the next sentence to be displayed and feeds it into coroutine to animate it over time
	public void DisplayNextSentence()
	{
		ChangePortrait();
		if (yesTriggered)
		{
			if (yesSentences.Count == 0)
			{
				yesTriggered = false;
				EndDialogue();
				return;
			}

			string yesSentence = yesSentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(yesSentence));
		}
		else if (noTriggered)
		{
			if (noSentences.Count == 0)
			{
				noTriggered = false;
				EndDialogue();
				return;
			}

			string noSentence = noSentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(noSentence));
		}
		else
		{
			if (sentences.Count == 0)
			{
				if (triggerChoice == true)
				{
					EndDialogue();
					EnableChoice();
				}
				else if (triggerChoice == false)
				{
					EndDialogue();
				}

				return;
			}
			string sentence = sentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(sentence));
		}


	}
	

	//changes portrait based on the current name of the person talking
	private void ChangePortrait()
    {
		if (currentPortrait != null)
        {
			currentPortrait.SetActive(false);

		}
		if (nameText.text == "Squizard")
        {
			currentPortrait = SquizardPortrait;
			SquizardPortrait.SetActive(true);
        }
		if(nameText.text == "Shelly")
        {
			currentPortrait = GrannyPortrait;
			GrannyPortrait.SetActive(true);
        }
		if (nameText.text == "Marina")
		{
			currentPortrait = MomPortrait;
			MomPortrait.SetActive(true);
		}
		if (nameText.text == "Gill")
		{
			currentPortrait = FarmerPortrait;
			FarmerPortrait.SetActive(true);
		}
		if (nameText.text == "Child")
		{
			currentPortrait = KidPortrait;
			KidPortrait.SetActive(true);
		}
		if (nameText.text == "Del Phin")
		{
			currentPortrait = DolphinPortrait;
			DolphinPortrait.SetActive(true);
		}
		if (nameText.text == "Hermit")
		{
			currentPortrait = HermitPortrait;
			HermitPortrait.SetActive(true);
		}

	}

	//displays choice buttons
	private void EnableChoice()
    {
		choiceButtons.SetActive(true);
    }


	//changes currencies based off variables
	public void yesChoice()
    {
		dialogueBox.SetActive(true);


		triggerChoice = false;
		yesTriggered = true;
		int currentPopulation = int.Parse(popText.text);
		int currentHappiness = int.Parse(happText.text);
		int currentMoney = int.Parse(monText.text);

		currentPopulation += yesPopChange;
		currentHappiness += yesHappChange;
		currentMoney += yesMonChange;

		popText.text = currentPopulation.ToString();
		happText.text = currentHappiness.ToString();
		monText.text = currentMoney.ToString();

		choiceButtons.SetActive(false);
		DisplayNextSentence();
    }

	//changes currencies based off no choices
	public void noChoice()
    {
		dialogueBox.SetActive(true);

		triggerChoice = false;
		noTriggered = true;

		int currentPopulation = int.Parse(popText.text);
		int currentHappiness = int.Parse(happText.text);
		int currentMoney = int.Parse(monText.text);

		currentPopulation += noPopChange;
		currentHappiness += noHappChange;
		currentMoney += noMonChange;

		popText.text = currentPopulation.ToString();
		happText.text = currentHappiness.ToString();
		monText.text = currentMoney.ToString();

		choiceButtons.SetActive(false);
		DisplayNextSentence();
	}

	/*public void DisplayYesSentence()
	{
		if (yesSentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = yesSentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	public void DisplayNoSentence()
	{
		if (noSentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = noSentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}*/


	//displays sentences letter by letter
	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		//reads the current letter about to be displayed
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			//makes sure the letter is a letter in the alphabet (not a weird symbol like %$#@!)
			var index = char.ToUpper(letter) - 65;
			if (index < 0 || index > 26)
            {
				index = 26;
            }

			//plays audio based off the number of the position of the letter in the alphabet
			audioPlayer.clip = dialogueAudios[index];
			audioPlayer.Play();

			//waits (x) seconds before displayed/playing the sound for the next letter
			yield return new WaitForSecondsRealtime(13 * Time.deltaTime);
		}
	}


	//on dialogue end, hides the dialogue box, stops the audio.
	void EndDialogue()
	{
		//animator.SetBool("IsOpen", false);
		if (!triggerChoice)
		{
			dialogueBox.SetActive(false);
			exitButton.SetActive(true);
			gameObject.GetComponent<VisitorSystem>().citizenVisiting = false;
			StopAllCoroutines();
		}
	}
}
