using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaser : MonoBehaviour {
    public int nextLevel;

    public int deliveredCats = 0;
    int allCats;
    public Text deliveredCatsText;
    public Text maxDeliveredCatsText;

    public GameObject victoryText;

    private void Start() {
        GetCats();
    }

    public void UpdateCAts() {
        deliveredCats++;
        deliveredCatsText.text = deliveredCats.ToString();
        if(deliveredCats == allCats) {
            Victory();
        }
    }

    void GetCats() {
        allCats = GameObject.FindGameObjectsWithTag("Cat").Length;
        maxDeliveredCatsText.text = allCats.ToString();
    }

    void Victory() {
        victoryText.SetActive(true);
        StartCoroutine(switchScene(nextLevel));
    }

    IEnumerator switchScene(int index) {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
