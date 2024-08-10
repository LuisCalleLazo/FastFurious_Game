using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Services;
using FastFurios_Game.UI;
using FastFurios_Game.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FastFurios_Game.Connections
{
    public class Register : MonoBehaviour
    {
        
        public TMP_InputField nameUser;
        public TMP_InputField gmail;
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
            yearBirth.ClearOptions();
            yearBirth.AddOptions(GetDates.GetListYearByDate());
            
            monthBirth.ClearOptions();
            monthBirth.AddOptions(GetDates.GetListMonthByDate());
            
            dayBirth.ClearOptions();
            dayBirth.AddOptions(GetDates.GetListDayByDate());
            
            showPassword.onValueChanged.AddListener(OnToggleValueChanged);
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

                txtRegister.SetActive(false);
                loadBtnReg.SetActive(true);
                animLoadReg.PlayUIAnim();
                
                AuthService.LoginPlayer("nameOrGmail.text", "password.text", 
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
            // Debug.Log("Login failed");
            loadBtnReg.SetActive(false);
            txtRegister.SetActive(true);
            yield return new WaitForSeconds(time);
            isLoading = false;
        }
        
        IEnumerator StopTimeSucces(float time)
        {
            animLoadReg.StopUIAnim();
            // Debug.Log("Login successful");
            yield return new WaitForSeconds(time);
            isLoading = false;
        }
    }
}
