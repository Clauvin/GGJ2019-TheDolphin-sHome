using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStraightFishIA : MonoBehaviour {

    public float counter;
    public float time_to_change_state;

    public ScriptSpinningFishMovement movement;

    private float reverse_180_angle;
    private bool reverse_180 = true;
    private float change_30_angle;
    private bool change_30 = true;

    public enum SpinningStates
    {
        Move,
        Spin180DegreesAndMove,
        Spin30DegreesAndMove
    }

    public SpinningStates estado_do_peixe;

    // Use this for initialization
    void Start()
    {

        movement = GetComponent<ScriptSpinningFishMovement>();
        ChangeState();

    }

    // Update is called once per frame
    void Update()
    {

        Act();
        movement.UpdateValues();

        movement.InertialForcesWorkingInTheSpinningFish();

        movement.UpdateValues();

        CountingTime();
        TimeToChangeState();
    }

    void IAList()
    {
        Act();
        CountingTime();
        TimeToChangeState();
    }

    void ChangeState()
    {
        estado_do_peixe = (SpinningStates)((int)(Random.Range(0, 3)) % 3);
    }

    void Act()
    {
        switch (estado_do_peixe)
        {
            case SpinningStates.Move:
                Move();
                break;
            case SpinningStates.Spin180DegreesAndMove:
                if (reverse_180)
                {
                    reverse_180_angle = (GetComponent<ScriptSpinningFishMovement>().z_angle + 180) % 360;
                    reverse_180 = false;
                }
                Spin180DegreesAndMove();
                break;
            case SpinningStates.Spin30DegreesAndMove:
                if (change_30)
                {
                    change_30_angle = (GetComponent<ScriptSpinningFishMovement>().z_angle + 30) % 360;
                    change_30 = false;
                }
                Spin30DegreesAndMove();
                break;
            default:
                Move();
                break;
        }
    }

    void Move()
    {
        movement.AccelerateFishForward(movement.directional_speed);
    }

    void Spin180DegreesAndMove()
    {
        if (!Mathf.Approximately(movement.z_angle, reverse_180_angle))
        {
            movement.RotateDolphin(-movement.rotational_speed);
        }
        else
        {
            movement.AccelerateFishForward(movement.directional_speed);
        }
    }

    void Spin30DegreesAndMove()
    {
        if (!Mathf.Approximately(movement.z_angle, change_30_angle))
        {
            movement.RotateDolphin(movement.rotational_speed);
        }
        else
        {
            movement.AccelerateFishForward(movement.directional_speed);
        }
    }

    void CountingTime()
    {
        counter += Time.deltaTime;
    }

    void TimeToChangeState()
    {
        if (counter > time_to_change_state)
        {
            ChangeState();
            counter = 0;
            reverse_180 = true;
            change_30 = true;
        }
    }
}
