using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 5f;
    [SerializeField] float runSpeed = 8f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;


    Animator animator;
    public bool moving;
    public bool acting;
    bool running;


    private float startTime = 1f;
    public float deltaTime = 0f;

    private InventoryManager inventoryPlayer;
    private ToolsPlayerController toolsPlayerController;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        toolsPlayerController = GetComponent<ToolsPlayerController>();
        inventoryPlayer = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (!acting)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                running = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                running = false;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            motionVector.x = horizontal;
            motionVector.y = vertical;

            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("vertical", vertical);

            moving = horizontal != 0 || vertical != 0;
            animator.SetBool("moving", moving);

            if (horizontal != 0 || vertical != 0)
            {
                lastMotionVector = new Vector2(
                    horizontal,
                    vertical
                ).normalized;

                animator.SetFloat("lastHorizontal", horizontal);
                animator.SetFloat("lastVertical", vertical);
            }
        }

        if (!moving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                acting = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!acting)
        {
            Move();
        }

        if (!moving)
        {
            VerifyAction();
        }
    }

    private void Move()
    {
        rigidbody2d.velocity = motionVector * (running == true ? runSpeed : speed);
    }

    private void VerifyAction()
    {
        if (acting)
        {
            toolsPlayerController.UseTool();
            if (toolsPlayerController.selectedItem != null
                && (!Seed.HasSeed(toolsPlayerController.selectedItem.GetName())))
            {
                VerifyTimeAction();
            }
            else
            {
                acting = false;
            }
        }

        animator.SetBool("acting", acting);
    }

    private void VerifyTimeAction()
    {
        if (deltaTime <= 0)
        {
            acting = false;
            deltaTime = startTime;
        }
        else
        {
            deltaTime -= Time.deltaTime;
        }
    }

    private void OnDisable()
    {
        rigidbody2d.velocity = Vector2.zero;
    }
}