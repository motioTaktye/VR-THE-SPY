using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningText : MonoBehaviour {
    [SerializeField][Range(0,1.0f)]
    float _textAlphaDecreseSpeed = 0;
    Text _text;

	// Use this for initialization
	void Awake () {
        _text = GetComponent<Text>();
        NoShowText();
    }
	
	// Update is called once per frame
	void Update () {
        //透明度を減らす
        float nowAlpha = _text.color.a;
        nowAlpha -= _textAlphaDecreseSpeed;
        if (nowAlpha < 0)
        {
            nowAlpha = 0;
        }

        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, nowAlpha);
    }

    //テキスト表示
    public void ShowText()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b,1.0f);
    }

    //テキスト非表示
    public void NoShowText()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0.0f);
    }
}
