using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatDeliveredTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Cat") {
            FindObjectOfType<GameMaser>().deliveredCats++;
        }
    }
}
