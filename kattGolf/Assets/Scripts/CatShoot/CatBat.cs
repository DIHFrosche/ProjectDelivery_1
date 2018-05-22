using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBat : MonoBehaviour {

    public GameObject club;
    GameObject cat;
    public Mesh Bazooka;
    public Mesh Catclub;
    public Mesh WALLE;


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
            if(cat != null) {
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
    public void BazookaClub()
    {
        GetComponent<Catshoot>().catBatPivot.GetComponentInChildren<MeshFilter>().mesh = Bazooka;
        GetComponent<Catshoot>().maxForce = 20;
        GetComponent<Catshoot>().maxHeight = 12;
    }
    public void CatClub()
    {
        GetComponent<Catshoot>().catBatPivot.GetComponentInChildren<MeshFilter>().mesh = Catclub;
        GetComponent<Catshoot>().maxForce = 40;
        GetComponent<Catshoot>().maxHeight = 24;
    }
    public void WALLEClub()
    {
        GetComponent<Catshoot>().catBatPivot.GetComponentInChildren<MeshFilter>().mesh = WALLE;
        GetComponent<Catshoot>().maxForce = 30;
        GetComponent<Catshoot>().maxHeight = 18;
    }
}
