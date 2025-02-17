using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int cardCount = 0;

    public GameObject nextLevelButton;

    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextLevelButton.SetActive(false);
    }
    void Update()
    {
        
        if ((currentScene == 1) && cardCount == 12) //  level 1 collect 12 cards
        {
            nextLevelButton.SetActive(true);
        }
        else if ((currentScene == 2) && cardCount == 8) // level 2 has 8 caards
        {
            nextLevelButton.SetActive(true);
        }
        else if (currentScene == 4 && cardCount == 3) // alepa has 3 cards to collect
        {
            nextLevelButton.SetActive(true);
        }
        else if (currentScene == 5 && cardCount == 5) // level 3(5) has 5 cards (3 from alepa already collected)
        {
            nextLevelButton.SetActive(true);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

}
