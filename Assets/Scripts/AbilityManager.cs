using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public GameObject cardViewer;

    public GameObject player;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;



    public enum Ability
    {
        PressurePolliwog, 
        TongueTrap,
        FoulFangs,
        LiquidLungs,
        PhantomProwl,
        BlitzBurst
    }

    // Start is called before the first frame update
    void Update()
    {
        RemoveAbility();
        SelectAbility();
    }

    public void AddAbility(Ability a)
    {
        abilities.Add(a);
        if (a == Ability.PressurePolliwog)
        {
            GameObject newCard = Instantiate(card1);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.TongueTrap)
        {
            GameObject newCard = Instantiate(card2);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.FoulFangs)
        {
            GameObject newCard = Instantiate(card3);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.BlitzBurst)
        {
            GameObject newCard = Instantiate(card4);
            newCard.transform.parent = cardViewer.transform;
        }
        if (a == Ability.PhantomProwl)
        {
            GameObject newCard = Instantiate(card5);
            newCard.transform.parent = cardViewer.transform;
        }
    }
    public void RemoveAbility()
    {
        for (int i = 0; i < cardViewer.transform.childCount; i++)
        {
            if (cardViewer.transform.GetChild(i).GetComponent<CardInFront>().isChosen)
            {
                AbilityManager.Ability ability = cardViewer.transform.GetChild(i).GetComponent<CardInFront>().ability;

                //Apply your ability here
                player.GetComponent<DeerMovement>().UseAbility(ability);

                //Remove ability or card from the scene
                abilities.Remove(ability);
                Destroy(cardViewer.transform.GetChild(i).gameObject);
            }
        }

    }

    public void SelectAbility()
    {
        if(cardViewer.gameObject.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(cardViewer.transform.GetChild(0)!= null)
            {
                if(cardViewer.transform.GetChild(0).GetComponent<CardInFront>().cardSelected == false)
                {
                    cardViewer.transform.GetChild(0).GetComponent<CardInFront>().SelectEffect();
                } 
                else if(cardViewer.transform.GetChild(0).GetComponent<CardInFront>().cardSelected == true)
                {
                    AbilityManager.Ability ability = cardViewer.transform.GetChild(0).GetComponent<CardInFront>().ability;

                    player.GetComponent<DeerMovement>().UseAbility(ability);
                    abilities.Remove(ability);
                    Destroy(cardViewer.transform.GetChild(0).gameObject);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(cardViewer.transform.GetChild(1)!= null)
            {
                if(cardViewer.transform.GetChild(1).GetComponent<CardInFront>().cardSelected == false)
                {
                    cardViewer.transform.GetChild(1).GetComponent<CardInFront>().SelectEffect();
                } 
                else if(cardViewer.transform.GetChild(1).GetComponent<CardInFront>().cardSelected == true)
                {
                    AbilityManager.Ability ability = cardViewer.transform.GetChild(0).GetComponent<CardInFront>().ability;

                    player.GetComponent<DeerMovement>().UseAbility(ability);
                    abilities.Remove(ability);
                    Destroy(cardViewer.transform.GetChild(1).gameObject);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {

        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {

        }
        }

    }
}