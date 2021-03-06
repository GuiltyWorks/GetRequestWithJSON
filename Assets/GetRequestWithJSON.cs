﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;

public class GetRequestWithJSON : MonoBehaviour
{
    public string uri = "http://weather.livedoor.com/forecast/webservice/json/v1?city=130010";

    void Start()
    {
        StartCoroutine(GetRequest(this.uri));
    }

    private IEnumerator GetRequest(string uri)
    {
        Debug.Log("-------- GET Request Start --------");
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("GET Request Failure");
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("GET Request Success");
                Debug.Log(request.downloadHandler.text);
                Dictionary<string, object> response = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
                Debug.Log(response["title"]);
            }
        }
    }
}
