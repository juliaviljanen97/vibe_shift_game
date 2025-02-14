using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip level3Music;
    public AudioClip level4Music; // LevelThreeAlepa
    public AudioClip level5Music; // LevelThreeAlepa
    public AudioClip level6Music; // Main-menu

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Musiikki ei katkea scenevaihdoksissa
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Musiikki luuppaa automaattisesti
        SceneManager.sceneLoaded += OnSceneLoaded; // Kuunnellaan scenevaihtoa
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        AudioClip newClip = null;

        if (sceneName == "LevelOne")
            newClip = level1Music;
        else if (sceneName == "LevelTwo")
            newClip = level2Music;
        else if (sceneName == "LevelThree")
            newClip = level3Music;
        else if (sceneName == "LevelThreeAlepa") // Uusi taso
            newClip = level4Music;
            else if (sceneName == "LevelThreePostAlepa") // Uusi taso
            newClip = level5Music;
        else if (sceneName == "Main-menu") // Uusi taso
            newClip = level6Music;

        if (newClip != null && audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}
