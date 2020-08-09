using System.Collections;
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
    private Color specialColor;
    public GameObject puzzle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        specialColor = GameObject.Find("specialCash").GetComponent<SpriteRenderer>().color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Score.instance.ChangeScore(cashValue);
            Destroy(other.gameObject);
            i++;
            if (other.gameObject.GetComponent<SpriteRenderer>().color == specialColor) {
                //Activate minigame
                GameObject.Find("Main Camera").GetComponentInChildren<Camera>().orthographicSize = 9;
                puzzle.SetActive(true);
            }
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
