using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptLogoManipulation : MonoBehaviour
{
    public float time_for_alpha_to_become_255;
    public float time_for_alpha_to_be_255;
    public float time_for_alpha_to_become_0;

    private float starting_time;
    private float min_time_where_alpha_is_255;
    private float max_time_where_alpha_is_255;
    private float min_time_where_alpha_becomes_0;
    private float max_time_where_alpha_becomes_0;
    private float min_time_where_alpha_is_0;
    private Image logo;


    // Start is called before the first frame update
    void Start()
    {
        starting_time = Time.time;
        min_time_where_alpha_is_255 = starting_time + time_for_alpha_to_become_255;
        max_time_where_alpha_is_255 = min_time_where_alpha_is_255 + time_for_alpha_to_be_255;
        min_time_where_alpha_becomes_0 = max_time_where_alpha_is_255;
        max_time_where_alpha_becomes_0 = min_time_where_alpha_becomes_0 + time_for_alpha_to_become_0;

        logo = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LogoColorManipulation();
    }

    private void LogoColorManipulation()
    {
        if (Time.time < min_time_where_alpha_is_255)
        {
            Color color = logo.color;
            color.a = 1 - (min_time_where_alpha_is_255 - Time.time) / time_for_alpha_to_become_255;
            logo.color = color;
        }
        else if (Time.time < max_time_where_alpha_is_255)
        {

            Color color = logo.color;
            color.a = 1;
            logo.color = color;

        }
        else if (Time.time < max_time_where_alpha_becomes_0)
        {
            Color color = logo.color;
            color.a = 1 - (Time.time - min_time_where_alpha_becomes_0) / (time_for_alpha_to_become_0);
            logo.color = color;
        }
        else
        {
            Color color = logo.color;
            color.a = 0;
            logo.color = color;
        }

    }
}