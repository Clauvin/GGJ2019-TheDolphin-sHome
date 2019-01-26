using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithFish : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponentInChildren<TagFish>()) && (ScriptGlobalVariables.player.
                GetComponentInChildren<ScriptDolphinStomach>().CanEatStuff()))
        {
            ScriptDolphinStomach dolphin_stomach = ScriptGlobalVariables.player.
                GetComponentInChildren<ScriptDolphinStomach>();

            GameObject root_fish = other.transform.parent.gameObject;

            ScriptFishNutritionalValue nutritional_value = root_fish.GetComponentInChildren<ScriptFishNutritionalValue>();

            dolphin_stomach.AteStuff(nutritional_value.fish_nutritional_value);

            Destroy(root_fish);
        }
    }

}
