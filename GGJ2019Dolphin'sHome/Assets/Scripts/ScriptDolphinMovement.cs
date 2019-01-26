using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDolphinMovement : MonoBehaviour {

    private GameObject root_player;

    public Vector3 scalar_velocity;

    public float z_angle;
    public Vector3 pivot;
    public float rotational_speed;

    public Vector3 directional_speed;
    public Vector3 true_speed;
    public float maximum_speed;
    public Vector3 force_acting_in_dolphin;

    public float inertial_limit;

    public bool is_in_water = false;

    private void Awake()
    {
        root_player = GameObject.FindGameObjectWithTag("Player");
        z_angle = root_player.transform.eulerAngles.z;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        ControlDolphin();

        UpdateValues();

        InertialForcesWorkingInTheDolphin();

        UpdateValues();
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
            if (vertical_axis < 0) BreakingDolphingSpeed();
            else if (vertical_axis > 0) AccelerateDolphinForward(directional_speed);
        }



    }

    private void RotateDolphin(float rotation_in_degrees)
    {
        float final_rotation_speed = rotation_in_degrees * ScriptGlobalVariables.game_speed;

        Vector3 rotation_to_be_applied = new Vector3(0, 0, rotation_in_degrees);
        root_player.transform.Rotate(pivot, final_rotation_speed, Space.World);

        UpdateValues();

        TransferSpeed();
    }

    private void TransferSpeed()
    {
        float scalar_value = GetOriginalXValue(true_speed);

        MoveDolphinForward(new Vector3(scalar_value, 0.0f, 0.0f));
    }

    private float GetOriginalXValue(Vector3 true_speed)
    {
        float x = true_speed.x;
        float y = true_speed.y;

        float hip = Mathf.Sqrt(Mathf.Pow(x,2) + Mathf.Pow(y, 2));

        return hip;
    }

    private void AccelerateDolphinForward(Vector3 directional_speed)
    {
        Vector3 final_directional_speed = GetFinalDirectionalSpeed(directional_speed);

        Rigidbody rigidbody = root_player.GetComponent<Rigidbody>();

        rigidbody.AddForce(final_directional_speed * ScriptGlobalVariables.game_speed);
    }

    private void BreakingDolphingSpeed()
    {
        float x = GetOriginalXValue(true_speed);

        if (x < inertial_limit)
        {
            StopDolphinImmediately();
        } else
        {
            AccelerateDolphinForward(-directional_speed * 2 * ScriptGlobalVariables.game_speed);
        }
    }

    private void MoveDolphinForward(Vector3 directional_speed)
    {
        Vector3 final_directional_speed = GetFinalDirectionalSpeed(directional_speed);

        Rigidbody rigidbody = root_player.GetComponent<Rigidbody>();

        rigidbody.velocity = final_directional_speed;
    }

    private Vector3 GetFinalDirectionalSpeed(Vector3 directional_speed)
    {
        Rigidbody rigidbody = root_player.GetComponent<Rigidbody>();

        Vector3 final_directional_speed = directional_speed;
        float rad_angle = z_angle * Mathf.Deg2Rad;

        final_directional_speed.x = ScriptGlobalVariables.game_speed * directional_speed.x * Mathf.Cos(rad_angle);
        final_directional_speed.y = ScriptGlobalVariables.game_speed * directional_speed.x * Mathf.Sin(rad_angle);

        return final_directional_speed;
    }

    private void StopDolphinImmediately()
    {
        Rigidbody rigidbody = root_player.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        AccelerateDolphinForward(-directional_speed);
    }

    private void InertialForcesWorkingInTheDolphin()
    {
        LimitDolphinSpeed();

        ApplyWaterFriction();

        UpdateValues();

        ApplyInertialLimitEffect();
    }

    private void LimitDolphinSpeed()
    {
        float dolphin_true_speed = GetOriginalXValue(true_speed);
        Debug.Log("SHOW TRUE SPEED! =" + dolphin_true_speed);

        if (dolphin_true_speed > maximum_speed)
        {
            Debug.Log("HEY!");
            StopDolphinImmediately();

            Vector3 maximum_speed_vector = new Vector3(dolphin_true_speed, 0f, 0f);
            MoveDolphinForward(maximum_speed_vector);
        }
    }

    private void ApplyWaterFriction()
    {
        float dolphin_true_speed = GetOriginalXValue(true_speed);
        float vertical_axis = Input.GetAxis("Vertical");
        float water_friction = ScriptGlobalVariables.water.GetComponent<ScriptWaterAttributes>().water_friction;
        if ((dolphin_true_speed > inertial_limit) && (vertical_axis <= 0)){
            AccelerateDolphinForward(-directional_speed * water_friction *
                ScriptGlobalVariables.game_speed);
        }
    }

    private void ApplyInertialLimitEffect()
    {
        float x = GetOriginalXValue(true_speed);

        if (x < inertial_limit)
        {
            StopDolphinImmediately();
        }
    }

    private void UpdateValues()
    {
        z_angle = root_player.transform.eulerAngles.z;
        true_speed = root_player.GetComponent<Rigidbody>().velocity;
    }
}
