using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Viittaus paneeliin
    public GameObject inventoryOpen;


    void Start()
    {
        inventoryPanel.SetActive(false); // Inventaario alkaa piilotettuna
    }

    public void InventoryOpen()
    {
        inventoryPanel.SetActive(true);
        inventoryOpen.SetActive(false);
    }

    public void InventoryClose()
    {
        inventoryPanel.SetActive(false);
        inventoryOpen.SetActive(true);
    }
}
