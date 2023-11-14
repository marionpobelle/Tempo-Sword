using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    public Transform tracker;
    public Vector3 velocity;

    private Vector3 lastFramePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - lastFramePos) / Time.deltaTime;
        lastFramePos = transform.position;
    }
}
