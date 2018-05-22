using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject ShopCanvas;
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
        if (Collision.tag == "Player")
        {
            ShopCanvas.SetActive(true);
            gamemnu.SetActive(false);
            ShowCursor.SetCursorLock(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("leave");
        if (other.tag == "Player")
        {
            ShopCanvas.SetActive(false);
            gamemnu.SetActive(true);
            ShowCursor.SetCursorLock(true);
        }
    }

}
