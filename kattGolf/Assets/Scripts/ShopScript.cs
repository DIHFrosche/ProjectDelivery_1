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
        if (Collision.tag == "meny")
        {
            ShopCanvas.SetActive(true);
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
            ShopCanvas.SetActive(false);
            gamemnu.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
