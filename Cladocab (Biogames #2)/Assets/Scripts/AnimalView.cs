using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalView : MonoBehaviour {

    public GameObject speechbubble;
    
    // Update is called once per frame
    void Update () {
    }

    //called by controller
    public void changeOrganism(string organism)
    {
		foreach (Transform child in transform) 
        {
            if (child.gameObject.name == organism) 
            {
                //move to front of UI
                child.transform.SetAsLastSibling ();
            }
        }
    }
}


