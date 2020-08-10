using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCont : MonoBehaviour
{
    [SerializeField] private string levelChange;
    [SerializeField] private string levelChange2;
    [SerializeField] private string levelChange3;
    public AudioSource coin;
    public int cashValue = 1;
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    int i;
    private GameObject puzMin;
    private GameObject mazeMin;
    public GameObject puzzle;
    public GameObject maze;
    private GameObject puzzleClone;
    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        puzMin = GameObject.Find("puzzleMinigame");
        mazeMin = GameObject.Find("mazeMinigame");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coin.Play();
            Score.instance.ChangeScore(cashValue);
            Destroy(other.gameObject);
            i++;
            if (other.gameObject == puzMin) {
                //Activate minigame
                GameObject.Find("Main Camera").GetComponentInChildren<Camera>().orthographicSize = 9;
                puzzleClone = Instantiate(puzzle);
                puzzleClone.SetActive(true);
                //pause character (in Update function)
                speed = 0;
            }
            if (other.gameObject == mazeMin)
            {
                //Activate minigame
                puzzleClone = Instantiate(maze);
                puzzleClone.SetActive(true);
                //pause character (in Update function)
                speed = 0;
            }
        }
        if (other.gameObject.CompareTag("EndOne"))
        {
            if (i == 7)
            {
                SceneManager.LoadScene(levelChange);
            }
        }
        if (other.gameObject.CompareTag("EndTwo"))
        {
            if (i == 7)
            {
                SceneManager.LoadScene(levelChange2);
            }
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            if (i == 14)
            {
                SceneManager.LoadScene(levelChange3);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleClone && !puzzleClone.activeSelf)
        {
            speed = 2.0f;
            //destroy puzzle
            Destroy(puzzleClone);
        }
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


}
