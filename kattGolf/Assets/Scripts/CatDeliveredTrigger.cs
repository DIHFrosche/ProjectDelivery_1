using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatDeliveredTrigger : MonoBehaviour {

    public GameObject goodJob;
    private void OnTriggerEnter(Collider other) {
        print(transform.name);
        if(other.gameObject.tag == "Window") {
            DontDestroyOnLoad(gameObject);
            FindObjectOfType<GameMaser>().UpdateCAts();
            Instantiate(goodJob, transform.position, Quaternion.identity);
            FindObjectOfType<CameraShake>().shakeDuration = 0.3f;
            Destroy(gameObject);
        }
    }
}
