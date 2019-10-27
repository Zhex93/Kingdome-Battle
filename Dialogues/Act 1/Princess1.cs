using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Princess1 : MonoBehaviour
{
    public static Princess1 Instance { get; private set; }
    public Vector2 mov;
    public float speed = 6;
    public float horizontalInput, verticalInput;
    public Rigidbody2D rb;
    public Animator anim;
    public bool attacking, movement;

    public bool talking;
    public Text characterNameText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        movement = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {
        PlayerMovement();
        Animations();
    }

    private void PlayerMovement()
    {
        float fixedSpeed = speed * Time.deltaTime;
        if (movement == true)
        {
            rb.MovePosition(rb.position + mov * fixedSpeed);
        }
    }

    private void Animations()
    {
            mov = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            if (mov != Vector2.zero)
            {
                anim.SetFloat("MovX", mov.x);
                anim.SetFloat("MovY", mov.y);
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }

    }
}
