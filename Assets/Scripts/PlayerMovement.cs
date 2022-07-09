using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float horInput, verInput;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 7;
    private bool isJumpButtonPressed;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpButtonPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 playMovement = new Vector3(horInput, 0, verInput);
        playMovement *= speed;
        rb.AddForce(playMovement, ForceMode.Acceleration);

        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray,transform.localScale.x/2f + 0.01f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if (isJumpButtonPressed == true && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumpButtonPressed = false;
        }
    }
    //private void oncollisionenter(collision collision)
    //{
    //    isgrounded = true;
    //}
    //private void oncollisionexit(collision collision)
    //{
    //    isgrounded = false;
    //}
}
