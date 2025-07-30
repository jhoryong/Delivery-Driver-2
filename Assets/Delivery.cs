using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float delay = 0f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("asdf");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            if (hasPackage)
            {
                Debug.Log("Already carrying a package");
                return;
            }
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, delay);
        }
        else if (other.CompareTag("Customer"))
        {
            if (hasPackage)
            {
                Debug.Log("Package delivered");
                hasPackage = false;
            }
            else
            {
                Debug.Log("No package to deliver");
            }
        }
    }
}
