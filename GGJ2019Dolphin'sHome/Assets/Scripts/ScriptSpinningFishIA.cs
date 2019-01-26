using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpinningFishIA : MonoBehaviour {

    public float counter;
    public float time_to_change_state;

    public ScriptSpinningFishMovement movement;

    public enum SpinningStates
    {
        Straight,
        Clockwise,
        Anticlockwise
    }

    public SpinningStates estado_do_peixe;

	// Use this for initialization
	void Start () {

        ChangeState();
        movement = GetComponent<ScriptSpinningFishMovement>();

    }
	
	// Update is called once per frame
	void Update () {

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
            case SpinningStates.Straight:
                ActStraight();
                break;
            case SpinningStates.Clockwise:
                ActClockwise();
                break;
            case SpinningStates.Anticlockwise:
                ActAntiClockwise();
                break;
            default:
                ActStraight();
                break;
        }            
    }

    void ActStraight()
    {
        movement.AccelerateFishForward(movement.directional_speed);
    }

    void ActClockwise()
    {
        movement.AccelerateFishForward(movement.directional_speed);
        movement.RotateDolphin(movement.rotational_speed);
    }

    void ActAntiClockwise()
    {
        movement.AccelerateFishForward(movement.directional_speed);
        movement.RotateDolphin(-movement.rotational_speed);
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
        }
    }
}

