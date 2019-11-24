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
    public static float Hiber_Health = 100f;
    public Slider SpeedMeter;

    [Header("UI Scenes")]
    public GameObject MenuPanel;
    public GameObject UiPanel;
    public GameObject BadEnd;
    public GameObject GoodEnd;
    public Text speed;
    public Text hiber;

    [Header("GameObject Components")]
    public Rigidbody rb;
    public GameObject DeathDecal;
    public bool IsAlive = true;
    public bool isPlaying = false;

    [Header("Camera Components")]
    public Camera c;
    public Transform target;
    public float smooth = 5.0f;

    public void Awake()
    {
        MenuPanel.SetActive(true);
        UiPanel.SetActive(false);
        GoodEnd.SetActive(false);
        BadEnd.SetActive(false);
    }
    public void Start()
    {
        ProgressBar.value = Hiber_Health;
        hiber.text = Hiber_Health.ToString();
        Hiber_Health -= 50f;
        
        SpeedMeter.value = movementSpeed;
        speed.text = movementSpeed.ToString();
        rb = gameObject.GetComponentInChildren<Rigidbody>();
        c = gameObject.GetComponentInChildren<Camera>();
    }

    public void FixedUpdate()
    {
        if (isPlaying)
        {
            MenuPanel.SetActive(false);
            UiPanel.SetActive(true);
            
        }
        if (isPlaying)
        {
            Movement();
            Jump(JumpForce);
        }
        if (IsAlive)
        {
            ProgressBar.value = Hiber_Health;
            hiber.text = Hiber_Health.ToString();
            SpeedMeter.value = movementSpeed;
            speed.text = movementSpeed.ToString();
            if (Hiber_Health <= 0)
            {
                IsAlive = false;
                onDeath();
            }
            else if(Hiber_Health >= 100)
            {
                GoodEnd.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && movementSpeed < 6f && movementSpeed > 1f)
        {
            
            movementSpeed--;
            if (movementSpeed <= 1)
            {
                movementSpeed = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && movementSpeed < 6f && movementSpeed > 1f)
        {
           
            movementSpeed++;
            if (movementSpeed >= 6)
            {
                movementSpeed = 5;
            }
        }

        if (Input.GetKeyDown(KeyCode.P) == true)
        { 
            rb.constraints = RigidbodyConstraints.FreezeAll;
            MenuPanel.SetActive(true);
            UiPanel.SetActive(false);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

    }

    void Movement()
    {
        rb.velocity += new Vector3((movementSpeed * 0.1f), 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity += new Vector3(0, 0, (movementSpeed * 0.1f));
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity -= new Vector3(0, 0, (movementSpeed * 0.1f));
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
    private void OnTriggerEnter(Collider other)
    {
        Destroyables destro = other.gameObject.GetComponent<Destroyables>();
        if (destro)
        {
            Destroy(other.gameObject);
            Instantiate(DeathDecal, other.transform.position, other.transform.rotation);
        }
    }
    void onDeath()
    {
        movementSpeed = 0;
        BadEnd.SetActive(true);
        isPlaying = false;
    }
    public void OnStart()
    {
        isPlaying = true;
    }

    public void OnExit()
    {
        Debug.Log("Quit Applicaiton");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL); 
#endif

        Application.Quit();
    }

}
