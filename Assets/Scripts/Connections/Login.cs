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
        public Transform errorsContent;
        public GameObject errorPrefab;
        public float fadeOutDuration = 1.0f;
        public float messageLifetime = 3.0f;
        public float verticalSpacing = 30f;
        private List<GameObject> activeMessages = new List<GameObject>();
        
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
            
            AuthService.LoginPlayer(nameOrGmail.text, password.text, 
                (sucess) =>
                {
                    StartCoroutine(StopTimeSucces(3f));
                },
                (errors) =>
                {
                    DisplayErrors(errors);
                    StartCoroutine(StopTimeFailed(3f));
                }
            );
        }
        IEnumerator StopTimeFailed(float time)
        {
            Debug.Log("Login failed");
            loadBtnLogin.SetActive(false);
            txtLogin.SetActive(true);
            yield return new WaitForSeconds(time);
        }
        IEnumerator StopTimeSucces(float time)
        {
            animLoadLogin.StopUIAnim();
            Debug.Log("Login successful");
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(2);
        }

        public void DisplayErrors(List<string> errors)
        {
            foreach (string error in errors)
            {
                GameObject errorInstance = Instantiate(errorPrefab, errorsContent);
                TMP_Text errorText = errorInstance.GetComponentInChildren<TMP_Text>();
                errorText.text = error;

                activeMessages.Add(errorInstance);
                UpdateMessagePositions();

                StartCoroutine(FadeOutAndRemove(errorInstance));
            }
        }
        private void UpdateMessagePositions()
        {
            for (int i = 0; i < activeMessages.Count; i++)
            {
                
                RectTransform rectTransform = activeMessages[i].GetComponent<RectTransform>();
                
                if (rectTransform == null)
                    rectTransform = activeMessages[i].GetComponentInChildren<RectTransform>();

                
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -i * verticalSpacing);
            }
        }

        private IEnumerator FadeOutAndRemove(GameObject message)
        {
            CanvasGroup canvasGroup = message.GetComponent<CanvasGroup>();
            
            if (canvasGroup == null) canvasGroup = message.AddComponent<CanvasGroup>();

            yield return new WaitForSeconds(messageLifetime);

            float elapsed = 0f;
            while (elapsed < fadeOutDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, elapsed / fadeOutDuration);
                yield return null;
            }

            activeMessages.Remove(message);
            Destroy(message);

            UpdateMessagePositions();
        }
    }
}
