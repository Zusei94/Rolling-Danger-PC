using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField] private Transform cannonTip;
    [SerializeField] private float shootingCooldown = 3f;
    [SerializeField] private float laserPower = 50;

    private bool isPlayerInRange;
    private GameObject player;
    private float timeLeftToShoot = 0;
    private LineRenderer cannonLaser;
    // Start is called before the first frame update
    void Start()
    {
        cannonLaser = GetComponent<LineRenderer>();
        cannonLaser.sharedMaterial.color = Color.green;
        cannonLaser.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        timeLeftToShoot = shootingCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            cannonHead.transform.LookAt(player.transform);

            cannonLaser.SetPosition(0, cannonTip.transform.position);
            cannonLaser.SetPosition(1, player.transform.position);

            timeLeftToShoot -= Time.deltaTime;
        }

        if (timeLeftToShoot <= shootingCooldown * 0.5)
        {
            cannonLaser.sharedMaterial.color = Color.red;
        }

        if (timeLeftToShoot <= 0)
        {
            Vector3 directionToPushBack = player.transform.position - cannonTip.transform.position;
            Vector3 dir = directionToPushBack.normalized;

            player.GetComponent<Rigidbody>().AddForce(dir * laserPower, ForceMode.Impulse);
            Debug.Log(directionToPushBack.magnitude);
            Debug.Log(directionToPushBack.normalized);

            timeLeftToShoot = shootingCooldown;
            cannonLaser.sharedMaterial.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            cannonLaser.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInRange = false;
        cannonLaser.enabled = false;

        timeLeftToShoot = shootingCooldown;
        cannonLaser.sharedMaterial.color = Color.green;
    }
}
