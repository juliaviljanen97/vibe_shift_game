using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI introText1; // First part of the intro
    public TextMeshProUGUI introText2; // Second part of the intro
    public float sceneDelay = 4f; // Time before loading the game

    public Button startButton; // Reference to the Start button
    public Button quitButton;  // Reference to the Quit button

    private bool introText1Clicked = false; // Flag to track if introText1 was clicked
    private bool introText2Clicked = false; // Flag to track if introText2 was clicked

    void Start()
    {
        // Ensure text is hidden at the beginning
        introText1.gameObject.SetActive(false);
        introText2.gameObject.SetActive(false);

        // Ensure buttons are visible at the start
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        // Hide buttons immediately when the intro starts
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        // Start the intro sequence
        StartCoroutine(ShowIntroSequence());
    }

    IEnumerator ShowIntroSequence()
    {
        introText1.gameObject.SetActive(true); // Show first text

        // Wait until introText1 is clicked
        yield return new WaitUntil(() => introText1Clicked);

        introText1.gameObject.SetActive(false); // Hide first text
        introText2.gameObject.SetActive(true); // Show second text

        // Wait until introText2 is clicked
        yield return new WaitUntil(() => introText2Clicked);


        SceneManager.LoadScene("LevelOne"); // Load the game scene
    }

    public void OnIntroText1Clicked()
    {
        introText1Clicked = true;
    }

    public void OnIntroText2Clicked()
    {
        introText2Clicked = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
