using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
===============================================================================
The MissHitDetector class characterize the wall used as a limit for the blocks to be hit. If the blocks hit this object, they are considered missed.
===============================================================================
*/
public class MissHitDetector : MonoBehaviour
{
    /*
    ====================
    OnTriggerEnter()
        When a GameObject collides with another GameObject, Unity calls OnTriggerEnter. It describes all actions that answer this collision.
        @param other : Collider of the object that made contact with this object.
    ====================
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            other.GetComponent<Block>().Hit();
            GameManager.instance.MissBlock();
        }
    }
}
