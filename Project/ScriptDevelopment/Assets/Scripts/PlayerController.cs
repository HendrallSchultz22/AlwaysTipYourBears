using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Controls")]
    public float movementSpeed = 1f;
    public float JumpForce = 250f;
    public bool isGrounded;
    [Header("UI Components")]
    public Slider ProgressBar;
    public int Hiber_Health;
    public Slider SpeedMeter;
    public Text Status;
     
   

    [Header("GameObject Components")]
    public Rigidbody rb;

    [Header("Camera Components")]
    public Camera c;
    public Transform target;
    public float smooth = 5.0f;

    public void Start()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody>();
        c = gameObject.GetComponentInChildren<Camera>();
    }

    public void FixedUpdate()
    {
        Movement();
        Jump(JumpForce);
    }

    void Movement()
    {
        rb.velocity += new Vector3(0, 0, (movementSpeed * 0.1f));

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity += new Vector3((movementSpeed * 0.1f), 0, 0);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity -= new Vector3((movementSpeed * 0.1f), 0, 0);
        }
    }

    void Jump(float jumpForce)
    {
        jumpForce = JumpForce;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SolidSurface>())
        {
            isGrounded = true;
        }
    }

}
