using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Player;
    public GameObject gamemnu;
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
        print("shop");
        if (Collision.tag == "meny")
        {
            Shop.SetActive(true);
            gamemnu.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("leave");
        if (other.tag == "meny")
        {
            Shop.SetActive(false);
            gamemnu.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
