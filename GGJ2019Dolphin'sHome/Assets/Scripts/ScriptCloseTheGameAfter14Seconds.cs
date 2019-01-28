using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCloseTheGameAfter14Seconds : MonoBehaviour {

    public float counter;
    public float time_to_end_the_game;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AddToCounter();
        TimeToCloseTheGame();

    }
    
    void AddToCounter()
    {
        counter += Time.deltaTime;
    }

    void TimeToCloseTheGame()
    {
        if (counter >= time_to_end_the_game)
        {
            SceneManager.LoadScene.CloseGame();
        }
    }
}
