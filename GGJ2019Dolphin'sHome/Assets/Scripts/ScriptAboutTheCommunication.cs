using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAboutTheCommunication : MonoBehaviour {

    public float counter;
    public float time_for_destruction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CounterTime();
        IfIsTimeDestroy();
    }

    void CounterTime()
    {
        counter += Time.deltaTime;
    }

    void IfIsTimeDestroy()
    {
        if (counter > time_for_destruction)
        {
            Destroy(this.gameObject);
        }
    }
}
