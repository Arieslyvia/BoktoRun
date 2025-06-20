using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        RotationSpeed(speed);

    }
    public void RotationSpeed(float rotationSpeed)
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0 );

    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Lilac"))
        {
            //have to let lilac disappear
        }
    }
}
