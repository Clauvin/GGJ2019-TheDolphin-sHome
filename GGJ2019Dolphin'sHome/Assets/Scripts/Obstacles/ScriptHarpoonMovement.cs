using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHarpoonMovement : MonoBehaviour {

    public float z_angle;
    public Vector3 pivot;

    public Vector3 directional_speed;
    public Vector3 true_speed;
    public float maximum_speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        MoveHarpoonForward(directional_speed);

        UpdateValues();

    }

    public void MoveHarpoonForward(Vector3 directional_speed)
    {
        Vector3 final_directional_speed = GetFinalDirectionalSpeed(directional_speed);

        Rigidbody rigidbody = transform.parent.GetComponent<Rigidbody>();

        rigidbody.velocity = final_directional_speed;
    }

    public Vector3 GetFinalDirectionalSpeed(Vector3 directional_speed)
    {
        Rigidbody rigidbody = transform.parent.GetComponent<Rigidbody>();

        Vector3 final_directional_speed = directional_speed;
        float rad_angle = z_angle * Mathf.Deg2Rad;

        final_directional_speed.x = ScriptGlobalVariables.game_speed * directional_speed.x * Mathf.Cos(rad_angle);
        final_directional_speed.y = ScriptGlobalVariables.game_speed * directional_speed.x * Mathf.Sin(rad_angle);

        return final_directional_speed;
    }

    public void Rotate(float rotation_in_degrees)
    {
        float final_rotation_speed = rotation_in_degrees * ScriptGlobalVariables.game_speed;

        Vector3 rotation_to_be_applied = new Vector3(0, 0, rotation_in_degrees);
        transform.parent.Rotate(pivot, final_rotation_speed, Space.World);
    }

    public void UpdateValues()
    {
        z_angle = transform.parent.transform.eulerAngles.z;
        true_speed = transform.parent.GetComponent<Rigidbody>().velocity;
    }
}
