using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMatch : MonoBehaviour
{
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject coveredCards;

    public GameObject firstCover;
    public GameObject secondCover;
    public GameObject hideCards;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (this.firstCard == null)
            {
                foreach (Transform card in coveredCards.transform)
                {
                    if (card.name == this.name)
                    {
                        firstCard = card.gameObject;
                        break;
                    }
                }
                if (firstCard)
                {
                    foreach(Transform card in hideCards.transform)
                    {
                        card.GetComponent<CardMatch>().firstCover = this.gameObject;
                    }
                    firstCover.SetActive(false);
                }
            }
            else
            {
                foreach (Transform card in coveredCards.transform)
                {
                    if (card.name == this.name)
                    {
                        secondCard = card.gameObject;
                        break;
                    }
                }
                if (secondCard)
                {
                    foreach (Transform card in hideCards.transform)
                    {
                        card.GetComponent<CardMatch>().secondCover = this.gameObject;
                    }
                    secondCover.SetActive(false);
                }
            }

            if (firstCard != null && secondCard != null)
            {
                CheckForMatch();
            }
            
        }
    }

    void CheckForMatch()
    {
        if (firstCard.GetComponent<SpriteRenderer>().sprite == secondCard.GetComponent<SpriteRenderer>().sprite)
        {
            //match!!!
            GameObject.Find("cards").GetComponent<MatchGame>().matches++;
            firstCard.SetActive(false);
            secondCard.SetActive(false);
            foreach (Transform card in hideCards.transform)
            {
                card.GetComponent<CardMatch>().firstCard = null;
                card.GetComponent<CardMatch>().secondCard = null;
                card.GetComponent<CardMatch>().firstCover = null;
                card.GetComponent<CardMatch>().secondCover = null;
            }
        }
    }


}
