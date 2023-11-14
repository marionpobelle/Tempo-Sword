using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissHitDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // did a block hit the detector?
        if (other.CompareTag("Block"))
        {
            other.GetComponent<Block>().Hit();
            GameManager.instance.MissBlock();
        }
    }
}
