using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinMovement : MonoBehaviour {

    private GameObject root_player;
    public Vector3 scalar_velocity;
    public float z_angle;

    private void Awake()
    {
        root_player = GameObject.FindGameObjectWithTag("Player");
        z_angle = root_player.transform.rotation.z;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void ControlDolphin()
    {

    }

    private void RotateDolphin(float rotation_in_degrees)
    {

    }
}
