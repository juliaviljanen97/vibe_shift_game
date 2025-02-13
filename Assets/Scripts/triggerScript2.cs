using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject cardReward; // Kortti, joka aktivoidaan
    private bool convoDone = false; // Tarkistus, ettei samaa korttia voi kerätä useasti

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && convoDone == false) // Tarkistetaan törmäys ja ettei korttia ole jo kerätty
        {
            convoDone = true; // Merkitään kortti kerätyksi
            cardReward.SetActive(true); // Näytetään kortti UI:ssa
        }
    }
}
