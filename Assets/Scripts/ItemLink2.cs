using UnityEngine;
using UnityEngine.SceneManagement;

public class NewItemLink : MonoBehaviour
{
    public string sceneName; // Scene, johon pelaaja menee
    public string playerPrefKey = "PlayerHasVisitedLevel"; // PlayerPrefs avaimen nimi, joka tallentaa käynnin

    private void Start()
    {
        // Alustetaan PlayerPrefs (jos ei ole aiemmin asetettu)
        if (!PlayerPrefs.HasKey(playerPrefKey))
        {
            PlayerPrefs.SetInt(playerPrefKey, 0); // Asetetaan oletusarvo: ei käyty
            PlayerPrefs.Save();
        }
    }

    // Tämä funktio kutsutaan, kun pelaaja menee triggeriin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Varmistetaan, että pelaaja osuu triggeriin
        {
            PlayerPrefs.SetInt(playerPrefKey, 1); // Merkitään pelaaja käyneeksi tasolla
            PlayerPrefs.Save();
            LoadScene(); // Ladataan uusi scene
        }
    }

    // Funktio, joka lataa uuden sceneen
    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Lataa uuden scenen
    }

    // Tämä tarkistaa, onko pelaaja käynyt tasolla, ja aktivoi objektit
    public void CheckPlayerProgress(GameObject[] objectsToActivate)
    {
        if (PlayerPrefs.GetInt(playerPrefKey) == 1) // Tarkistaa, onko pelaaja käynyt tasolla
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true); // Aktivoidaan objektit
            }
        }
    }
}
