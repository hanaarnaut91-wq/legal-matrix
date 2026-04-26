using UnityEngine;

public class ButtonOppener : MonoBehaviour
{
    public string url = "https://www.linkedin.com/in/hana-arnaut-31791b212/";

    public void Open()
    {
        Application.OpenURL(url);
    }

    public void SendMail()
    {
        string email = "haana.arnaut@gmail.com";
        string subject = "LEGAL_MATRIX_MAIL";
        string body = "...";

        string url =
            "mailto:" + email +
            "?subject=" + Escape(subject) +
            "&body=" + Escape(body);

        Application.OpenURL(url);
    }

    string Escape(string value)
    {
        return UnityEngine.Networking.UnityWebRequest.EscapeURL(value);
    }
}
