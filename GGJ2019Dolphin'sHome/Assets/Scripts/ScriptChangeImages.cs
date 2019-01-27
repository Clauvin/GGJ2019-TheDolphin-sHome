using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//passar pra SupportLibrary
public class ScriptChangeImages : MonoBehaviour {

    public GameObject[] lista_de_imagens;

    public float[] tempo_de_transicoes;
    public float tempo_que_passou;
    public float tempo_para_pular_pra_proxima_cena;
    public SceneManager.Cenas proxima_cena;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTime();


	}

    public void ShowImage(int qual)
    {
        for (int i = 0; i < lista_de_imagens.Length; i++)
        {
            if (i == qual) lista_de_imagens[i].SetActive(true);
            else lista_de_imagens[i].SetActive(false);
        }
    }

    public void UpdateTime()
    {
        tempo_que_passou += Time.deltaTime;
    }


}
