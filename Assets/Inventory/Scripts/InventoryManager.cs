using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Viittaus paneeliin
    public TextMeshProUGUI inventoryText; // Viittaus tekstikenttään
    public Button inventoryButton; // Viittaus inventoryn avaavaan/sulkevaan nappiin

    private List<string> collectedItems = new List<string>(); // Lista kerätyistä esineistä

    void Start()
    {
        inventoryPanel.SetActive(false); // Inventaario alkaa piilotettuna
        inventoryButton.onClick.AddListener(ToggleInventory); // Liitetään nappi toimintoon
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf); // Avaa tai sulje inventaario
    }

    public void AddItem(string itemName)
    {
        collectedItems.Add(itemName);
        UpdateInventoryText();
    }

    private void UpdateInventoryText()
    {
        inventoryText.text = "Kerätyt esineet:\n";
        foreach (string item in collectedItems)
        {
            inventoryText.text += "• " + item + "\n";
        }
    }
}
