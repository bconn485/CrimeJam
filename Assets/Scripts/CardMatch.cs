using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMatch : MonoBehaviour
{
    public GameObject coveredCards;
    private GameObject firstCard;
    private GameObject secondCard;
    private GameObject firstCover;
    private GameObject secondCover;
    private bool matching = false;

    public GameObject hideCards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if card is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("here");
            if (!matching)
            {
            if (Physics.Raycast(ray, out hit, 1000f))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    if (this.firstCard == null)
                    {
                        Debug.Log("Setting first card");
                        this.firstCover = hit.transform.gameObject;
                        foreach (Transform card in coveredCards.transform)
                        {
                            if (card.name == hit.transform.gameObject.name)
                            {
                                Debug.Log("Confirmed first card");
                                this.firstCard = card.transform.gameObject;
                                break;
                            }
                        }
                        this.firstCover.GetComponent<SpriteRenderer>().color = Color.clear;
                    }
                    else if (hit.transform.gameObject != this.firstCard)
                    {
                        Debug.Log("Setting second card");
                        this.secondCover = hit.transform.gameObject;
                        foreach (Transform card in coveredCards.transform)
                        {
                            if (card.name == hit.transform.gameObject.name)
                            {
                                Debug.Log("Confirmed second card");
                                this.secondCard = card.transform.gameObject;
                                break;
                            }
                        }
                        this.secondCover.GetComponent<SpriteRenderer>().color = Color.clear;
                    }
                }

                if (firstCard != null && secondCard != null)
                {
                    StartCoroutine(CheckForMatch());
                }
            }
        }
    }

    private IEnumerator CheckForMatch()
    {
        matching = true;
        yield return new WaitForSeconds(1);
        if (firstCard.GetComponent<SpriteRenderer>().sprite == secondCard.GetComponent<SpriteRenderer>().sprite)
        {
            //match!!!
            GameObject.Find("cards").GetComponent<MatchGame>().matches++;
            this.firstCard.SetActive(false);
            this.secondCard.SetActive(false);
            this.firstCover.SetActive(false);
            this.secondCover.SetActive(false);
        }
        else
        {
            // hide cards again
            this.firstCover.GetComponent<SpriteRenderer>().color = Color.white;
            this.secondCover.GetComponent<SpriteRenderer>().color = Color.white;
        }

        this.firstCard = null;
        this.secondCard = null;
        this.firstCover = null;
        this.secondCover = null;
        matching = false;
    }


}
