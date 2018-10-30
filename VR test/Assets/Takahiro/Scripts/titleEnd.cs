using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleEnd : MonoBehaviour {

	[SerializeField]
	private float fadeSecond;
	[SerializeField]
	private GameObject[] titles;

	private bool isEnd;
	private float sped;
    SteamVR_Controller.Device _controller;

    // Use this for initialization
    void Start () {
        isEnd = false;
		sped = 1.0f / fadeSecond / 60.0f;
        _controller = transform.parent.GetComponent<VR_Controller>().Controller;
    }
	
	// Update is called once per frame
	void Update () {
        if (isEnd)
		{
            for (int i = 0; i < titles.Length; ++i)
			{
				Color c = titles[i].GetComponent<MeshRenderer>().material.color;
				c.a -= sped;
				titles[i].GetComponent<MeshRenderer>().material.color = new Color(c.r, c.g, c.g, c.a);
			}
		}

		if(Input.GetKeyDown(KeyCode.Return) || _controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
            EndTitle();
		}
    }

	void EndTitle()
	{
        isEnd = true;
    }
}
