using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    public GameObject playerCardPrefab;
    public Transform cardContainer;

    private void OnEnable()
    {
        UpdateProgress();
        DisplayPlayers();
    }

    void UpdateProgress()
    {
        if (InventoryManager.Instance != null && progressText != null)
        {
            progressText.text = InventoryManager.Instance.GetProgressText();
        }
    }

    void DisplayPlayers()
    {
        if (InventoryManager.Instance == null || cardContainer == null || playerCardPrefab == null)
            return;

        // Vorhandene Karten löschen
        foreach (Transform child in cardContainer)
            Destroy(child.gameObject);

        // Neue Karten erstellen
        foreach (var player in InventoryManager.Instance.ownedPlayers)
        {
            GameObject card = Instantiate(playerCardPrefab, cardContainer);
            card.transform.localScale = Vector3.one;

            var nameText = card.transform.Find("PlayerNameText")?.GetComponent<TextMeshProUGUI>();
            if (nameText != null) nameText.text = player.name;

            var rarityText = card.transform.Find("PlayerRarityText")?.GetComponent<TextMeshProUGUI>();
            if (rarityText != null) rarityText.text = player.rarity;
        }
    }

    public void CloseInventory()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
