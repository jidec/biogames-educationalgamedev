using UnityEngine;
 using System.Collections;
 
 public class Draggable : MonoBehaviour
 {
     public bool _mouseState;
     public GameObject target;
     public Vector3 screenSpace;
     public Vector3 offset;

	//used to store the last socket the attached object was in
	 public PuzzleSocket lastsocket;
     // Use this for initialization
     void Start()
     {
 
     }
 
     // Update is called once per frame
     void Update()
     {
         // Debug.Log(_mouseState);
		if (Input.GetMouseButtonDown(0))
         {
             RaycastHit hitInfo;
             target = GetClickedObject(out hitInfo);
			if (target != null && (target.tag == "MovableCarbons" || target.tag == "MovableEnzyme" || target.tag == "MovablePowersource"))
             {
                 _mouseState = true;
                 screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                 offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
				//sets socketed molecule of last socket to null when picked up

				if(gameObject.Equals(target))
                    if(lastsocket != null)
				        lastsocket.socketedmolecule = null;
             }
         }
         if (Input.GetMouseButtonUp(0))
         {
             _mouseState = false;
         }
         if (_mouseState)
         {
             //keep track of the mouse position
             var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
 
             //convert the screen mouse position to world point and adjust with offset
             var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
 
             //update the position of the object in the world
             target.transform.position = curPosition;
         }
     }
 
 
     GameObject GetClickedObject(out RaycastHit hit)
     {
         GameObject target = null;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
         {
             target = hit.collider.gameObject;
         }
 
         return target;
     }

	void OnTriggerStay(Collider col)
	{
		//if you let go of the mouse
        if(target != null)
		if(_mouseState == false && target.Equals(gameObject))
		{
			//if you are colliding with a Socket and the Socket is not occupied, stick the Molecule to the Socket
			if (col.gameObject.tag == "Socket" && col.gameObject.GetComponent<PuzzleSocket>().socketedmolecule == null) 
			{
				target.transform.position = new Vector3 (col.transform.position.x, col.transform.position.y, target.transform.position.z);
				col.GetComponent<PuzzleSocket> ().socketedmolecule = gameObject;

				lastsocket = col.GetComponent<PuzzleSocket>();
                if(GetComponent<ExpandedView>() != null)
                    GetComponent<ExpandedView>().startexpand();

				//play the sound
				GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<GlycolysisController>().playSound("Snap");
			}
            else
            {
                if(GetComponent<ExpandedView>() != null)
                  GetComponent<ExpandedView>().startretract();
            }

		}
			
	}
 }