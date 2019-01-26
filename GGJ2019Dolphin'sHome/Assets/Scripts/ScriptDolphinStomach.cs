using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinStomach : MonoBehaviour {

    public float min_stomach_limit;
    public float how_much_filled;
    public float max_stomach_limit;

    bool CanEatStuff()
    {
        if (how_much_filled == max_stomach_limit)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void AteStuff(float nutritional_value)
    {
        how_much_filled += nutritional_value;
        if (how_much_filled >= max_stomach_limit) how_much_filled = max_stomach_limit;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
