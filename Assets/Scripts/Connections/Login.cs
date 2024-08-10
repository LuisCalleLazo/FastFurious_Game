using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Services;
using FastFurios_Game.UI;
using TMPro;
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

        // TODO: ERROS
        public ManageErrors manageErrors;
        
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
            var errorsLocal = new List<string>();
            if (password.text.Length <= 6 || password.text.Length > 15)
            {
                errorsLocal.Add("La contraseña es muy corta o muy larga");
                manageErrors.DisplayErrors(errorsLocal);
                return;
            }

            txtLogin.SetActive(false);
            loadBtnLogin.SetActive(true);
            animLoadLogin.PlayUIAnim();
            
            AuthService.LoginPlayer(nameOrGmail.text, password.text, 
                (sucess) =>
                {
                    StartCoroutine(StopTimeSucces(3f));
                },
                (errors) =>
                {
                    manageErrors.DisplayErrors(errors);
                    StartCoroutine(StopTimeFailed(3f));
                }
            );
        }
        
        IEnumerator StopTimeFailed(float time)
        {
            // Debug.Log("Login failed");
            loadBtnLogin.SetActive(false);
            txtLogin.SetActive(true);
            yield return new WaitForSeconds(time);
        }
        IEnumerator StopTimeSucces(float time)
        {
            animLoadLogin.StopUIAnim();
            // Debug.Log("Login successful");
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(2);
        }
    }
}
