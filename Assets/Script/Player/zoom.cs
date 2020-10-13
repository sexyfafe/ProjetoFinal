using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public int zoom2 = 20;
    public int normal = 60;
    public float smooth = 5;
    public GameObject crosshair1;
    private bool isZoomed = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
        }
        if (isZoomed)
        {
            crosshair1.SetActive(true);
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom2, Time.deltaTime * smooth);
        }
        else
        {
            crosshair1.SetActive(false);
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}
