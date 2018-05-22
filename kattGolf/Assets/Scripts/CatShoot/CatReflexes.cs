using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatReflexes : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
