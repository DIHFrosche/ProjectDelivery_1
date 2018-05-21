using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCat : MonoBehaviour {

    public GameObject cat;
    public bool hasCatBeenSelected;
    public LayerMask layer;
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, 1000, layer)){
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10000, Color.blue);
            if(hit.transform.tag == "Cat" ) {
                if (Input.GetKey(KeyCode.Mouse1)) {
                    for (int i = 0; i < hit.transform.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                        hit.transform.gameObject.GetComponent<Renderer>().materials[i].color = Color.green;
                    }
                    cat = hit.transform.gameObject;
                    //GetComponent<Catshoot>().cat = hit.transform.gameObject.GetComponent<Rigidbody>();
                    hasCatBeenSelected = true;
                }
                if(hasCatBeenSelected != true) {
                    for (int i = 0; i < hit.transform.gameObject.GetComponent<Renderer>().materials.Length; i++) {
                        hit.transform.gameObject.GetComponent<Renderer>().materials[i].color = Color.blue;

                    }
                }
            }
            
        }
	}
}
