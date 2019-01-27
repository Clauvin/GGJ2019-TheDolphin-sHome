using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinStamina : MonoBehaviour {

    public float min_stamina_value;
    public float actual_stamina_value;
    public float max_stamina_value;

    public float stamina_decay;
    public float partial_stamina_recovery;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StaminaFall();
        InCaseOfNoStamina();
    }

    public void StaminaFall()
    {
        actual_stamina_value -= stamina_decay * ScriptGlobalVariables.game_speed;
        if (actual_stamina_value <= min_stamina_value) actual_stamina_value = min_stamina_value;
    }

    public void PartialStaminaRecover()
    {
        actual_stamina_value += partial_stamina_recovery;
        if (actual_stamina_value >= max_stamina_value) actual_stamina_value = max_stamina_value;
    }

    public void FullStaminaRecover()
    {
        actual_stamina_value = max_stamina_value;
    }

    public void InCaseOfNoStamina()
    {
        if (actual_stamina_value <= 0.0f)
        {
            SceneManager.LoadScene.ResetScene();
        }
    }


}
