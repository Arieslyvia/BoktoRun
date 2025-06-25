using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    bool Alive = true;

    private Rigidbody boktoRB;

    public float playerSpeed;
    public bool isJumping;

    Vector3 start;
    Vector3 end;

    public Vector3 jump;

    public GameObject currentPath;
    public GameObject reStartUI;
    public float gyroSensitivity;




    // Start is called before the first frame update
    void Start()
    {

        boktoRB = this.GetComponent<Rigidbody>();

    }



    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * playerSpeed);
        // boktoRB.velocity = new Vector3(boktoRB.velocity.x, boktoRB.velocity.y, playerSpeed);
        /* Vector3 x = transform.forward * playerSpeed;
         boktoRB.velocity = new Vector3(x.x, boktoRB.velocity.y, x.z);
 */

        if (!Alive) return;
        var x = Vector3.forward + Vector3.up * boktoRB.velocity.y;
        transform.Translate(x * playerSpeed * Time.deltaTime);


        if (transform.position.y < -15)
        {
            Debug.Log("positon running");
            gameObject.SetActive(false);
            reStartUI.SetActive(true);
        }


        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            end = Input.mousePosition;
            Swipe();
        }
    }

    void Swipe()
    {
        var xDisplace = start.x - end.x;
        var yDisplace = start.y - end.y;

        if (Mathf.Abs(xDisplace) > Mathf.Abs(yDisplace))
        {

            if (start.x - end.x < 0)
            {
                this.transform.Rotate(new Vector3(0, 90, 0));
                Debug.Log("right");
            }
            else
            {
                this.transform.Rotate(new Vector3(0, -90, 0));
                Debug.Log("left");
            }
        }
        else
        {

            if (start.y - end.y < 0)
            {
                boktoRB.velocity = new Vector3(boktoRB.velocity.x, jump.y, boktoRB.velocity.z);

                if (isJumping)
                {
                    Debug.Log("up");
                    AudioManager.instance.Jumpsound();
                    boktoRB.AddForce(jump, ForceMode.Impulse);
                    isJumping = false;
                }
            }
            else
            {
                Debug.Log("down");
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = true;
            currentPath = collision.transform.parent.parent.gameObject;
            Debug.Log(currentPath);
        }


        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("obstacle running");
            gameObject.SetActive(false);
            AudioManager.instance.PlayerDeadSound();
            reStartUI.SetActive(true);
        }

    }

    void GyroMovement()
    {
        float gyroX = Input.acceleration.x; // Use Input.gyro.gravity.x if needed
        float moveAmount = gyroX * gyroSensitivity;

        Vector3 targetPosition = transform.position + Vector3.right * moveAmount * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }
}
