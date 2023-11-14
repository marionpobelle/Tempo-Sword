using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor
{
    Green,
    Red
}

public class Block : MonoBehaviour
{
    public BlockColor color;
    public GameObject brokenBlockLeft;
    public GameObject brokenBlockRight;
    public float brokenBlockForce;
    public float brokenBlockTorque;
    public float brokenBlockDestroyDelay;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordRed"))
        {
            if(color == BlockColor.Red)
            {
                //Increase score
            }
            else
            {
                //Remove life
            }
            Hit();
        }
        else if (other.CompareTag("SwordGreen"))
        {
            if(color == BlockColor.Green)
            {
                //Increase score
            }
            else
            {
                //Remove life
            }
            Hit();
        }
    }


}
