using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayMoney : MonoBehaviour
{
    public int payment1;
    public int payment2;
    public int payment3;
    public int payment4;

    public GameObject SoldOut1;
    public GameObject SoldOut2;
    public GameObject SoldOut3;
    public GameObject SoldOut4;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;

    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pay1()
    {
        if (Money.money >= payment1)
        {
            SoldOut1.SetActive(true);
            Image1.SetActive(false);
            Button1.SetActive(false);
            Button2.SetActive(true);
            Money.money -= payment1;
        }
    }
    public void Pay2()
    {
        if (Money.money >= payment2)
        {
            SoldOut2.SetActive(true);
            Image2.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(true);
            Money.money -= payment2;
            GameObject.FindWithTag("Player").GetComponent<CatBat>().BazookaClub();
        }
    }
    public void Pay3()
    {
        if (Money.money >= payment3)
        {
            SoldOut3.SetActive(true);
            Image3.SetActive(false);
            Button3.SetActive(false);
            Button4.SetActive(true);
            Money.money -= payment3;
            GameObject.FindWithTag("Player").GetComponent<CatBat>().WALLEClub();
        }
    }
    public void Pay4()
    {
        if (Money.money >= payment4)
        {
            SoldOut4.SetActive(true);
            Image4.SetActive(false);
            Button4.SetActive(false);
            Money.money -= payment4;
            GameObject.FindWithTag("Player").GetComponent<CatBat>().CatClub();
        }
    }
}
