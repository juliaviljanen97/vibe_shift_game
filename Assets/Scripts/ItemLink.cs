using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemLink : MonoBehaviour
{
    public string sceneName; // Tämä on se scene, johon pelaaja siirtyy

    // Tämä funktio kutsutaan, kun pelaaja osuu trigger-alueeseen
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
        SceneManager.LoadScene(sceneName); // Lataa uusi scene
    }
}
