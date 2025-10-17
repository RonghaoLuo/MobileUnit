using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardManager : MonoBehaviour
{
    public const string API = "https://mobileunit-ronghao-default-rtdb.firebaseio.com/";
    public const string PLAYERS_ADDRESS = "Players/";

    public string userName = "Eli";

    public List<PlayerEntryData> playerList;

    private PlayerEntryData newDataToBePosted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetAllPlayers());
        StartCoroutine(SavePlayerInfo());
    }

    IEnumerator GetAllPlayers()
    {
        UnityWebRequest playersRequest = UnityWebRequest.Get(API + PLAYERS_ADDRESS + ".json");
        yield return playersRequest.SendWebRequest();

        if (playersRequest.result == UnityWebRequest.Result.Success)
        {
            //Debug.Log(playersRequest.downloadHandler.text);
            string trimmedJson = playersRequest.downloadHandler.text.Replace(" ", "");
            string[] splitData = trimmedJson.Split('{', '}');

            PlayerEntryData tempData;

            foreach (string singleSplitString in splitData)
            {
                if (singleSplitString != "" && !singleSplitString.Contains("health"))
                {
                    //Debug.Log(singleSplitString);
                    playerList.Add(new PlayerEntryData());
                    //playerList[playerList.Count - 1].username = singleSplitString.Trim('"').Trim(',');
                }
                else if (singleSplitString != "" && singleSplitString.Contains("health"))
                {
                    tempData = JsonUtility.FromJson<PlayerEntryData>("{ " + singleSplitString + " }");
                    playerList[playerList.Count - 1].health = tempData.health;
                    playerList[playerList.Count - 1].score = tempData.score;
                }
                
            }

            //playerList = JsonUtility.FromJson<AllPlayers>(playersRequest.downloadHandler.text);
        }

        yield return null;
    }

    IEnumerator SavePlayerInfo()
    {
        yield return new WaitForSeconds(1);

        newDataToBePosted = new PlayerEntryData();
        newDataToBePosted.health = 0;
        newDataToBePosted.score = 10;


        UnityWebRequest playersRequest = UnityWebRequest.Put(API + PLAYERS_ADDRESS + userName + ".json", 
            JsonUtility.ToJson(newDataToBePosted));

        yield return playersRequest.SendWebRequest();

        if (playersRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(playersRequest.downloadHandler.text);
        }

    }
}
