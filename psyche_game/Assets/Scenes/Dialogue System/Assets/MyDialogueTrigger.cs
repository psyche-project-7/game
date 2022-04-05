using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDialogueTrigger : MonoBehaviour {

	public MyDialogue dialogue;
	public MyDialogueManager dialogueManager;

	private void Start()
	{
		//dialogueManager = FindObjectOfType<MyDialogueManager>();
		TriggerDialogue();
	}

	public void TriggerDialogue ()
	{
		dialogueManager.StartDialogue(dialogue);
		//FindObjectOfType<MyDialogueManager>().StartDialogue(dialogue);
	}

    

}
