using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleEnd : MonoBehaviour {

	[SerializeField]
	private float fadeSecond;
	[SerializeField]
	private GameObject[] titles;

	private bool end;
	private float sped;
	// Use this for initialization
	void Start () {
		end = false;
		sped = 1.0f / fadeSecond / 60.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(end)
		{
			for(int i = 0; i < titles.Length; ++i)
			{
				Color c = titles[i].GetComponent<MeshRenderer>().material.color;
				c.a -= sped;
				titles[i].GetComponent<MeshRenderer>().material.color = new Color(c.r, c.g, c.g, c.a);
			}
		}

		if(Input.GetKeyDown(KeyCode.Return))
		{
			endTitle();
		}

	}

	public void endTitle()
	{
		end = true;
	}
}
