using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
===============================================================================
The VelocityTracker class contains information used in order to track an object using its velocity and frames.
===============================================================================
*/
public class VelocityTracker : MonoBehaviour
{
    //Position of the tracker
    public Transform tracker;
    //Velocity of the tracked object
    public Vector3 velocity;
    //Position of the tracker during the last frame
    private Vector3 lastFramePos;

    /*
	====================
	Update()
		Update is called once per frame. It is used to find out the tracker's velocity and update its last frame.
	====================
	*/
    void Update()
    {
        velocity = (transform.position - lastFramePos) / Time.deltaTime;
        lastFramePos = transform.position;
    }
}
