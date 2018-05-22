using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBat : MonoBehaviour {

    public GameObject club;
    GameObject cat;

    Vector3 currentPointHit;
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) {
            currentPointHit = hit.point;
        }
        if (GetComponent<SelectCat>().hasCatBeenSelected == true) {
            club.SetActive(true);
            cat = GetComponent<SelectCat>().cat;
            if(club != null) {
                club.transform.position = cat.transform.position + new Vector3(0, 2.55f, 0);
                club.transform.LookAt(currentPointHit);
                club.transform.eulerAngles = Vector3.Scale(club.transform.eulerAngles, new Vector3(0, 1, 0));
                club.transform.eulerAngles -= new Vector3(0, 90, 0);
            }


        }
        else {
            club.SetActive(false);
            cat = null;
            
        }
    }
}
