using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Main:MonoBehaviour
{
    private MotionUI ui;
    private SteeringForSeek steer;
    private void Awake()
    {
        GameObject go = GameObject.Find("knigthprefab");
        steer = go.AddComponent<SteeringForSeek>();
        ui = go.AddComponent<MotionUI>();
        ui.motion = go.AddComponent<AILocomotion>();
        steer.target = GameObject.Find("target");
    }
}
