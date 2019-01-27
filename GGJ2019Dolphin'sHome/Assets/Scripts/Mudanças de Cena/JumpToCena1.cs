using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToCena1 : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene.LoadFase1();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
