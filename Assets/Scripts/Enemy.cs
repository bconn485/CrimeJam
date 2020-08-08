using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform pffov;
    private FOV fov;
    // Start is called before the first frame update
    public float speed;
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
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
            transform.Translate(0, 0, -2 * Time.deltaTime * speed);
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
            velocity = (-1)*(previousPosition - transform.position);
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
        if (moveRight || i == 0)
        {
            Invoke("Left", 2);
            i++;
        }
        if (moveLeft)
        {
            Invoke("Right", 2);
        }

    }
    private void Left()
    {
        moveLeft = true;
        moveRight = false;
        moveDown = false;
        moveUp = false;
    }
    private void Right()
    {
        moveLeft = false;
        moveRight = true;
        moveDown = false;
        moveUp = false;
    }
    private void Up()
    {
        moveLeft = false;
        moveRight = false;
        moveDown = false;
        moveUp = true;
    }
    private void Down()
    {
        moveLeft = false;
        moveRight = false;
        moveDown = true;
        moveUp = false;
    }

}
