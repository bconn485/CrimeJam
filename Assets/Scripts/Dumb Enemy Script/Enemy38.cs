using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy38 : MonoBehaviour
{
    [SerializeField] private Transform pffov;
    private FOV fov;
    // Start is called before the first frame update
    public float speed;
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
    public bool wait;
    Vector3 Velocity;
    int i;
    public Rigidbody2D rb;
    void Start()
    {
        fov = Instantiate(pffov, null).GetComponent<FOV>();
        rb = GetComponent<Rigidbody2D>();
        Velocity = rb.velocity;
        i = 0;
    }
    public void Move()
    {
        if (moveUp)
        {
            transform.Translate(0, 2 * Time.deltaTime * speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (moveDown)
        {
            transform.Translate(0, -2 * Time.deltaTime * speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (moveLeft)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (wait)
        {
            transform.Translate(0, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }
    private Vector3 previousPosition;
    private Vector3 velocity;
    public Vector3 CurrentMovementDirection
    {
        get
        {
            return velocity.normalized;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (previousPosition != transform.position)
        {
            velocity = (-1) * (previousPosition - transform.position);
            previousPosition = transform.position;
        }
        rb = GetComponent<Rigidbody2D>();
        Velocity = rb.velocity;
        fov.SetOrigin(transform.position);
        fov.SetAimDirection(velocity);

    }

    private void FixedUpdate()
    {
        Move();
        if (moveUp || i == 0)
        {
            if (i == 0)
            {
                Down();
                i++;
            }
            else
            {
                Invoke("Down", 5);
            }
        }
        if (moveDown)
        {
            Invoke("Wait", 5);
        }
        if (wait)
        {
            Invoke("Up", 3);
        }
        // if (moveUp)
        //{
        //  Invoke("Right", 7);
        //}
        //if (moveRight)
        //{
        //  Invoke("Left", 7);
        //}
        // if (moveDown)
        //  {
        //     Invoke("Up", 2);
        //  }



    }
    private void Left()
    {
        wait = false;
        moveLeft = true;
        moveRight = false;
        moveDown = false;
        moveUp = false;
    }
    private void Right()
    {
        wait = false;
        moveLeft = false;
        moveRight = true;
        moveDown = false;
        moveUp = false;
    }
    private void Up()
    {
        wait = false;
        moveLeft = false;
        moveRight = false;
        moveDown = false;
        moveUp = true;
    }
    private void Down()
    {
        wait = false;
        moveLeft = false;
        moveRight = false;
        moveDown = true;
        moveUp = false;
    }
    private void Wait()
    {
        wait = true;
        moveLeft = false;
        moveRight = false;
        moveDown = false;
        moveUp = false;
    }
}
