using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private string levelChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Change()
    {
        SceneManager.LoadScene(levelChange);
    }
}
