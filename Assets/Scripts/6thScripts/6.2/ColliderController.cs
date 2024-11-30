using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject restBall;

    private void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
            restBall.SetActive(true);
            if (rb != null)
            {
                rb.isKinematic = !rb.isKinematic;
                Debug.Log("Bilye Wall tag'li objeye çarptý, isKinematic kapatýldý.");
            }
        }
    }
}
