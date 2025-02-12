using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI introText1; // First part of the intro
    public TextMeshProUGUI introText2; // Second part of the intro
    public float sceneDelay = 4f; // Time before loading the game

    public Button startButton; // Reference to the Start button
    public Button quitButton;  // Reference to the Quit button

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
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        introText1.gameObject.SetActive(false); // Hide first text
        introText2.gameObject.SetActive(true); // Show second text
        yield return new WaitForSeconds(sceneDelay); // Wait for sceneDelay seconds

        SceneManager.LoadScene("LevelOne"); // Load the game scene
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
