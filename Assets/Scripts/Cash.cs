using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public int cashValue=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject == null)
        {
            Score.instance.ChangeScore(cashValue);
        }
    }
}
