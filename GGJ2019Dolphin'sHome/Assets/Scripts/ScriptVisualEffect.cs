using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVisualEffect : MonoBehaviour {

    public float minimum_effect;
    public float maximum_effect;

    public float counter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeUpdate();
        SphereUpdate();
    }

    void TimeUpdate()
    {
        counter += Time.deltaTime;
    }

    void SphereUpdate()
    {
        float radius = minimum_effect + counter * 6 % (maximum_effect - minimum_effect);
        Vector3 new_size = new Vector3(radius, radius, 10);

        transform.localScale = new_size;
    }
}
