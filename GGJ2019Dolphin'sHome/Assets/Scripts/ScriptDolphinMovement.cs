using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinMovement : MonoBehaviour {

    private GameObject root_player;

    public Vector3 scalar_velocity;

    public float z_angle;
    public Vector3 pivot;
    public float rotational_speed;

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

        }



    }

    private void RotateDolphin(float rotation_in_degrees)
    {
        Vector3 rotation_to_be_applied = new Vector3(0, 0, rotation_in_degrees);
        root_player.transform.Rotate(pivot, rotation_in_degrees, Space.World);
    }
}
