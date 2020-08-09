using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleWin : MonoBehaviour
{
    private int pointsToWin;
    public GameObject myPieces;
    public int currentPoints;
    public GameObject puzzle;

    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = myPieces.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints == pointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);

            StartCoroutine(finished());
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }

    private IEnumerator finished()
    {
        yield return new WaitForSeconds(2);
        puzzle.SetActive(false);
        GameObject.Find("Main Camera").GetComponentInChildren<Camera>().orthographicSize = 5;
    }
}
