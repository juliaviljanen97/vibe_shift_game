using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSelection : MonoBehaviour
{
    public List<GameObject> allCards; // 28 korttia tänne (Inspectorissa)
    public List<GameObject> selectedCards = new List<GameObject>(); // Tänne valitut 4 korttia
    public Transform displayArea; // Hierarkiasta "DisplayArea"
    public Button drawButton; // UI-nappi

    void Start()
    {
        drawButton.onClick.AddListener(DrawFinalCards);
    }

    public void DrawFinalCards()
    {
        if (allCards.Count < 4) return; // Jos ei ole tarpeeksi kortteja, lopeta

        selectedCards.Clear(); // Tyhjennetään edellinen arvonta
        foreach (Transform child in displayArea) // Piilotetaan vanhat kortit
        {
            child.gameObject.SetActive(false);
        }

        List<GameObject> tempCards = new List<GameObject>(allCards); // Kopio korteista

        for (int i = 0; i < 4; i++)
        {
            int randomIndex = Random.Range(0, tempCards.Count);
            GameObject chosenCard = tempCards[randomIndex];
            selectedCards.Add(chosenCard);
            tempCards.RemoveAt(randomIndex); // Poistetaan valittu kortti, jotta se ei toistu
        }

        ShowCards();
    }

    void ShowCards()
    {
        foreach (GameObject card in selectedCards)
        {
            card.SetActive(true);
            card.transform.SetParent(displayArea, false); // Asetetaan kortti oikeaan paikkaan
        }
    }
}
