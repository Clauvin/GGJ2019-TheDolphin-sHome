using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawningHarpoon : MonoBehaviour {

    public GameObject the_parent;
    public GameObject harpoon;

    public float minimum_angle;
    public float maximum_angle;

    public float counter;
    public float time_to_spawn_a_new_harpoon;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCounting();
        if (TimeToSpawnANewHarpoon())
        {
            SpawnNewHarpoon();
        }

    }

    public float GenerateAngle()
    {
        return Random.Range(minimum_angle, maximum_angle);
    }

    public void UpdateCounting()
    {
        counter += Time.deltaTime;
    }

    public bool TimeToSpawnANewHarpoon()
    {
        if (counter >= time_to_spawn_a_new_harpoon)
        {
            counter = 0.0f;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpawnNewHarpoon()
    {
        GameObject new_harpoon;

        new_harpoon = Instantiate(harpoon, the_parent.transform);

        float angle = GenerateAngle();
        Debug.Log(angle);

        Vector3 new_position = transform.position;

        new_harpoon.transform.position = new_position;

        new_harpoon.GetComponentInChildren<ScriptHarpoonMovement>().Rotate(angle);
    }
}
