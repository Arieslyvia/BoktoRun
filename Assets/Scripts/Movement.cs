

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
    public Vector3 jump;

    bool isJumping;

    Vector3 startPos;
    Vector3 lastPos;



    private void Start()
    {
        playeR = GetComponent<Animator>();
        bokTo = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
        var x = Vector3.forward + Vector3.up * bokTo.velocity.y;
        transform.Translate(x * boktoSpeed*Time.deltaTime);
        SwipeRL();

      
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
            ShiftPosition();
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
                playeR.transform.eulerAngles = new Vector3(boktoSpeed*Time.deltaTime, transform.eulerAngles.y+90f, 0);
                //transform.Rotate(new Vector3(0f, 90f, 0f));
                //bokTo.velocity = new Vector3(boktoSpeed, bokTo.velocity.y, 0);
                playeR.SetFloat("Running", Mathf.Abs(xDisplace));
                Debug.Log("Swipe Right");

            }
            else
            {
                playeR.transform.eulerAngles = new Vector3(boktoSpeed*Time.deltaTime, transform.eulerAngles.y+ -90f, 0);
                //bokTo.velocity = new Vector3(-boktoSpeed, bokTo.velocity.y, 0);
                Debug.Log("Swipe Left");
                playeR.SetFloat("Running", Mathf.Abs(xDisplace));
            }
        }
        else
        {
            if (startPos.y - lastPos.y < 0)
            {
                Debug.Log("up");
                playeR.SetBool("Jumping", true);
                bokTo.AddForce(jump, ForceMode.Impulse);
               
            }
            else
            {
                Debug.Log("down");
                playeR.SetTrigger("Slide");

            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = false;
            playeR.SetBool("Jumping", false);

        }

    }


}


