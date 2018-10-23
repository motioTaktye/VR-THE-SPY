using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPrefubInstancer : MonoBehaviour {

	[SerializeField]
	private Transform parent;
	[SerializeField]
	private GameObject[] obj;

	// Use this for initialization
	void Start () {
		// 座標を見ながら生成
		for(int i = 0; i < obj.Length; ++i)
		{
			// 初期のカメラ座標に+して表示すれば終わり
			GameObject.Instantiate(obj[i], this.transform.position, Quaternion.identity , parent);
		}
	}
	
}
