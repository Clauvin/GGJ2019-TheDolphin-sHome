﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinMovement : MonoBehaviour {

    private GameObject root_player;

    public Vector3 scalar_velocity;

    public float z_angle;
    public Vector3 pivot;
    public float rotational_speed;

    public Vector3 directional_speed;
    public Vector3 force_acting_in_dolphin;
    

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
        ControlDolphin();

        InertialForcesWorkingInTheDolphin();

        
    }

    private void ControlDolphin()
    {

        float horizontal_axis = Input.GetAxis("Horizontal");
        float vertical_axis = Input.GetAxis("Vertical");

        if ((horizontal_axis < 0) || (horizontal_axis > 0)) {
            if (horizontal_axis < 0) RotateDolphin(rotational_speed);
            else if (horizontal_axis > 0) RotateDolphin(-rotational_speed);

        }

        if ((vertical_axis < 0) || (vertical_axis > 0))
        {
            if (vertical_axis < 0) ;
            else if (vertical_axis > 0) MoveDolphinForward(directional_speed);


        }



    }

    private void RotateDolphin(float rotation_in_degrees)
    {
        float final_rotation_speed = rotation_in_degrees * ScriptGlobalVariables.game_speed;

        Vector3 rotation_to_be_applied = new Vector3(0, 0, rotation_in_degrees);
        root_player.transform.Rotate(pivot, final_rotation_speed, Space.World);
    }

    private void MoveDolphinForward(Vector3 directional_speed)
    {
        Rigidbody rigidbody = root_player.GetComponent<Rigidbody>();

        Vector3 final_directional_speed = directional_speed;
        float rad_angle = Mathf.Deg2Rad * z_angle;

        Debug.Log("1 - " + Mathf.Cos(rad_angle));
        Debug.Log("2 - " + Mathf.Sin(rad_angle));

        final_directional_speed.x = directional_speed.x * Mathf.Cos(rad_angle);
        final_directional_speed.y = directional_speed.y * Mathf.Sin(rad_angle);

        rigidbody.AddForce(final_directional_speed * ScriptGlobalVariables.game_speed);
    }

    private void InertialForcesWorkingInTheDolphin()
    {

    }
}
