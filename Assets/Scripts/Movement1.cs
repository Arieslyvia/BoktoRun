using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

  // bool Alive = true;
    public Animator playeR;
    public Rigidbody bokTo;
    public float boktoSpeed;
    public float rotationSpeed;
    public Vector3 jump;
    
    bool isJumping;

    Vector3 startPos;
    Vector3 lastPos;
    private CapsuleCollider playerCollider;
    public GameObject currentPath;

    public GameObject optionGo;
    public float gyroSensitivity;

    public int playerHealth = 2;
    public GameObject fullHealth;
    public GameObject halfHealth;
    public GameObject emptyHealth;

   

    private void Start()
    {
        playeR = GetComponent<Animator>();
        bokTo = GetComponent<Rigidbody>();
       playerCollider = GetComponent<CapsuleCollider>();

        
    }

    private void Update()
    {
        GyroMovement();


        Vector3 horizontalVel = transform.forward * boktoSpeed;
        bokTo.velocity = new Vector3(horizontalVel.x, bokTo.velocity.y, horizontalVel.z);
        SwipeRL();

        if (transform.position.y < -1)
        {
            gameObject.SetActive(false);
            AudioManager.instance.PlayerDeadSound();
            optionGo.SetActive(true);
            
        }
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
                playeR.transform.Rotate(new Vector3(0, 90, 0));

                playeR.SetFloat("Running", Mathf.Abs(xDisplace));
                Debug.Log("Swipe Right");

            }
            else
            {
                playeR.transform.Rotate(new Vector3(0, -90, 0));
                
                playeR.SetFloat("Running", Mathf.Abs(xDisplace));
                Debug.Log("Swipe Left");

            }
        }
        else
        {
            if (startPos.y - lastPos.y < 0)
            {
                if(isJumping)
                {
                    isJumping = true;
                    playeR.SetTrigger("Jumping");
                    bokTo.AddForce(jump, ForceMode.Impulse);
                    AudioManager.instance.Jumpsound();
                    isJumping = false;
                    Debug.Log("up");
                }
            }
            else if (startPos.y - lastPos.y > 0)
            {
                Debug.Log("down");
                playeR.SetTrigger("Slide");

            }

        }
    }
    IEnumerator playerdead()
    {
        playerHealth -= 1;
        halfHealth.SetActive(true);
        yield return new WaitForSeconds(5);
        playerHealth = 2;
    }
    void gameoverstate()
    {
       

        
        optionGo.SetActive(true);
        emptyHealth.SetActive(true);
        fullHealth.SetActive(false);
        gameObject.SetActive(false);
       

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

          isJumping = true;
            currentPath = collision.transform.parent.parent.gameObject;

            Debug.Log(currentPath);


        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            if(AudioSetting.isVibrating)
            {
               Handheld.Vibrate();
               AudioManager.instance.BasketCollide();
                
            }
            gameObject.SetActive(false);
            optionGo.SetActive(true);
           
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameoverstate();
            
        }
        if (collision.gameObject.CompareTag("barrel"))
        {
            StartCoroutine(playerdead());
            if (playerHealth <= 0)
            {
            
                gameoverstate();

            }
        }
    }

    public void Collider()
    {
        playerCollider.height = 0.03f;
        playerCollider.center = new Vector3(0, 0.02f, 0);

    }
    public void NormalCollider()
    {
        playerCollider.height = 0.8020196f;
        playerCollider.center = new Vector3(0, 0.5030588f, 0);
    }

    void GyroMovement()
    {
        float gyroX = Input.acceleration.x; // Use Input.gyro.gravity.x if needed
        float moveAmount = gyroX * gyroSensitivity;

        Vector3 targetPosition = transform.position + transform.right * moveAmount * Time.smoothDeltaTime;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }

}


