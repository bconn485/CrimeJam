using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : MonoBehaviour
{
    public GameObject dog;
    public GameObject cat;
    public GameObject fern;
    public GameObject bottle;
    public GameObject coveredCards;
    public GameObject matchGame;

    List<Sprite> imageList = new List<Sprite>();
    public int matches = 0;
    private int total_matches = 4;
    // Start is called before the first frame update
    void Start()
    {
        imageList.Add(dog.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(dog.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(cat.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(cat.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(fern.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(fern.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(bottle.GetComponent<SpriteRenderer>().sprite);
        imageList.Add(bottle.GetComponent<SpriteRenderer>().sprite);
        IListExtensions.Shuffle(imageList);

        int index = 0;
        foreach (Transform card in coveredCards.transform)
        {
            card.GetComponent<SpriteRenderer>().sprite = imageList[index];
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (matches == total_matches)
        {
            matchGame.SetActive(false);
        }
    }
    
}
public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}