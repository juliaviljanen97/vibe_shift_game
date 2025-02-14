using System.Collections;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI;
using UnityEngine.EventSystems; // Add this directive

public class AlepaScript : MonoBehaviour
{
    int alepaTrip = 0;
    private AlepaCheck alepaCheck;
    private static GameObject persistentInventoryCanvas;
    private GameObject ProteinCard;
    private GameObject QuarkCard;

    private GameObject ShakerCard;

    void Start()
    {
        Debug.Log($"Starting AlepaScript on {gameObject.name}");
        
        if (persistentInventoryCanvas == null)
        {
            persistentInventoryCanvas = GameObject.Find("L3Canvas/~~~ INVENTORY ~~~");
            if (persistentInventoryCanvas == null)
            {
                Debug.LogError("Cannot find persistent inventory canvas!");
                return;
            }
        }

        // Debug the hierarchy
        Debug.Log($"Canvas found: {persistentInventoryCanvas.name}");
        Debug.Log($"Children count: {persistentInventoryCanvas.transform.childCount}");
        
        // List all children to verify names
        foreach (Transform child in persistentInventoryCanvas.transform)
        {
            Debug.Log($"Found child: {child.name}");
        }

        // Try to find each card with null checks at each step
        Transform proteinTransform = persistentInventoryCanvas.transform.Find("ProteinCard");
        if (proteinTransform == null)
        {
            Debug.LogError("Could not find ProteinCard transform!");
            return;
        }
        ProteinCard = proteinTransform.gameObject;

        Transform quarkTransform = persistentInventoryCanvas.transform.Find("QuarkCard");
        if (quarkTransform == null)
        {
            Debug.LogError("Could not find QuarkCard transform!");
            return;
        }
        QuarkCard = quarkTransform.gameObject;

        Transform shakerTransform = persistentInventoryCanvas.transform.Find("ShakerCard");
        if (shakerTransform == null)
        {
            Debug.LogError("Could not find ShakerCard transform!");
            return;
        }
        ShakerCard = shakerTransform.gameObject;
    }

    void OnMouseDown()
    {
        Debug.Log($"Clicked on: {gameObject.name}");
       
        if (gameObject.name == "Quark")
        {
            Debug.Log("quark");
            QuarkCard.SetActive(true);
            GameObject.Find("quarkCard").SetActive(true);
            alepaTrip++;
        }
        else if (gameObject.name == "Shaker")
        {
            Debug.Log("shake");
            ShakerCard.SetActive(true);
            GameObject.Find("shakerCard").SetActive(true);
            alepaTrip++;
        }
        else if (gameObject.name == "Creatine")
        {
            Debug.Log("creatine");
            ProteinCard.SetActive(true);
            GameObject.Find("CreatineCard").SetActive(true);
            alepaTrip++;
        }
    }


    public void Update()
    {
        //Debug.Log(alepaTrip);
        if (alepaTrip == 3)
        {
            GameObject alepaCheckObj = GameObject.Find("alepaCheck");
            if (alepaCheckObj != null)
            {
                alepaCheck = alepaCheckObj.GetComponent<AlepaCheck>();
                if (alepaCheck != null)
                {
                    alepaCheck.alepaVisit = true;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("LevelThree");
                }
            }
        }
    }
}

