using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.Video;

public class ScriptWhenVideoEndsGoToTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<VideoPlayer>().isPlaying)
        {
            SceneManager.LoadTutorial();
        }
	}
}
