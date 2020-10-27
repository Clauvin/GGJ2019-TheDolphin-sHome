using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMainScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        RectTransform rect_transform = GetComponent<RectTransform>();
        float x = Screen.width; float y = Screen.height;
        float x_adjustment = Screen.width / (rect_transform.rect.width);
        float y_adjustment = Screen.height / (rect_transform.rect.height);

        rect_transform.localScale = new Vector3(rect_transform.localScale.x * x_adjustment,
            rect_transform.localScale.y * y_adjustment, rect_transform.localScale.z);

	}
	
	// Update is called once per frame
	void Update () {

    }

    
}
