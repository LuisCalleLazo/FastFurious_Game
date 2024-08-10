using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.UI;
using TMPro;
using UnityEngine;



namespace FastFurios_Game.Connections
{

    public class ManageErrors : MonoBehaviour
    {
        public Transform errorsContent;
        public GameObject errorPrefab;
        public FadeoutSprite fadeout;
        public float verticalSpacing = 30f;
        public List<GameObject> activeMessages = new List<GameObject>();
        
        public void DisplayErrors(List<string> errors)
        {
            foreach (string error in errors)
            {
                GameObject errorInstance = Instantiate(errorPrefab, errorsContent);
                TMP_Text errorText = errorInstance.GetComponentInChildren<TMP_Text>();
                errorText.text = error;

                activeMessages.Add(errorInstance);
                UpdateMessagePositions();
                
                StartCoroutine(fadeout.FadeOutAndRemoveListErros(errorInstance));
                UpdateMessagePositions();
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

    }
}
