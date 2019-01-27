using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithBarrier : MonoBehaviour {

    public GameObject[] sons_do_boto;
    public GameObject communication_image;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TagBarrier>())
        {
            int qual_som = (int)Random.Range(0, 3);

            sons_do_boto[qual_som].GetComponent<AudioSource>().Play();

            Instantiate(communication_image, transform.parent);


            //Spawnar imagem que dura 8 segundos.
        }
    }

}
