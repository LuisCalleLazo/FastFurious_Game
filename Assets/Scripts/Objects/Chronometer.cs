
using FastFurios_Game.Controllers;
using TMPro;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    public GameObject motorRoadsGo;
    public MotorController motorRoadController;
    public float time;
    public float distance;
    public TMP_Text textTime;
    public TMP_Text textDistance;

    // Start is called before the first frame update
    void Start()
    {
        motorRoadsGo = GameObject.Find("MotorRoad");
        motorRoadController = motorRoadsGo.GetComponent<MotorController>();

        textTime.text = "2 : 00";
        textDistance.text = "0";

        time = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(motorRoadController.startGame && !motorRoadController.endGame)
            CalculateTimeDistance();

        if(time <= 0 && !motorRoadController.endGame)
            motorRoadController.endGame = true;
    }

    void CalculateTimeDistance()
    {
        distance += Time.deltaTime * motorRoadController.speed;
        textDistance.text = ((int)distance).ToString();

        time -= Time.deltaTime;
        int minutes = (int) time / 60;
        int seconds = (int) time % 60;

        textTime.text = $"{minutes} : {seconds.ToString().PadLeft(2, '0')}";
    }
}
