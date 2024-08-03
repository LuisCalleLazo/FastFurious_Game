using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FastFurios_Game.Controllers
{
    public class SoundController : MonoBehaviour
    {
        public GameObject motorRoadGo;
        public MotorController motorController;
        public Sprite[] numbers;
        
        public GameObject counterNumGo;
        public SpriteRenderer counterNumComp;

        public GameObject cocheControllerGo;
        public GameObject cocheGo;

        void Start()
        {
            InitComponent();
        }

        void InitComponent()
        {
            motorRoadGo = GameObject.Find("MotorRoad");
            motorController = motorRoadGo.GetComponent<MotorController>();

            counterNumGo = GameObject.Find("CounterNumber");
            counterNumComp = counterNumGo.GetComponent<SpriteRenderer>();

            cocheGo = GameObject.Find("Coche");
            cocheControllerGo = GameObject.Find("ControllerCoche");

            InitCountdown();
        }

        void InitCountdown()
        {
            StartCoroutine(Counting());
        }

        IEnumerator Counting()
        {
            cocheControllerGo.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2);

            counterNumComp.sprite = numbers[1];
            this.gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1);
            
            counterNumComp.sprite = numbers[2];
            this.gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1);
            
            counterNumComp.sprite = numbers[3];
            motorController.startGame = true;
            counterNumGo.GetComponent<AudioSource>().Play();
            cocheGo.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2);

            counterNumGo.SetActive(false);
        }


        void Update()
        {
            
        }
    }
}
