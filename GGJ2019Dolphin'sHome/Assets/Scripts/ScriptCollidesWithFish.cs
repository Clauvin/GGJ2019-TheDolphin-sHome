using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollidesWithFish : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<TagFish>())
        {

        }
    }

}
