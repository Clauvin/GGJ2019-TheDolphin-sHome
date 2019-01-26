using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptWaterAttributes : ScriptFluidAttributes {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (there_will_be_a_color_change)
        {
            ChangeColorGradually(final_color);
            change_counter += Time.deltaTime;
            if (change_counter >= time_for_change) there_will_be_a_color_change = false;
        }
    }
}
