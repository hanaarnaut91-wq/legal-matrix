using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;

public class LoginPageScript : MonoBehaviour
{
    public TMP_InputField mailInputField;
    public TMP_InputField passwordInputField;
    public GameObject loadingAppScreen;

    public string url = "https://script.google.com/macros/s/AKfycbxFDWupNbHmT426edWqf6Ki5OMZ_4pGEJG0VE5zv7b3CDbYVlVH_Raw5mthwTDs-xZJ/exec";

    void OnEnable()
    {
        if(PlayerPrefs.GetInt("prvoPokretanje", 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void Submit()
    {
        string mail = mailInputField.text;
        string pass = passwordInputField.text;

        if(mail == "" || pass == "" || !mail.Contains("@") || !mail.Contains(".com"))
        {
            return;
        }

        //šib na server samo mail
        SendEmail(mail);


        loadingAppScreen.SetActive(true);
        //PlayerPrefs.SetInt("prvoPokretanje", 1);
        
    }

    public void SendEmail(string email)
    {
        StartCoroutine(Send(email));
    }

    IEnumerator Send(string email)
    {
        string json = "{\"email\":\"" + email + "\"}";

        UnityWebRequest req = new UnityWebRequest(url, "POST");
        byte[] body = Encoding.UTF8.GetBytes(json);

        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Saved to Sheet");
        }
        else
        {
            Debug.LogError(req.error);
        }

        //ugasi objekat kad zavrsi coroutine
        gameObject.SetActive(false);
    }
}
