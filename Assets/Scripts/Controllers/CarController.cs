using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Player;
using FastFurios_Game.Utils;
using UnityEngine;

namespace FastFurios_Game.Controllers
{
    public class CarController : MonoBehaviour
    {
        public GameObject carGo;
        public float turningAngle;
        public float speed;
        private string axisHorizontal;

        void Start()
        {
            axisHorizontal = AxesControls.ControlHorizontal();
            carGo = FindObjectOfType<Car>().gameObject;
        }

        void Update()
        {
            float turnInZ = 0;
            float axisH = Input.GetAxis(axisHorizontal);
            transform.Translate(Vector2.right * axisH * speed * Time.deltaTime);

            turnInZ = axisH * -turningAngle;
            carGo.transform.rotation = Quaternion.Euler(0,0, turnInZ);
        }
    }
}
