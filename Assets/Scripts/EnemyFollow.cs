using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Rigidbody rb;
    private bool isPlayerInRange;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInRange)
        {
            // tinh vector de dash
            Vector3 targetDirection = player.transform.position - transform.position;
            //velocity change >> force will change our velocity ignoring the enemy's mass
            rb.AddForce(targetDirection * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            //store our velocity in a temp variable to change it later
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0; // remove any velocity on the Y-Axis

            rb.velocity = newVelocity;
        }
    }
}
