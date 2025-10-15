using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ApiTesting : MonoBehaviour
{
    public ChuckNorrisJoke jokeRetrieved;
    public TextMeshProUGUI jokeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        UnityWebRequest imageDownload = UnityWebRequestTexture.GetTexture("");
        UnityWebRequest request = UnityWebRequest.Get("https://api.chucknorris.io/jokes/random");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            //Debug.Log(request.downloadHandler.text);
            jokeRetrieved = JsonUtility.FromJson<ChuckNorrisJoke>(request.downloadHandler.text);
            jokeText.text = jokeRetrieved.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
