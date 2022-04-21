using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpForce;
    public float playerRotationSpeed;
    
    Animator animator;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        animator.SetTrigger("isIdle");

        // player left, right, back, forward movements
        float inputX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float inputZ = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate(inputX, 0f, inputZ);
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)
        {
            animator.SetTrigger("isRunning");
        }

        // player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * playerJumpForce);
        }

        // player firing...on mouse click
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isShooting");
            //Debug.Log("firing");
        }

    }
}
