using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithPlastic : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<TagPlastic>()) {

            ScriptDolphinStamina dolphin_stamina = ScriptGlobalVariables.player.GetComponentInChildren<ScriptDolphinStamina>();

            dolphin_stamina.actual_stamina_value -= other.GetComponentInChildren<ScriptPlasticDamage>().plastic_damage;
            dolphin_stamina.max_stamina_value -= other.GetComponentInChildren<ScriptPlasticDamage>().plastic_damage;

            Destroy(other.gameObject);
        }


    }
}
