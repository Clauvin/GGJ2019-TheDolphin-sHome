using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpinningFishMovement : MonoBehaviour {

    public float z_angle;
    public Vector3 pivot;
    public float rotational_speed;

    public Vector3 directional_speed;
    public Vector3 true_speed;
    public float maximum_speed;
    public Vector3 force_acting_in_dolphin;

    public float inertial_limit;

    public bool is_in_water = false;

    // Use this for initialization
    void Start () {
        z_angle = transform.parent.transform.eulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void InertialForcesWorkingInTheSpinningFish()
    {
        LimitFishSpeed();

        ApplyWaterFriction();

        UpdateValues();

        //ApplyInertialLimitEffect();
    }

    public void LimitFishSpeed()
    {
        float dolphin_true_speed = GetOriginalXValue(true_speed);

        if (dolphin_true_speed > maximum_speed)
        {
            StopFishImmediately();

            Vector3 maximum_speed_vector = new Vector3(dolphin_true_speed, 0f, 0f);
            MoveFishForward(maximum_speed_vector);
        }
    }

    public void MoveFishForward(Vector3 directional_speed)
    {
        Vector3 final_directional_speed = GetFinalDirectionalSpeed(directional_speed);

        Rigidbody rigidbody = transform.parent.GetComponent<Rigidbody>();

        rigidbody.velocity = final_directional_speed;
    }

    public void StopFishImmediately()
    {
        Rigidbody rigidbody = transform.parent.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        AccelerateFishForward(-directional_speed);
    }

    public void AccelerateFishForward(Vector3 directional_speed)
    {
        Vector3 final_directional_speed = GetFinalDirectionalSpeed(directional_speed);

        Rigidbody rigidbody = transform.parent.GetComponent<Rigidbody>();

        rigidbody.AddForce(final_directional_speed * ScriptGlobalVariables.game_speed);
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

    public float GetOriginalXValue(Vector3 true_speed)
    {
        float x = true_speed.x;
        float y = true_speed.y;

        float hip = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));

        return hip;
    }

    public void ApplyWaterFriction()
    {
        float dolphin_true_speed = GetOriginalXValue(true_speed);

        GameObject w = ScriptGlobalVariables.water;
        float friction = w.GetComponent<ScriptWaterAttributes>().friction;

        if (dolphin_true_speed > inertial_limit)
        {
            AccelerateFishForward(-directional_speed * friction *
                ScriptGlobalVariables.game_speed);
        }
    }

    public void ApplyInertialLimitEffect()
    {
        float x = GetOriginalXValue(true_speed);
        float vertical_axis = Input.GetAxis("Vertical");

        if (x < inertial_limit)
        {
            StopDolphinCalmly();
        }
    }

    public void StopDolphinCalmly()
    {
        Rigidbody rigidbody = transform.parent.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public void RotateDolphin(float rotation_in_degrees)
    {
        float final_rotation_speed = rotation_in_degrees * ScriptGlobalVariables.game_speed;

        Vector3 rotation_to_be_applied = new Vector3(0, 0, rotation_in_degrees);
        transform.parent.Rotate(pivot, final_rotation_speed, Space.World);

        UpdateValues();

        TransferSpeed();
    }

    public void TransferSpeed()
    {
        float scalar_value = GetOriginalXValue(true_speed);

        MoveFishForward(new Vector3(scalar_value, 0.0f, 0.0f));
    }

    public void UpdateValues()
    {
        z_angle = transform.parent.transform.eulerAngles.z;
        true_speed = transform.parent.GetComponent<Rigidbody>().velocity;
    }
}
