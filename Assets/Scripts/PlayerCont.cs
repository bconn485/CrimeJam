﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCont : MonoBehaviour
{
    [SerializeField] private string levelChange;
    public int cashValue = 1;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Score.instance.ChangeScore(cashValue);
            Destroy(other.gameObject);
            i++;
        }
        if (other.gameObject.CompareTag("EndOne"))
        {
            if (i == 7)
            {
                SceneManager.LoadScene(levelChange);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


}
