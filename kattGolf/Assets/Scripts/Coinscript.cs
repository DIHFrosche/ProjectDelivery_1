using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinscript : MonoBehaviour
{
    public GameObject Coin;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        print("Något");
        if (other.tag == "Player")
        {
            print(other);
            Money.money += 300;
            Destroy(Coin);
            print("Peng");
        }
    }
}
