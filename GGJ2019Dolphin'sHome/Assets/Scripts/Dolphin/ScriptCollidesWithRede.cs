using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithRede : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<TagRede>())
        {
            ScriptDolphinMovement dolphin_movement = ScriptGlobalVariables.player.
                GetComponentInChildren<ScriptDolphinMovement>();

            dolphin_movement.PushDolphin(new Vector3(0, -10, 0));
            dolphin_movement.stun_time += other.GetComponentInChildren<ScriptRedeStun>().stun_value;

            Destroy(other.gameObject);
        }


    }
}
