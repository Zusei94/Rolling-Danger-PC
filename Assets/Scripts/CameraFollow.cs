using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTarget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.3f;

    //init
    private Vector3 cameraVelocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;
        //smooth damp will gradually changes a vector towards a desired goal overtime
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

        // make the camera's transform look at the player transform
        transform.LookAt(cameraTarget);
    }
}
