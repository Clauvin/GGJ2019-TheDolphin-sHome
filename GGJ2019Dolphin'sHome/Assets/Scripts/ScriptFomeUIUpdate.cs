using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFomeUIUpdate : MonoBehaviour {

    ScriptDolphinStomach dolphin_stomach;

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        dolphin_stomach = player.GetComponentInChildren<ScriptDolphinStomach>();

    }

    // Update is called once per frame
    void Update()
    {

        int amount_of_hunger = (int)dolphin_stomach.how_much_filled;

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, amount_of_hunger);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, amount_of_hunger);

    }
}
