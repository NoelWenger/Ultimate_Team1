using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerList
{
    public List<PlayerData> players;
}

public static class JsonUtilityWrapper
{
    public static List<PlayerData> FromJson(string json)
    {
        // JSON so "wrappen", dass JsonUtility es als Liste erkennt
        string wrappedJson = $"{{\"players\":{json}}}";
        PlayerList playerList = JsonUtility.FromJson<PlayerList>(wrappedJson);
        return playerList.players;
    }
}
