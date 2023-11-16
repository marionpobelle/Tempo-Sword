using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines the color of the block
public enum BlockColor
{
    Green,
    Red
}

/*
===============================================================================
The Block class regroups everything that characterize a block.
===============================================================================
*/
public class Block : MonoBehaviour
{
    //Color of the block
    public BlockColor color;
    //Child game object that represents the left piece of a broken block
    public GameObject brokenBlockLeft;
    //Child game object that represents the right piece of a broken block
    public GameObject brokenBlockRight;
    //Force applied to broken pieces of a block to simulate the rupture impulsion
    public float brokenBlockForce;
    //Rotation applied to broken pieces of a block to simulate the rupture gravity
    public float brokenBlockTorque;
    //Delay before the broken pieces of a block get deleted
    public float brokenBlockDestroyDelay;

    /*
	====================
	Hit()
        A chain of actions that take place when a block gets hit by a sword.
	====================
	*/
    public void Hit()
    {
        //Enable the broken pieces
        brokenBlockLeft.SetActive(true);
        brokenBlockRight.SetActive(true);

        //Remove them as children
        brokenBlockLeft.transform.parent = null;
        brokenBlockRight.transform.parent = null;

        //Add force to them
        Rigidbody leftRig = brokenBlockLeft.GetComponent<Rigidbody>();
        Rigidbody rightRig = brokenBlockRight.GetComponent<Rigidbody>();
        leftRig.AddForce(-transform.right * brokenBlockForce, ForceMode.Impulse);
        rightRig.AddForce(transform.right * brokenBlockForce, ForceMode.Impulse);

        //Add torque to them
        leftRig.AddTorque(-transform.forward * brokenBlockTorque, ForceMode.Impulse);
        rightRig.AddTorque(transform.forward * brokenBlockTorque, ForceMode.Impulse);

        //Destroy the broken pieces after a few seconds
        Destroy(brokenBlockLeft, brokenBlockDestroyDelay);
        Destroy(brokenBlockRight, brokenBlockDestroyDelay);

        //Destroy the main block
        Destroy(gameObject);
    }

    /*
    ====================
    OnTriggerEnter()
        When a GameObject collides with another GameObject, Unity calls OnTriggerEnter. It describes all actions that answer this collision.
        @param other : Collider of the object that made contact with this object.
    ====================
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordRed"))
        {
            //If we hit the right block with the right sword and the velocity is valid regarding the threshold
            if (color == BlockColor.Red && GameManager.instance.rightSwordTracker.velocity.magnitude >= GameManager.instance.swordHitVelocityThreshold)
            {
                GameManager.instance.AddScore();
                //FindObjectOfType<AudioManager>().Play("HitBlock");
            }
            else
            {
                GameManager.instance.HitWrongBlock();
                //FindObjectOfType<AudioManager>().Play("WrongBlock");
            }
            Hit();
        }
        else if (other.CompareTag("SwordGreen"))
        {
            //If we hit the right block with the right sword and the velocity is valid regarding the threshold
            if (color == BlockColor.Green && GameManager.instance.leftSwordTracker.velocity.magnitude >= GameManager.instance.swordHitVelocityThreshold)
            {
                GameManager.instance.AddScore();
                //FindObjectOfType<AudioManager>().Play("HitBlock");
            }
            else
            {
                GameManager.instance.HitWrongBlock();
                //FindObjectOfType<AudioManager>().Play("WrongBlock");
            }
            Hit();
        }
    }


}
