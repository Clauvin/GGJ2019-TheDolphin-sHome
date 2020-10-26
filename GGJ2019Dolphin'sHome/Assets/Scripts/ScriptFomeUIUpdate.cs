using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFomeUIUpdate : MonoBehaviour {

    ScriptDolphinStomach dolphin_stomach;

    public bool gambiarra = true;

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        dolphin_stomach = player.GetComponentInChildren<ScriptDolphinStomach>();

    }

    // Update is called once per frame
    void Update()
    {

        int amount_of_hunger = (int)dolphin_stomach.how_much_filled;

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, amount_of_hunger);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, amount_of_hunger);

        if (gambiarra)
        {
            ChangeDistanciaPosition();
            gambiarra = false;
        }

    }

    private void ChangeDistanciaPosition()
    {
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ScriptFixedRatio fixed_ratio = camera.GetComponent<ScriptFixedRatio>();
        float x = Screen.width; float y = Screen.height;
        float percentage_of_x = camera.rect.x; float percentage_of_y = camera.rect.y;

        float extra_position_x = x * percentage_of_x; float extra_position_y = y * percentage_of_y;
        extra_position_y *= -1;

        Vector3 new_position = GetComponent<RectTransform>().position;
        new_position.x += extra_position_x;
        new_position.y += extra_position_y;
        GetComponent<RectTransform>().position = new_position;
    }
}
