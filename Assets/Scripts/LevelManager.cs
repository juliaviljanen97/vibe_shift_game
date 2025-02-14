using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public GameObject level2inv;
    public GameObject[] cards; // Lisää kaikki UI-kortit Inspectorissa
    public int nextLevelIndex; // Määrittele seuraava levelin index

    public int  alepaTrip;

    void Update()
    {
        if (AllCardsCollected()) // Tarkistetaan onko kaikki kortit kerätty
        {
            Destroy(level2inv);
            LoadNextLevel(); // Siirrytään seuraavalle tasolle
        }
        Debug.Log(AllCardsCollected());

        //Debug.Log(alepaTrip);
    if (alepaTrip == 3)
    {
        level2inv.SetActive(false);
        
        // Destroy all DontDestroyOnLoad objects
        var dontDestroyObjects = Object.FindObjectsOfType<GameObject>()
            .Where(go => go.scene.name == "DontDestroyOnLoad");
        foreach (var obj in dontDestroyObjects)
        {
            Destroy(obj);
        }
        
        SceneManager.LoadScene("LevelThreePostAlepa");
    }

    }

    bool AllCardsCollected()
    {
        foreach (GameObject card in cards)
        {
            if (!card.activeInHierarchy) // If any card is not visible, return false
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
