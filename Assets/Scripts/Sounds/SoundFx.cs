using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FastFurios_Game.Sounds
{
    public class SoundFx : MonoBehaviour
    {
        public AudioClip[] fxs;
        AudioSource sounds;

        void Start()
        {
            sounds = GetComponent<AudioSource>();
        }

        // 0 choque
        public void FxSoundChoque()
        {
            sounds.clip = fxs[0];
            sounds.Play();
        }
        // 1 music game
        public void FxSoundMusic()
        {
            sounds.clip = fxs[1];
            sounds.Play();
        }

    }
}
