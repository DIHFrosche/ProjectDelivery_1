using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider Collision)
    {
        if (GetComponent<Collider>().tag == "meny")
        {
            Shop.SetActive(true);
        }
    }

}
