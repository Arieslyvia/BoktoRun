using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator playeR;
    public Rigidbody bokTo;
    public float boktoSpeed;
    public float rotationSpeed;
    Vector3 directionA = Vector3.forward;
    float xDirection;

    Vector3 startPos;
    Vector3 lastPos;
    


    private void Start()
    {
        playeR = GetComponent<Animator>();
        bokTo = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        bokTo.velocity = directionA * boktoSpeed;
        float input = directionA.magnitude;

        var lookDirection = directionA.normalized;
        if ( lookDirection.magnitude >=0.1f)
        {
            var playerRotation = Quaternion.LookRotation( lookDirection );
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                                playerRotation, rotationSpeed * Time.deltaTime);
             
        }
        //bokTo.velocity = new Vector3(bokTo.velocity.x, bokTo.velocity.y, boktoSpeed);
        SwipeRL();
       // JumpNSlide();
        ShiftPosition();

    }

    void SwipeRL()
    {


        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouseButton
        {
            startPos = Input.mousePosition;
            

        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastPos = Input.mousePosition;
     
        }
        
    }
       

    void ShiftPosition()
    {
       var xDisplace = startPos.x - lastPos.x;
        var yDisplace = startPos.y - lastPos.y;

        if (Mathf.Abs(xDisplace) > Mathf.Abs(yDisplace))
        {
            if (startPos.x - lastPos.x < 0)
            {
                playeR.transform.eulerAngles = new Vector3(boktoSpeed, 90f, 0);
                //transform.Rotate(new Vector3(0f, 90f, 0f));
                bokTo.velocity = new Vector3(boktoSpeed, bokTo.velocity.y, 0);


                Debug.Log("Swipe Right");

            }
            else
            {
                playeR.transform.eulerAngles = new Vector3(boktoSpeed, -90f, 0);
                bokTo.velocity = new Vector3(-boktoSpeed, bokTo.velocity.y, 0);
                Debug.Log("Swipe Left");
            }
        }
        else 
        {
            if (startPos.y - lastPos.y < 0)
            {
                Debug.Log("up");

            }
            else
            {
                Debug.Log("down");
            }
        }

    }

    
}


