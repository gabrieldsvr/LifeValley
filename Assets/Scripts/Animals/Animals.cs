using System;
using System.Collections;
using UnityEngine;
using UnityEngine;
using Random = UnityEngine.Random;

public class Animals : MonoBehaviour
{
    public string name;

    public float life = 100f;

    public float hungry;
    public float thirst;

    public float offspring;
    public Species Specie;


    public int age;


    public float moveSpeed = 0.5f;
    public float moveDelay = 2f;
    private Vector3 targetPos;

    private Collider2D collider;
    private bool impacto;

    public Rigidbody2D rigidbody2D;
    public Animator animator;



    public enum Species
    {
        Turkey,
        Sheep,
        Pig,
        Cow,
        Goat,
        Chicken,
    }


    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public virtual void Eat(float mount)
    {
        // hungry -= mount;
    }

    public virtual void Move()
    {
        StartCoroutine(RandomMovement());
    }

    public IEnumerator RandomMovement()
    {
        while (true)
        {
            float moveX = Random.Range(-2f, 2f);
            float moveY = Random.Range(-2f, 2f);

            targetPos = new Vector3(transform.position.x + moveX, transform.position.y + moveY, transform.position.z);
            
           

            while (transform.position != targetPos && impacto == false)
            {
                Vector2 direction = (Vector2)targetPos - (Vector2)transform.position;
                Vector3 lastPosition = transform.position;
                
                
                
                
                if (Mathf.Abs(direction.x) != 0) {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPos.x, transform.position.y), moveSpeed * Time.deltaTime);
                } else {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, targetPos.y), moveSpeed * Time.deltaTime);
                }
                
                SetAnimation(lastPosition,transform.position);
                yield return null;
            }

            impacto = false;
            animator.SetBool("moving", false);
            yield return new WaitForSeconds(moveDelay);
        }
    }

    private void SetAnimation(Vector3 lastPosition, Vector3 position)
    {
        animator.SetBool("moving", true);
        if (lastPosition.x < position.x)
        {
            animator.SetFloat("horizontal", 1);
        }
        else if (lastPosition.x > position.x)
        {
            animator.SetFloat("horizontal", -1);
        }  else
        {
            animator.SetFloat("horizontal", 0);
        }
        if (lastPosition.y < position.y)
        {
            animator.SetFloat("vertical", 1);
        }
        else if (lastPosition.y > position.y)
        {
            animator.SetFloat("vertical", -1);
        }  else
        {
            animator.SetFloat("vertical", 0);
        }
    }


    private void OnCollisionStay2D(Collision2D col)
    {
        animator.SetBool("moving", false);
        impacto = true;
    }
}