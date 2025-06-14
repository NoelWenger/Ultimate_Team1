using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<PlayerData> ownedPlayers = new List<PlayerData>();
    public int totalPlayers = 150;

    private void Awake()
    {
        // Singleton-Muster: Sicherstellen, dass nur eine Instanz existiert
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Objekt beim Szenenwechsel behalten
        }
        else
        {
            Destroy(gameObject); // Doppelte Instanzen entfernen
        }
    }

    public void AddPlayers(List<PlayerData> players)
    {
        ownedPlayers.AddRange(players); // Neue Spieler hinzufügen
    }

    public string GetProgressText()
    {
        // Einzigartige Spieler zählen (keine Doppelungen)
        int uniqueCount = new HashSet<PlayerData>(ownedPlayers).Count;
        return $"Spieler: {uniqueCount} / {totalPlayers}";
    }
}
