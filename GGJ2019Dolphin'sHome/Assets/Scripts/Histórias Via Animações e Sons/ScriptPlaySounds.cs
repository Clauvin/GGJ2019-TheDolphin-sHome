using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlaySounds : MonoBehaviour {

    public AudioSource[] lista_de_sons_a_tocar;
    public bool[] tocar_uma_vez_ou_varias;
    private bool[] tocou_uma_vez;
    public float[] quando_comecar_a_tocar_som;
    public float[] quando_parar_de_tocar_som;
    
    

    public float tempo;

	// Use this for initialization
	void Start () {
        tocou_uma_vez = new bool[tocar_uma_vez_ou_varias.Length];
		for (int i = 0; i < tocou_uma_vez.Length; i++)
        {
            tocou_uma_vez[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < lista_de_sons_a_tocar.GetLength(0); i++)
        {
            PlayIfItsTime(i);
        }
        UpdateTime();
    }

    void UpdateTime()
    {
        tempo += Time.deltaTime;
    }

    void PlayIfItsTime(int i)
    {
        if ((tempo >= quando_comecar_a_tocar_som[i]) && (tocar_uma_vez_ou_varias[i])){

            if (!tocou_uma_vez[i])
            {
                lista_de_sons_a_tocar[i].enabled = true;
                lista_de_sons_a_tocar[i].Play();
                tocou_uma_vez[i] = true;
            }
        }
        else if((tempo >= quando_comecar_a_tocar_som[i]) && (tempo <= quando_parar_de_tocar_som[i]) && 
                    !tocar_uma_vez_ou_varias[i])
        {
            Debug.Log(i + " - " + lista_de_sons_a_tocar[i].isPlaying);
            if (!lista_de_sons_a_tocar[i].isPlaying)
            {
                lista_de_sons_a_tocar[i].enabled = true;
                lista_de_sons_a_tocar[i].Play();
                Debug.Log(lista_de_sons_a_tocar[i].isPlaying);
            }
        }
        else if (!tocar_uma_vez_ou_varias[i])
        {
            if (lista_de_sons_a_tocar[i].isPlaying)
            {
                Debug.Log(tempo);
                lista_de_sons_a_tocar[i].Stop();
                lista_de_sons_a_tocar[i].enabled = false;
            }
        }
    }
}
