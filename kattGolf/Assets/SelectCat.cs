using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCat : MonoBehaviour {

    public GameObject cat;
    public bool hasCatBeenSelected;

    public GameObject bat;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit)){
            if(hit.transform.tag == "Cat") {
                if (Input.GetKey(KeyCode.Mouse1)) {
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    cat = hit.transform.gameObject;
                    hasCatBeenSelected = true;
                }
                if(hasCatBeenSelected != true) {
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
            
        }
	}
}
