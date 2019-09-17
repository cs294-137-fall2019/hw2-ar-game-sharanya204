using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restarting : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*        timeLeft -= Time.deltaTime;
                timer.text = (timeLeft).ToString("0");
                if (timeLeft < 0)
                {
                    //display restart button
                    this.gameObject.SetActive(true);
                    //on click of button
                    //
                }*/
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene("untitled");
    }
}
