using System;

[Serializable]
public class PlayerData : IEquatable<PlayerData>
{
    public string id;
    public string name;
    public string rarity;

    public bool Equals(PlayerData other) => other != null && id == other.id;

    public override bool Equals(object obj) => Equals(obj as PlayerData);

    public override int GetHashCode() => id?.GetHashCode() ?? 0;
}

