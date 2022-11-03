using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRequest : MonoBehaviour
{
    private string url = "";

    IEnumerator GetVideoFromServer()
    {
        try
        {

        }
        catch
        {

        }
        yield return url;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetVideoFromServer());
    }
}
