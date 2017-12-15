using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSprite : MonoBehaviour {

	public GameObject sprite;

	private Color prevcolor;

	public Color newcolor;

	// Use this for initialization
	void Start () {
		prevcolor = sprite.GetComponent<SpriteRenderer>().color;
	}

	void OnMouseOver()
	{
		sprite.GetComponent<SpriteRenderer>().color = newcolor;
	}

	void OnMouseExit()
	{
		sprite.GetComponent<SpriteRenderer>().color = prevcolor;
	}

}
