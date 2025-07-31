using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delay = 0f;
    [SerializeField] Color32 hasPackageColor = new(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new(1, 1, 1, 1);

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(other.gameObject, delay);
        }
        else if (other.CompareTag("Customer"))
        {
            if (hasPackage)
            {
                Debug.Log("Package delivered");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("No package to deliver");
            }
        }
    }
}
