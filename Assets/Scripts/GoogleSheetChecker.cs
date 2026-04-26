using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GoogleSheetChecker : MonoBehaviour
{
    [SerializeField] private string sheetUrl;

    public GameObject[] sve = new GameObject[7];

    public bool result = false;

    public GameObject appTerminated;

    void Start()
    {
        sheetUrl = "https://script.google.com/macros/s/AKfycbxFDWupNbHmT426edWqf6Ki5OMZ_4pGEJG0VE5zv7b3CDbYVlVH_Raw5mthwTDs-xZJ/exec";
        StartCoroutine(CheckA1());
    }

    IEnumerator CheckA1()
    {
        UnityWebRequest req = UnityWebRequest.Get(sheetUrl);
        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(req.error);
            yield break;
        }

        string value = req.downloadHandler.text.Trim();

        if (value == "1")
        {
            Debug.Log("A1 is 1 → TRUE");
            Kill();
        }
        else
        {
            Debug.Log("A1 is NOT 1: [" + value + "]");
        }
    }

    public void Kill()
    {
        appTerminated.SetActive(true);
        string pathZ = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");

        if (File.Exists(pathZ))
        {
            File.Delete(pathZ);
            Debug.Log("File deleted");
        }
        else
        {
            Debug.Log("File not found");
        }

        string pathS = Path.Combine(Application.persistentDataPath, "SeverityData.txt");

        if (File.Exists(pathS))
        {
            File.Delete(pathS);
            Debug.Log("File deleted");
        }
        else
        {
            Debug.Log("File not found");
        }
        for (int i = 0; i < sve.Length; i++)
        {
            Destroy(sve[i]);
        }
    }
}
