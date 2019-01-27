using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptIfTimePassedGoToStage2 : MonoBehaviour {

    public float counter;
    public float time_to_jump;
	
	// Update is called once per frame
	void Update () {
        CounterUpdate();
        TimeToJump();
    }

    void CounterUpdate()
    {
        counter += Time.deltaTime;
    }

    void TimeToJump()
    {
        if (counter >= time_to_jump)
        {
            SceneManager.LoadScene.LoadFase2();
        }
    }
}
