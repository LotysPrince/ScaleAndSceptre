using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

	public string name;

	[TextArea(3, 10)]
	public string[] beginningDialogue;

	[TextArea(3, 10)]
	public string[] yesDialogue;

	[TextArea(3, 10)]
	public string[] noDialogue;

	public bool triggerChoice;
	public string unlockBlueprint;

	public int yesPopChange;
	public int yesHappChange;
	public int yesMonChange;

	public int noPopChange;
	public int noHappChange;
	public int noMonChange;

}
