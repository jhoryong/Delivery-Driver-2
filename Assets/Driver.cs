using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 2f;

    void Start()
    {

    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boost activated");
        }
        else if (other.CompareTag("Slow"))
        {
            moveSpeed = slowSpeed;
            Debug.Log("Slow activated");
        }
    }
}
