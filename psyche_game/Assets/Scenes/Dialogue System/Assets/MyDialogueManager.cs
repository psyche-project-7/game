using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

    private void Awake()
    {
		sentences = new Queue<string>();
	}

    // Use this for initialization
    void Start () {
		
	}

	public void StartDialogue (MyDialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;
		try {
			sentences.Clear();
		}
		catch (NullReferenceException ex)
        {
			Debug.Log("sentences not set");
        }
		

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
