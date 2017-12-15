using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShake : MonoBehaviour {

	public bool shake = true;
	public bool shakeforward = true;
	public bool shakeback;

	public int shakecount = 0;
	public RectTransform myrect;
	public Vector3 initialposition;
	// Use this for initialization
	void Start () {
		myrect = GetComponent<RectTransform>();
		initialposition = GetComponent<RectTransform>().localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(shake)
		{
			if(shakeforward)
			{
				myrect.transform.localPosition += new Vector3(1f,0);
				if(myrect.transform.localPosition.x > initialposition.x + 3f)
				{
					shakeforward = false;
					shakeback = true;
				}
			}
			if(shakeback)
			{
				myrect.transform.localPosition -= new Vector3(1f,0);
				if(myrect.transform.localPosition.x < initialposition.x - 3f)
				{
					shakeback = false;
					shakeforward = true;
					shakecount++;
				}
			}
			if(shakecount > 2)
			{
				shake = false;
				shakecount = 0;
			}
		}
		else
		{
			myrect.transform.localPosition = initialposition;
			shakecount = 0;
		}
	}
}
