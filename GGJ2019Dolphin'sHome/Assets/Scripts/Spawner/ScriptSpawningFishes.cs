using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawningFishes : MonoBehaviour {

    public GameObject middleground;
    public GameObject original_spinning_fish;
    public int number_of_spinning_fishes;
    public GameObject original_straight_fish;
    public int number_of_straight_fishes;

    public float minimum_x;
    public float maximum_x;
    public float minimum_y;
    public float maximum_y;

    void SPAWNTHEFISHES()
    {
        float x, y;
        for (int i = 0; i < number_of_spinning_fishes; i++)
        {
            x = Random.Range(minimum_x, maximum_x);
            y = Random.Range(minimum_y, maximum_y);
            GameObject spinning_fish = Instantiate(original_spinning_fish, middleground.transform);
            Vector3 vector = spinning_fish.transform.position;
            vector.x = x;
            vector.y = y;
            spinning_fish.transform.position = vector;
        }

        for (int i = 0; i < number_of_straight_fishes; i++)
        {
            x = Random.Range(minimum_x, maximum_x);
            y = Random.Range(minimum_y, maximum_y);
            GameObject straight_fish = Instantiate(original_straight_fish, middleground.transform);
            Vector3 vector = straight_fish.transform.position;
            vector.x = x;
            vector.y = y;
            straight_fish.transform.position = vector;
        }
    }

	// Use this for initialization
	void Start () {
        SPAWNTHEFISHES();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
