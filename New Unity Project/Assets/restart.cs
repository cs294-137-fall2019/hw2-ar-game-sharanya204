using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    public float timeLeft = 5.0f;
    public Text timer; // countdown

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        //Restart();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //display restart button
            this.gameObject.SetActive(true);
            //on click of button
            //
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("untitled");
    }
}
