using System.Collections;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;
using UnityEngine.EventSystems; // Add this directive

public class clickScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject dialoguePanel; // connect to the same panel each time
    public GameObject cardReward; // a UI image to toggle on/off after the dialogue if you want
    public string dialogueToShow = ""; // but change the dialogue in Inspector for each trigger
    private bool convoDone; // on/off check to not repeat conversations
    private Coroutine swagCardCoroutine; // optional animation

    public GameObject levelM;

    void Start()
    {
        // Hide the dialogue and reward, don't be paused
        dialoguePanel.SetActive(false);
        dialoguePanel.GetComponentInChildren<TextMeshProUGUI>().text = dialogueToShow;
        cardReward.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartDialogue();
        if (gameObject.name == "Quark")
        {
            Debug.Log("quark");
            levelM.GetComponent<LevelManager>().alepaTrip ++;
        }
        else if (gameObject.name == "Shaker")
        {
            Debug.Log("shake");
            levelM.GetComponent<LevelManager>().alepaTrip ++;
        }
        else if (gameObject.name == "Creatine")
        {
            Debug.Log("creatine");
            levelM.GetComponent<LevelManager>().alepaTrip ++;
        }
    }

    private void StartDialogue()
    {
        if (!convoDone) // checking collision & that we haven't already had this conversation
        {
            dialoguePanel.SetActive(true);
            convoDone = true;
        }
    }

    public void CloseDialogue() // this needs to be linked in the inspector to the corresponding OnClick + of each Button component, and will just reverse what happens in StartDialogue
    {
        dialoguePanel.SetActive(false);
        cardReward.SetActive(true);
    }
}
