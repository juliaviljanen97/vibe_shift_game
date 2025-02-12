using System.Collections;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class kalliojabaScript : MonoBehaviour
{
    public string[] dialogueLines; // Array to hold dialogue lines
    private int currentLine = 0; // Keeps track of the current dialogue line

    public GameObject dialoguePanel; // Reference to the dialogue panel
    public TextMeshProUGUI dialogueText; // Reference to the dialogue text
    public Button nextButton; // Reference to the "Next" button

    void Start()
    {
        // Initially hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Add listener for the "Next" button
        nextButton.onClick.AddListener(DisplayNextLine);
    }

    // Call this method to start the dialogue
    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);  // Show the dialogue panel
        DisplayNextLine();  // Show the first line of dialogue
    }

    // Display the next line of dialogue
    private void DisplayNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine]; // Show the current line
            currentLine++; // Move to the next line
        }
        else
        {
            EndDialogue(); // End the dialogue when all lines are displayed
        }
    }

    // End the dialogue
    private void EndDialogue()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
        currentLine = 0; // Reset the dialogue line counter
    }

    // Detect when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialogue();
        }
    }
}
