using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore(int cash)
    {
        score += cash;
        text.text = "X" + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
