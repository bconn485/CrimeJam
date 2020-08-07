using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private FOV fov;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 test = new Vector3(0f, 1.0f, 0.0f);
        fov.SetOrigin(transform.position);
        fov.SetAimDirection(test);
        
    }
}
