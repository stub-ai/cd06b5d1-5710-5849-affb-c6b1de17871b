using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class KakaoLogin : MonoBehaviour
{
    private string clientId = "YOUR_KAKAO_CLIENT_ID";
    private string redirectUri = "YOUR_REDIRECT_URI";
    private string loginUrl = "https://kauth.kakao.com/oauth/authorize?client_id={0}&redirect_uri={1}&response_type=code";

    public void Login()
    {
        StartCoroutine(LoginCoroutine());
    }

    private IEnumerator LoginCoroutine()
    {
        string url = string.Format(loginUrl, clientId, redirectUri);
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Handle successful login here.
                // The response will include an authorization code which you can exchange for an access token.
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}