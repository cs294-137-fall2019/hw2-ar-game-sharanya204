
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class CubeScript : MonoBehaviour, OnTouch3D
{
    private Camera arCamera;
    private PlaceGameBoard placeGameBoard;

    // Use this for initialization
    void Start()
    {
        arCamera = GetComponent<ARSessionOrigin>().camera;
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            // Convert the 2d screen point into a ray.
            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            // Check if this hits an object within 100m of the user.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check that the object is interactable.
                if (hit.transform.tag == "CubeFound")
                    // Call the OnTouch function.
                    // Note the use of OnTouch3D here lets us
                    // call any class inheriting from OnTouch3D.
                    hit.transform.GetComponent<OnTouch3D>().OnTouch();
            }
        }
    }

    // Update is called once per frame
    public void OnTouch()
    {
        Debug.Log("Yo");
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("_Color");

        //Checks if cube that's being touched has specified tag
        //If not already touched once before, changes color
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        //rend.material.SetColor("_Color", Color.red);
        StartCoroutine(FlashCubes());
        Debug.Log("found cube");
        
    }

    private IEnumerator FlashCubes()
    {
        

        float count = 2f;
        for (int i = 0; i < 2000; i++)
        {
            while (count >= 0)
            {
                //Also changes color of the other cubes with the tag for two seconds
                GameObject[] gos = GameObject.FindGameObjectsWithTag("CubeFound");
                print(GameObject.FindGameObjectsWithTag("CubeFound"));
                foreach (GameObject go in gos)
                {
                    Renderer rend2 = GetComponent<Renderer>();
                    rend2.material.shader = Shader.Find("_Color");
                    rend2.material.SetColor("_Color", Color.red);
                }
                count -= Time.smoothDeltaTime;
                yield return null;
            }
        }
    }
}
