using System.Collections;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class LevelDialogue : MonoBehaviour
{
    public GameObject dialoguePanel; // Reference to the dialogue panel
    //public TextMeshProUGUI dialogueText; // Reference to the dialogue text
    //public string dialogueToShow; // The dialogue text to show

    void Start()
    {
        // Initially hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Start the dialogue sequence
        StartCoroutine(ShowDialogueSequence());
    }

    IEnumerator ShowDialogueSequence()
    {
        dialoguePanel.SetActive(true); // Show the dialogue panel
        //dialogueText.text = dialogueToShow; // Show the entire dialogue text

        // Wait for mouse click
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        dialoguePanel.SetActive(false); // Hide the dialogue panel when done
    }
}