using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPointUI : MonoBehaviour {

    private RectTransform trans;

    public Transform UITransform;

    public Transform targetTransform;

    // Use this for initialization
    void Start() {
        trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 directionBetweenUIAndPlayer = targetTransform.position - UITransform.position;
        if (Camera.main != null) {
            if (Vector3.Dot(directionBetweenUIAndPlayer, targetTransform.transform.forward) < 0) {
                trans.position = Camera.main.WorldToScreenPoint(UITransform.position);
            }

        }
    }
}
