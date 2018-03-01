using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWheelCameraZoom : MonoBehaviour {

 float scrollSpeed = -10f;
 
 void Update()
 {
    Camera cam = GetComponent<Camera>();
    if(Input.GetAxis("Mouse ScrollWheel") > 0)
    {
     float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
         if(cam.orthographicSize > 8)
         {
	        cam.orthographicSize += scroll;
         }
     }

    if(Input.GetAxis("Mouse ScrollWheel") < 0)
    {
    float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
         if(cam.orthographicSize < 31)
         {
	          cam.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
         }
    }
 }
}
