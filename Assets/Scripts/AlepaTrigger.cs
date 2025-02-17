using UnityEngine;
using UnityEngine.SceneManagement;

public class AlepaTrigger : MonoBehaviour
{
    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Varmistetaan, että pelaaja osuu
        {
            LoadScene(); // Kutsutaan funktiota, joka lataa uuden sceneen
        }
    }

    // Funktio, joka lataa uuden sceneen
    private void LoadScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
