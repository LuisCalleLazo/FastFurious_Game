using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Services;
using FastFurios_Game.UI;
using FastFurios_Game.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FastFurios_Game.Connections
{
    public class Register : MonoBehaviour
    {
        
        public TMP_InputField nameUser;
        public TMP_InputField emailUser;
        public TMP_Dropdown yearBirth;
        public TMP_Dropdown monthBirth;
        public TMP_Dropdown dayBirth;
        public TMP_InputField newPassword;
        public Toggle showPassword;

        // TODO: ERROS
        public ManageErrors manageErrors;
        
        // TODO: LOADINGS 
        private bool isLoading = false;
        public GameObject txtRegister;
        public GameObject loadBtnReg;
        private AnimationSprites animLoadReg;
        
        void Awake()
        {
            animLoadReg = loadBtnReg.GetComponent<AnimationSprites>();
        }
        
        void Start()
        {
            StartDatesDropDown();
            showPassword.onValueChanged.AddListener(OnToggleValueChanged);
        }

        void StartDatesDropDown()
        {
            yearBirth.ClearOptions();
            yearBirth.AddOptions(GetDates.GetListYearByDate());
            
            monthBirth.ClearOptions();
            monthBirth.AddOptions(GetDates.GetListMonthByDate());
            
            dayBirth.ClearOptions();
            dayBirth.AddOptions(GetDates.GetListDayByDate());
        }
        
        void OnToggleValueChanged(bool isOn)
        {
            if (isOn)
                newPassword.contentType = TMP_InputField.ContentType.Standard;
            else
                newPassword.contentType = TMP_InputField.ContentType.Password;

            newPassword.ForceLabelUpdate();
        }
        
        public void OnRegisterButtonClicked()
        {
            if (!isLoading) 
            {
                isLoading = true;
                var errorsLocal = new List<string>();

                // todo: obtener la fecha a atraves de los dropdown
                string birthdate = @$"{yearBirth.options[yearBirth.value].text}-{monthBirth.options[monthBirth.value].text}-{dayBirth.options[dayBirth.value].text}";

                txtRegister.SetActive(false);
                loadBtnReg.SetActive(true);
                animLoadReg.PlayUIAnim();
                
                AuthService.RegisterPlayer(
                    nameUser.text, 
                    emailUser.text, 
                    newPassword.text,
                    birthdate,
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
        }
        
        IEnumerator StopTimeFailed(float time)
        {
            loadBtnReg.SetActive(false);
            txtRegister.SetActive(true);
            yield return new WaitForSeconds(time);
            isLoading = false;
        }
        
        IEnumerator StopTimeSucces(float time)
        {
            animLoadReg.StopUIAnim();
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene((int)ManageNumberEscene.LoadToLobby);
            isLoading = false;
        }
    }
}
