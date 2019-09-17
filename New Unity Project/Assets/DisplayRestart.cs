using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DisplayRestart : MonoBehaviour
{
    float displayTime = 45;
    float timeRemaining;
    private PlaceGameBoard placeGameBoard;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = displayTime;
        placeGameBoard = GetComponent<PlaceGameBoard>();
        go = GameObject.Find("Cube");
    }

    // Update is called once per frame
    public void Update()
    {
        //if (placeGameBoard.Placed())
        //{
            if (timeRemaining <= 0)
            {
                Text t1 = gameObject.GetComponentInChildren<Text>();
                t1.text = "Hit this button to restart";
                //gameObject.GetComponent<Text>().text = "Hit this button to restart";
                gameObject.GetComponent<Button>().enabled = true;
                gameObject.GetComponent<Button>().onClick.AddListener(restartingscene);

                foreach (Transform child in GameObject.Find("Cube").transform)
                    child.gameObject.SetActive(false);

            }
            else
            {
                Text t2 = gameObject.GetComponentInChildren<Text>();
                t2.text = timeRemaining.ToString("0");
                timeRemaining -= Time.deltaTime;

                //gameObject.GetComponent<Text>().text = timeRemaining.ToString();
            }
        //}
    }

    private void restartingscene()
    {
        SceneManager.LoadScene("untitled");
    }

}
