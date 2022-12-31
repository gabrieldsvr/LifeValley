using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;

    public float speed = 2.5f;

    private float input_x;
    private float input_y;

    private int orientation;

    public bool isMoving = false;


    public float timeAction;
    public float startTimeAction;
    
    


    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");


        isMoving = (input_x != 0 || input_y != 0);

        if (isMoving)
        {
            Vector3 movement = new Vector3(input_x, input_y, 0f);
            
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            transform.position += movement * (speed * Time.deltaTime);
            
            anim.SetFloat("lastMoveX",input_x);
            anim.SetFloat("lastMoveY",input_y);
        }
        
        anim.SetBool("isWalking", isMoving);

        if (timeAction <= 0)
        {
            anim.SetBool("isWater", false);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetBool("isWater", true);
                timeAction = startTimeAction;
            }

        }
        else
        {
            timeAction -= Time.deltaTime;
        }
        
        
        
    }
    
    
    
}