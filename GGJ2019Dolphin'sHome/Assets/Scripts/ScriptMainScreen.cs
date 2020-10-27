using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMainScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        RectTransform rect_transform = GetComponent<RectTransform>();
        ScriptFixedRatio fixed_ratio = camera.GetComponent<ScriptFixedRatio>();
        float x = Screen.width; float y = Screen.height;
        float x_adjustment = x / (rect_transform.rect.width);
        float y_adjustment = y / (rect_transform.rect.height);

        float scaleheight = fixed_ratio.getScaleHeight();
        if (scaleheight > 1.0f) x_adjustment *= scaleheight;
        if (scaleheight < 1.0f) y_adjustment *= scaleheight;

        rect_transform.localScale = new Vector3(rect_transform.localScale.x * x_adjustment,
            rect_transform.localScale.y * y_adjustment, rect_transform.localScale.z);

	}
	
	// Update is called once per frame
	void Update () {

    }

    
}
