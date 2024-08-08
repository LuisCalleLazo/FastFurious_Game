using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Services;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace FastFurios_Game.Connections
{
    public class Login : MonoBehaviour
    {
        public TMP_InputField nameOrGmail;
        public TMP_InputField password; 
            
        public void OnLoginButtonClicked()
        {
            if (password.text.Length <= 6 || password.text.Length > 15)
            {
                Debug.Log("La contraseña es muy corta o muy larga");
                return;
            }
            
            AuthService.LoginPlayer(nameOrGmail.text, password.text, (result) =>
            {
                if (result != null)
                {
                    Debug.Log("Login successful");
                    // msgSucces.SetActive(true);
                    StartCoroutine(StopTimeSucces(3f));
                }
                else
                {
                    Debug.Log("Login failed");
                    // msgFailed.SetActive(true);
                    StartCoroutine(StopTimeFailed(3f));
                }
            });
        }
        IEnumerator StopTimeFailed(float time)
        {
            yield return new WaitForSeconds(time);
            // msgFailed.SetActive(false);
        }
        IEnumerator StopTimeSucces(float time)
        {
            yield return new WaitForSeconds(time);
            // msgSucces.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
