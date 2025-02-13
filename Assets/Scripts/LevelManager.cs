using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] cards; // Lisää kaikki UI-kortit Inspectorissa
    public int nextLevelIndex; // Määrittele seuraava levelin index

    void Update()
    {
        if (AllCardsCollected()) // Tarkistetaan onko kaikki kortit kerätty
        {
            LoadNextLevel(); // Siirrytään seuraavalle tasolle
        }
    }

    bool AllCardsCollected()
    {
        foreach (GameObject card in cards)
        {
            if (!card.activeInHierarchy) // Jos joku kortti ei ole näkyvissä, palautetaan false
            {
                return false;
            }
        }
        return true; // Kaikki kortit ovat kerätty, palautetaan true
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex); // Lataa seuraava taso, joka määritelty nextLevelIndexillä
    }
}
