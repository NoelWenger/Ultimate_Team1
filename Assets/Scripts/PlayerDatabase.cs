using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDatabase : MonoBehaviour
{
    public static List<PlayerData> allPlayers = new List<PlayerData>();

    void Awake()
    {
        LoadPlayerData();
    }

    void LoadPlayerData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "players.json");

        if (!File.Exists(filePath))
        {
            Debug.LogError($"players.json nicht gefunden unter: {filePath}");
            return;
        }

        string json = File.ReadAllText(filePath);
        allPlayers = JsonUtilityWrapper.FromJson(json);
        Debug.Log($"Spielerdaten geladen: {allPlayers.Count}");
    }
}
