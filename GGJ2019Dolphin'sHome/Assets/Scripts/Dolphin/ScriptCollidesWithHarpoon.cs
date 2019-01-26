using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithHarpoon : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<TagHarpoon>())
        {
            ScriptDolphinStamina dolphin_stamina = ScriptGlobalVariables.player.GetComponentInChildren<ScriptDolphinStamina>();

            ScriptHarpoonDamage harpoon = other.GetComponentInChildren<ScriptHarpoonDamage>();
            dolphin_stamina.actual_stamina_value -= harpoon.harpoon_damage;
        }
    }
}
