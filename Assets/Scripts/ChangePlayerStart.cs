using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerStart : MonoBehaviour
{
    [SerializeField] private GameObject bokto;
    [SerializeField] private GameObject barrel;
   
   // [SerializeField]private CameraMovement cam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bokto)
        {
            barrel.transform.position = bokto.transform.position;
            bokto.SetActive(false);
            barrel.SetActive(true);
            //cam.target = barrel.transform;
        }
    }
}
