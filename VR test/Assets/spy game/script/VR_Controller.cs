using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Controller : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;       //コントローラの入力用

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();     //ドラッキングオブジェクト追跡
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
