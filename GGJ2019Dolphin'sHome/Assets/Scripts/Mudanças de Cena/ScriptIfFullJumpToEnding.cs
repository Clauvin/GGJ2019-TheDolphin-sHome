using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptIfFullJumpToEnding : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (GetComponent<ScriptDolphinStomach>().max_stomach_limit ==
                GetComponent<ScriptDolphinStomach>().how_much_filled)
        {
            SceneManager.LoadCréditos();
        }
    }
}
