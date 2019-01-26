using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBreatherCollidesWithAir : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TagAir>())
        {
            ScriptDolphinStamina dolphin_stamina = ScriptGlobalVariables.player.GetComponentInChildren<ScriptDolphinStamina>();

            dolphin_stamina.FullStaminaRecover();
        }
        else if (other.GetComponent<TagDirtyAir>())
        {
            ScriptDolphinStamina dolphin_stamina = ScriptGlobalVariables.player.GetComponentInChildren<ScriptDolphinStamina>();

            dolphin_stamina.PartialStaminaRecover();
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
