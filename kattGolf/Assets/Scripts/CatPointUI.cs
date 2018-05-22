using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPointUI : MonoBehaviour {

    private RectTransform trans;

    public Transform UITransform;

    public Transform playerUI;

    // Use this for initialization
    void Start() {
        trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 directionBetweenUIAndPlayer = playerUI.position - UITransform.position;
        if (Camera.main != null) {
            if (Vector3.Dot(directionBetweenUIAndPlayer, playerUI.transform.forward) < 0) {
                trans.position = Camera.main.WorldToScreenPoint(UITransform.position);
            }

        }
    }
}
