using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithWater : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<TagWater>())
        {
            ScriptGlobalVariables.player.GetComponentInChildren<ScriptDolphinMovement>().is_in_water = true;
        }
        else ScriptGlobalVariables.player.GetComponentInChildren<ScriptDolphinMovement>().is_in_water = false;
    }
}
