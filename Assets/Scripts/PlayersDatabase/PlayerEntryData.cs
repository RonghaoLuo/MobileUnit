using UnityEngine;

[System.Serializable]
public class PlayerEntryData
{
    //public string username;
    public int health;
    public int score;
}

[System.Serializable]
public class AllPlayers
{
    public PlayerEntryData[] allPlayers;
}
