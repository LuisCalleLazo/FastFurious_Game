using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Services;
using FastFurios_Game.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace FastFurios_Game.Connections
{
    public class Login : MonoBehaviour
    {
        public TMP_InputField nameOrGmail;
        public TMP_InputField password;
        public Toggle showPassword;
        
        // TODO: LOADINGS 
        public GameObject txtLogin;
        public GameObject loadBtnLogin;
        private AnimationSprites animLoadLogin;

        void Awake()
        {
            animLoadLogin = loadBtnLogin.GetComponent<AnimationSprites>();
        }
        void Start()
        {
            // Suscribirse al evento onValueChanged del Toggle
            showPassword.onValueChanged.AddListener(OnToggleValueChanged);
        }
        
        void OnToggleValueChanged(bool isOn)
        {
            if (isOn)
                password.contentType = TMP_InputField.ContentType.Standard;
            else
                password.contentType = TMP_InputField.ContentType.Password;

            password.ForceLabelUpdate();
        }

        public void OnLoginButtonClicked()
        {
            if (password.text.Length <= 6 || password.text.Length > 15)
            {
                Debug.Log("La contraseña es muy corta o muy larga");
                return;
            }

            txtLogin.SetActive(false);
            loadBtnLogin.SetActive(true);
            animLoadLogin.PlayUIAnim();
            
            AuthService.LoginPlayer(nameOrGmail.text, password.text, (result) =>
            {

                animLoadLogin.StopUIAnim();

                if (result.Player != null)
                {
                    Debug.Log("Login successful");
                    // msgSucces.SetActive(true);
                    StartCoroutine(StopTimeSucces(3f));
                }
                else
                {
                    Debug.Log("Login failed");
                    loadBtnLogin.SetActive(false);
                    txtLogin.SetActive(true);
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
