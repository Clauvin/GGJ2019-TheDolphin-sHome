using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawningRedes : MonoBehaviour {

    public GameObject the_parent;
    public GameObject rede;

    public float minimum_x;
    public float maximum_x;

    public float counter;
    public float time_to_spawn_a_new_rede;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCounting();
        if (TimeToSpawnANewRede())
        {
            SpawnNewRede();
        }

    }

    public float GenerateSpawnCoordinate()
    {
        return Random.Range(minimum_x, maximum_x);
    }

    public void UpdateCounting()
    {
        counter += Time.deltaTime;
    }

    public bool TimeToSpawnANewRede()
    {
        if (counter >= time_to_spawn_a_new_rede)
        {
            counter = 0.0f;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpawnNewRede()
    {
        GameObject new_harpoon;

        new_harpoon = Instantiate(rede, the_parent.transform);

        float pos = GenerateSpawnCoordinate();

        Vector3 new_position = transform.position;
        new_position.x += pos;

        new_harpoon.transform.position = new_position;

    }
}
