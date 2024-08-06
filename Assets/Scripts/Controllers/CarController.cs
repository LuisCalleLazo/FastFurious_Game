using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Player;
using FastFurios_Game.Utils;
using SimpleInputNamespace;
using UnityEngine;

namespace FastFurios_Game.Controllers
{
    public class CarController : MonoBehaviour
    {
        public GameObject carGo;
        public float turningAngle;
        public float speed;
        public Joystick joystick;
        private string axisHorizontal;

        void Start()
        {
            axisHorizontal = AxesControls.ControlHorizontal();
            carGo = FindObjectOfType<Car>().gameObject;
        }

        void Update()
        {
            float moveHorizontal = joystick.Value.x;
            float moveVertical = joystick.Value.y;

            // Mover el coche en ambas direcciones
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            transform.Translate(movement * speed * Time.deltaTime);

            // Calcular la rotación del coche
            float turnInZ = moveHorizontal * -turningAngle;
            carGo.transform.rotation = Quaternion.Euler(0, 0, turnInZ);

            // Ajustar la rotación en función del movimiento vertical
            if (moveVertical != 0)
            {
                float forwardAngle = moveVertical > 0 ? turningAngle : -turningAngle;
                carGo.transform.Rotate(0, 0, moveHorizontal * forwardAngle * Time.deltaTime);
            }
        }
    }
}
