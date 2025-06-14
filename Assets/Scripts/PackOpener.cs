using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PackOpener : MonoBehaviour
{
    public int packSize = 5;
    public GameObject playerCardPrefab;  // Prefab mit Text für Name und Seltenheit
    public GameObject packResultPanel;   // Panel mit Button & Kartencontainer
    public Transform cardContainer;      // Container für Spieler-Karten

    public List<PlayerData> OpenPack()
    {
        var selectedPlayers = new List<PlayerData>();
        var allPlayers = PlayerDatabase.allPlayers;

        if (allPlayers.Count == 0)
        {
            Debug.LogWarning("Keine Spieler in der Datenbank.");
            return selectedPlayers;
        }

        packResultPanel.SetActive(true);

        // Alte Karten löschen
        foreach (Transform child in cardContainer)
            Destroy(child.gameObject);

        // Neue Karten ziehen und anzeigen
        for (int i = 0; i < packSize; i++)
        {
            var player = allPlayers[Random.Range(0, allPlayers.Count)];
            selectedPlayers.Add(player);

            var card = Instantiate(playerCardPrefab, cardContainer);
            card.transform.localScale = Vector3.one;

            var nameText = card.transform.Find("PlayerNameText")?.GetComponent<TextMeshProUGUI>();
            if (nameText != null) nameText.text = player.name;

            var rarityText = card.transform.Find("PlayerRarityText")?.GetComponent<TextMeshProUGUI>();
            if (rarityText != null) rarityText.text = player.rarity;
        }

        // Spieler zum Inventar hinzufügen
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.AddPlayers(selectedPlayers);
        else
            Debug.LogError("InventoryManager.Instance ist null!");

        return selectedPlayers;
    }

    public void DisplayPlayers(List<PlayerData> players)
    {
        foreach (Transform child in cardContainer)
            Destroy(child.gameObject);

        foreach (var player in players)
        {
            var card = Instantiate(playerCardPrefab, cardContainer);
            card.transform.localScale = Vector3.one;

            var nameText = card.transform.Find("PlayerNameText")?.GetComponent<TextMeshProUGUI>();
            if (nameText != null) nameText.text = player.name;

            var rarityText = card.transform.Find("PlayerRarityText")?.GetComponent<TextMeshProUGUI>();
            if (rarityText != null) rarityText.text = player.rarity;
        }
    }

    public void ClosePackPanel()
    {
        packResultPanel.SetActive(false);
    }
}
