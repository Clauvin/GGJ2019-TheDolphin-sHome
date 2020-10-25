using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStaminaUIUpdate : MonoBehaviour {

    ScriptDolphinStamina dolphin_stamina;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        dolphin_stamina = player.GetComponentInChildren<ScriptDolphinStamina>();

    }
	
	// Update is called once per frame
	void Update () {

        int amount_of_stamina = (int)dolphin_stamina.actual_stamina_value;

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, amount_of_stamina);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, amount_of_stamina);

    }
}
