using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int money;
    public Text text;
    private void Awake()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MakeCash();
        text.text = "Money:" + money;
    }
    public void MakeCash()
    {
        if (Input.GetKey(KeyCode.M))
        {
            money += 100;
            print(money);
        }
    }

}
