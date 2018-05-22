using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public int deathTime = 1;
	void Start () {
        Destroy(gameObject, deathTime);
	}

}
