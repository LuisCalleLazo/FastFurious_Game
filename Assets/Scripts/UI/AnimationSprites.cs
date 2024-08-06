
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FastFurios_Game.UI
{

    public class AnimationSprites : MonoBehaviour
    {
        private Image imageCont;
        public Sprite[] spritesArray;
        public float speed = .07f;
        private int indexSprite;
        Coroutine corutineAnim;
        bool play = true;

        void Awake()
        {
            imageCont = GetComponent<Image>();
        }
        
        void Start()
        {
            if(play) StartCoroutine(PlayAnimUI());
        }

        public void PlayUIAnim()
        {
            play = true;
            StartCoroutine(PlayAnimUI());
        }

        public void StopUIAnim()
        {
            play = false;
            StopCoroutine(PlayAnimUI());
        }

        IEnumerator PlayAnimUI()
        {
            yield return new WaitForSeconds(speed);
            
            if (indexSprite >= spritesArray.Length)
                indexSprite = 0;

            imageCont.sprite = spritesArray[indexSprite];
            indexSprite += 1;
            
            if (play)
                corutineAnim = StartCoroutine(PlayAnimUI());
        }

    }

}