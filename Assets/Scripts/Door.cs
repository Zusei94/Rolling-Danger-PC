using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float unlockingSpeed = 2;
    [SerializeField] private float unlockingTime = 3;
    [SerializeField] private bool isDoorUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (isDoorUnlocked)
        {
            unlockingTime -= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * unlockingSpeed);

            if(unlockingTime <= 0)
            {
                gameObject.SetActive(false);
            }
        } 
    }

    public void UnlockDoor()
    {
        isDoorUnlocked = true;
    }
}
