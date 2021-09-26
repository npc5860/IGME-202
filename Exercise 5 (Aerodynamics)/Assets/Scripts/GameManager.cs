using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject arrow1;  //fill in by Inspector
    private Arrow1 arrow1_script;
     
    // Start is called before the first frame update
    void Start()
    {
        arrow1_script = arrow1.GetComponent<Arrow1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrow1_script.LiftOff();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrow1_script.CeaseThrust();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            arrow1_script.Halt();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrow1_script.AdjustThrustAngle(1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrow1_script.AdjustThrustAngle(-1);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(5, 80, 100, 30), "speed = " + arrow1_script.GetSpeed());
        GUI.Box(new Rect(5, 110, 100, 30), "time = " + arrow1_script.GetTime());
        GUI.Box(new Rect(5, 140, 100, 30), "theta = " + arrow1_script.GetTheta());
        GUI.Box(new Rect(5, 170, 100, 30), "lambda = " + arrow1_script.GetLambda());
        GUI.Box(new Rect(5, 200, 100, 30), "dist = " + arrow1_script.GetDistance());
    }
}
