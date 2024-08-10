using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FastFurios_Game.UI
{
    public class AnimationByClick : MonoBehaviour
    {
        private Animator anim;
        void Start()
        {
            anim = GetComponent<Animator>();
        }
        public void StartAnimUIPlay(string nameAnim)
        {
            anim.Play(nameAnim);
        }

    }
}
