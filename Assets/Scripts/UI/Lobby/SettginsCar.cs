
using System.Collections.Generic;
using FastFurios_Game.Utils;
using TMPro;
using UnityEngine;



namespace FastFurios_Game.UI
{
    public class SettingsCar : MonoBehaviour
    {
        public TMP_Dropdown dropColors;
        public bool action;

        void Start()
        {
            dropColors.ClearOptions();
            dropColors.AddOptions(OptionsOfCar.GetTypeCars());
        }

        void Update()
        {

        }
    }
    
}
