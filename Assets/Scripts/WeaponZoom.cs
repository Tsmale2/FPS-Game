using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut = 60f;

    [SerializeField] Camera fpsCam;

    [SerializeField] bool zoomToggle = false;

    private void OnDisable()
    {
        zoomToggle = false;
        fpsCam.fieldOfView = zoomOut;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (zoomToggle == false)
            {
                zoomToggle = true;
                fpsCam.fieldOfView = zoomIn;
            }
            
            else if (zoomToggle == true)
            {
                zoomToggle = false;
                fpsCam.fieldOfView = zoomOut;
            }
                

        }
    }
}
