using System.Collections;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public GameObject dialoguePanel; // connect to the same panel each time
    public GameObject cardReward; // a UI image to toggle on/off after the dialogue if you want
    private GameObject levelManager; // the script where we keep track of the cards found
    public string dialogueToShow = ""; // but change the dialogue in Inspector for each trigger
    private bool convoDone; // on/off check to not repeat conversations
    private PlayerMovement playerMoveScript; // we'll assign this in the collision and need to save it to use with the close dialogue button

    void Start()
    {
        // Hide the dialogue and reward, don't be paused
        dialoguePanel.SetActive(false);
        dialoguePanel.GetComponentInChildren<TextMeshProUGUI>().text = dialogueToShow;
        cardReward.SetActive(false);

        // Find and assign the LevelManager GameObject
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && convoDone == false) // checking collison & that we haven't already had this conversatioin
        {
            playerMoveScript = collision.GetComponent<PlayerMovement>();
            playerMoveScript.moveSpeed = 0f; // 'pausing' the game by not letting the player move until they click the button in the UI
            dialoguePanel.SetActive(true);
            convoDone = true;
            levelManager.GetComponent<LevelManager>().cardCount += 1; // keeping track of cards in level Manager GO
        }
    }

    public void CloseDialogue() // this needs to be linked in the inspector to the corresponding OnClick + of each Button component, and will just reverse what happens in OnTriggerEnter2D
    {
            dialoguePanel.SetActive(false);
            playerMoveScript.moveSpeed = 5f;
            cardReward.SetActive(true);
    }
}
