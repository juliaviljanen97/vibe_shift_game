using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.EventSystems; // Add this directive

public class ClickScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject dialoguePanel; // connect to the same panel each time
    public GameObject cardReward; // a UI image to toggle on/off after the dialogue if you want
    private GameObject levelManager; // the script where we keep track of the cards found
    //public string dialogueToShow = ""; // but change the dialogue in Inspector for each trigger
    private bool convoDone; // on/off check to not repeat conversations
    private Coroutine swagCardCoroutine; // optional animation

    public GameObject levelM;

    void Start()
    {
        // Hide the dialogue and reward, don't be paused
        dialoguePanel.SetActive(false);
        //dialoguePanel.GetComponentInChildren<TextMeshProUGUI>().text = dialogueToShow;
        cardReward.SetActive(false);
        // Find and assign the LevelManager GameObject
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartDialogue();
        if (gameObject.name == "Quark")
        {
            //Debug.Log("quark");
            levelManager.GetComponent<LevelManager>().cardCount += 1;
        }
        else if (gameObject.name == "Shaker")
        {
            //Debug.Log("shake");
            levelManager.GetComponent<LevelManager>().cardCount += 1;
        }
        else if (gameObject.name == "Creatine")
        {
            //Debug.Log("creatine");
            levelManager.GetComponent<LevelManager>().cardCount += 1;
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
