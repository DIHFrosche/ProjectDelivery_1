using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayMoney : MonoBehaviour
{
    public int payment1;
    public int payment2;
    public int payment3;
    public int payment4;
    public int payment5;

    public GameObject SoldOut1;
    public GameObject SoldOut2;
    public GameObject SoldOut3;
    public GameObject SoldOut4;
    public GameObject SoldOut5;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;

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
            Button1.SetActive(false);
            Money.money -= payment1;
        }
    }
    public void Pay2()
    {
        if (Money.money >= payment2)
        {
            SoldOut2.SetActive(true);
            Button2.SetActive(false);
            Money.money -= payment2;
        }
    }
    public void Pay3()
    {
        if (Money.money >= payment3)
        {
            SoldOut3.SetActive(true);
            Button3.SetActive(false);
            Money.money -= payment3;
        }
    }
    public void Pay4()
    {
        if (Money.money >= payment4)
        {
            SoldOut4.SetActive(true);
            Button4.SetActive(false);
            Money.money -= payment4;
        }
    }
    public void Pay5()
    {
        if (Money.money >= payment5)
        {
            SoldOut5.SetActive(true);
            Button5.SetActive(false);
            Money.money -= payment5;
        }
    }
}
