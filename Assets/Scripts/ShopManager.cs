using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;      // Anzeige f�r die Punkte
    public Button pack1Button;              // Button f�r Pack 1
    public Button pack2Button;              // Button f�r Pack 2
    public Button pack3Button;              // Button f�r Pack 3
    public Button backButton;               // Button f�r das Zur�ck ins Main Men�

    public PackOpener packOpener;           // Referenz zum PackOpener-Script
    public GameObject packResultPanel;      // Panel f�r gezogene Spieler

    private int playerPoints;               // Punktzahl des Spielers

    void Start()
    {
        // Punktestand laden
        playerPoints = PlayerPrefs.GetInt("Score", 0);
        UpdatePointsDisplay();

        // Buttons verbinden
        pack1Button.onClick.AddListener(() => BuyPack(50, 2));
        pack2Button.onClick.AddListener(() => BuyPack(100, 5));
        pack3Button.onClick.AddListener(() => BuyPack(150, 8));
        backButton.onClick.AddListener(BackToMainMenu);

        // Panel zu Beginn ausblenden
        if (packResultPanel != null)
        {
            packResultPanel.SetActive(false);
        }
    }

    void UpdatePointsDisplay()
    {
        pointsText.text = "Punkte: " + playerPoints;
    }

    void BuyPack(int packCost, int packSize)
    {
        if (playerPoints >= packCost)
        {
            playerPoints -= packCost;
            Debug.Log("Pack gekauft! Punkte: " + playerPoints);
            UpdatePointsDisplay();

            PlayerPrefs.SetInt("Score", playerPoints);
            PlayerPrefs.Save();

            if (packOpener != null)
            {
                // Packgr��e setzen
                packOpener.packSize = packSize;

                // Pack �ffnen
                List<PlayerData> gezogeneSpieler = packOpener.OpenPack();

                // Spieler anzeigen
                packOpener.DisplayPlayers(gezogeneSpieler);

                // Ergebnis-Panel sichtbar machen
                if (packResultPanel != null)
                {
                    packResultPanel.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("PackOpener nicht gefunden!");
            }
        }
        else
        {
            Debug.Log("Nicht genug Punkte f�r dieses Pack.");
        }
    }

    void BackToMainMenu()
    {
        // Panel ausblenden, falls noch aktiv
        if (packResultPanel != null)
        {
            packResultPanel.SetActive(false);
        }

        // Punktestand speichern
        PlayerPrefs.SetInt("Score", playerPoints);
        PlayerPrefs.Save();

        // Zur�ck zur Hauptszene
        SceneManager.LoadScene("MainMenu");
    }
}
