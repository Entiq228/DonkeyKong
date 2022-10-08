using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    private bool doJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !doJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            doJump = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            doJump = false;
        }
    }
}
