using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionUI : MonoBehaviour {

    public AILocomotion motion;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        for(int i = 1;i<19;i++)
        {
            if (GUILayout.Button("Attack"+i))
            {
                motion.Attack(i);
            }
        }
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        if (GUILayout.Button("Walk"))
        {
            motion.Walk();
        }
        if (GUILayout.Button("Run"))
        {
            motion.Run();
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
