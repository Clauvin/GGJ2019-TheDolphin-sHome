using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithBarrier : MonoBehaviour {

    public GameObject[] sons_do_boto;
    GameObject communication_image;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TagBarrier>())
        {
            int qual_som = (int)Random.Range(0, 3);

            sons_do_boto[qual_som].GetComponent<AudioSource>().Play();

            communication_image = other.gameObject.GetComponent<ScriptStoreImage>().communication_image;

            GameObject imagem = Instantiate(communication_image);

            Vector3 posicao = other.gameObject.transform.position;

            posicao.y += 8;

            imagem.transform.position = posicao;
        }
    }

}
