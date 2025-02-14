using UnityEngine;
using UnityEngine.SceneManagement;

public class AlepaCheck : MonoBehaviour
{
    public bool alepaVisit = false;

    void OnLevelWasLoaded(int level)
    {
        // Check if we're in LevelThree
        if (SceneManager.GetActiveScene().name == "LevelThree" && alepaVisit)
        {
            GameObject player = GameObject.Find("player");
            if (player != null)
            {
                player.transform.position = new Vector3(12.28f, 3.38f, 0f);
            }
            
            GameObject alepa = GameObject.Find("Alepa");
            if (alepa != null)
            {
                Destroy(alepa);
            }
        }
    }
}