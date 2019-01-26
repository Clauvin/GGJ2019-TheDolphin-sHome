using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFluidAttributes : MonoBehaviour {

    public float friction;

    private Color initial_color;
    public Color final_color;
    public bool there_will_be_a_color_change;
    public float change_counter;
    public float time_for_change;

    void Awake()
    {
        initial_color = GetComponent<MeshRenderer>().material.GetColor("_Color");
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (there_will_be_a_color_change)
        {
            ChangeColorGradually(final_color);
            change_counter += Time.deltaTime;
            if (change_counter >= time_for_change) there_will_be_a_color_change = false;
        }
	}

    protected void ChangeColor(Color color)
    {
        Material material = GetComponent<MeshRenderer>().material;
        material.SetColor("_Color", color);
    }

    protected void ChangeColorGradually(Color final_color)
    {
        Color cor_original = initial_color;

        Color cor_final = final_color;

        float coeficient_original = (time_for_change - change_counter) / time_for_change;
        if (coeficient_original < 0) coeficient_original = 0;

        float coeficient_final = change_counter / time_for_change;
        if (coeficient_final > 1) coeficient_original = 1;

        Color cor_de_transicao = coeficient_original * cor_original + coeficient_final * cor_final;
        Debug.Log("Cor_original " + cor_original);
        Debug.Log("Cor final " + cor_final);
        Debug.Log("Cor de transição " + cor_de_transicao);

        GetComponent<MeshRenderer>().material.SetColor("_Color", cor_de_transicao);
    }
}
