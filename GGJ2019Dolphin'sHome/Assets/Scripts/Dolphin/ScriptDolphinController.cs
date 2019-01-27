using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinController : MonoBehaviour {

    ScriptDolphinMovement dolphin_movement;

    // Use this for initialization
	void Start () {

        dolphin_movement = transform.parent.GetComponentInChildren<ScriptDolphinMovement>();

	}
	
	// Update is called once per frame
	void Update () {
        ChooseAnimation();
    }

    void ChooseAnimation()
    {
        if (dolphin_movement != null)
        {
            if (dolphin_movement.stun_time > 0)
            {
                GetComponent<Animator>().ResetTrigger("MudarParaSituaçãoNormal");
                GetComponent<Animator>().SetTrigger("MudarParaTravado");
            }
            else
            {
                GetComponent<Animator>().ResetTrigger("MudarParaTravado");
                GetComponent<Animator>().SetTrigger("MudarParaSituaçãoNormal");
            }
        }
        else
        {
            GetComponent<Animator>().SetTrigger("MudarParaSituaçãoNormal");
        }

    }
}
