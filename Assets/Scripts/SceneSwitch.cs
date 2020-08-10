using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private string levelChange;
    [SerializeField] private string levelChange2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Change()
    {
        SceneManager.LoadScene(levelChange);
    }
    public void Change2()
    {
        SceneManager.LoadScene(levelChange2);
    }
    public void Change3()
    {
        Application.Quit();
    }
}
