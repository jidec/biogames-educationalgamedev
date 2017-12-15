using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomIntoPoint : MonoBehaviour {

	public float minZoom;
	public float maxZoom;

	public float zoomspeed;

	public Vector3 zoomposition;

	public bool zoom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(zoom)
		ZoomOrthoCamera(zoomposition, zoomspeed);
	}

	// Ortographic camera zoom towards a point (in world coordinates). Negative amount zooms in, positive zooms out
     // TODO: when reaching zoom limits, stop camera movement as well
     void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
     {
         // Calculate how much we will have to move towards the zoomTowards position
         float multiplier = (1.0f / Camera.main.orthographicSize * amount);
 
         // Move camera
         Camera.main.transform.position += (zoomTowards - transform.position) * multiplier; 
 
         // Zoom camera
         Camera.main.orthographicSize -= amount;
 
         // Limit zoom
         Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
     }
}
