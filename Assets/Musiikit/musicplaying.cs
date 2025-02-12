using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] levelMusic; // Taustamusiikit eri tasoille
    private AudioSource audioSource;

    void Start()
    {
        // Hakee AudioSource-komponentin
        audioSource = GetComponent<AudioSource>();
        
        // Varmistetaan, että musiikki alkaa soimaan heti pelin alussa
        if (audioSource != null && levelMusic.Length > 0)
        {
            audioSource.clip = levelMusic[0]; // Oletusmusiikki ensimmäiselle tasolle
            audioSource.Play();
        }
        
        // Kuuntelee tason latausta
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Vaihda musiikki sen mukaan, mikä taso on ladattu
        int levelIndex = scene.buildIndex;
        
        if (levelIndex < levelMusic.Length)
        {
            audioSource.clip = levelMusic[levelIndex]; // Asetetaan oikea musiikki
            audioSource.Play(); // Soittaa uuden musiikin
        }
    }

    void OnDestroy()
    {
        // Poistaa kuuntelijan, kun objekti tuhotaan
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
