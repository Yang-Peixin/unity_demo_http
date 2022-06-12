using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class HttpBehaviour : MonoBehaviour
{
    private string baseUrl = "http://localhost:8099/msg";

    void Start()
    {
        StartCoroutine(GetText());
        StartCoroutine(Upload());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(baseUrl + "/hi");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // 以文本形式显示结果
            Debug.Log("text: " + www.downloadHandler.text);
            Debug.Log("result: " + www.result);

            // 或者获取二进制数据形式的结果
            byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator Upload()
    {
        Dictionary<string, string> formFields = new Dictionary<string, string>();
        formFields.Add("field1", "1");
        formFields.Add("field2", "2");
        
        UnityWebRequest www = UnityWebRequest.Post(baseUrl + "/upload", formFields);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("text: " + www.downloadHandler.text);
            Debug.Log("result: " + www.result);
        }
    }
}