using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptIfFullJumpToConversa1 : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (GetComponent<ScriptDolphinStamina>().actual_stamina_value ==
                GetComponent<ScriptDolphinStamina>().max_stamina_value)
        {
            SceneManager.LoadScene.LoadConversaSobreLar1();
        }
    }
}
