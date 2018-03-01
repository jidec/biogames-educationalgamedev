using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEnterExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        isOver = true;
		print("entered");
		GameObject.FindGameObjectWithTag("MoleculeView").GetComponent<MoleculeView>().lastmousedover = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }


	//TODO rename this script, set spawn location to a public offset from the cameraposition
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(isOver)
			{
				GameObject newmolecule = Instantiate((GameObject) Resources.Load(gameObject.name), gameObject.transform.position, Quaternion.identity);
				newmolecule.transform.position = Camera.main.ScreenToWorldPoint(this.transform.position);
				newmolecule.transform.position = new Vector3(0,0,3);
				newmolecule.GetComponent<Draggable>()._mouseState = true;
				newmolecule.GetComponent<Draggable>().target = newmolecule;
				//set new molecule to correct position
			}
		}
	}
}