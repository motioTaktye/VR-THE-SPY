using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour {
    [SerializeField]
    GameObject _treasure;                   //宝オブジェクト
    [SerializeField]
    GameObject _warningText;
    bool _isGetTreasure;
    bool _isDead;
    SteamVR_Controller.Device _controller;

    public float CATCH_DISTANCE = 5.0f;
    public float TreasureRelativeDistZ = 1.0f;
    public float offsetY = 2;
    public Vector3 HandPosition;

    // Use this for initialization
    void Awake () {
        _isGetTreasure = false;
        _isDead = false;
    }

    void Start()
    {
        _controller = transform.parent.GetComponent<VR_Controller>().Controller;
    }

    // Update is called once per frame
    void Update ()
    {
        //手の先端の位置で宝物との距離を取って、範囲内なら、キャッチ可能
        HandPosition = transform.position + transform.up * offsetY;
        float dist = Vector3.Distance(HandPosition, _treasure.transform.position);

        //距離内ならキャッチできる
        Debug.Log(dist);
        if (dist < CATCH_DISTANCE)
        {
            //キャッチボタン押したらキャッチフラグが立つ
            if (_controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                _isGetTreasure = true;
            }
        }

        //宝物を手にくつっける
        TreasureOnHand();
    }

    //宝物が手にキャッチされてる
    void TreasureOnHand()
    {
        if (_isGetTreasure)
        {
            _treasure.transform.position = transform.position + transform.up * offsetY;
            _treasure.transform.rotation = transform.rotation;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _warningText.GetComponent<WarningText>().ShowText();
        }
    }

    public bool IsGetTreasureFlag
    {
        get
        {
            return _isGetTreasure;
        }
    }
}
