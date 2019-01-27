using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGlobalStarter : MonoBehaviour {

    void Awake()
    {
        ScriptGlobalVariables.player = GameObject.FindGameObjectWithTag("Player");
        ScriptGlobalVariables.water = GameObject.FindGameObjectWithTag("Water");
    }

    // Use this for initialization
    void Start () {
        ScriptGlobalVariables.player = GameObject.FindGameObjectWithTag("Player");
        ScriptGlobalVariables.water = GameObject.FindGameObjectWithTag("Water");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
