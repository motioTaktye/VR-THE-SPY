using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {
    public GameObject ControllerLeftObj;
    public GameObject ControllerRightObj;
    Hand ControllerLeftHand;
    Hand ControllerRightHand;
    public GameObject _warningText;
    Renderer rd;
    bool isDead;

    public Material normalMAT;
    public Material canCatchMAT;

    Vector3 originalScale;

    // Use this for initialization
    void Awake () {
        ControllerLeftHand = ControllerLeftObj.GetComponent<Hand>();
        ControllerRightHand = ControllerRightObj.GetComponent<Hand>();
        rd = GetComponent<Renderer>();
        isDead = false;
        originalScale = transform.lossyScale;
    }
	
	// Update is called once per frame
	void Update () {
        float distLeft = Vector3.Distance(transform.position, ControllerLeftObj.GetComponent<Hand>().HandPosition);
        float distRight = Vector3.Distance(transform.position, ControllerRightObj.GetComponent<Hand>().HandPosition);

        //キャッチ範囲内の時
        bool isSmallerThanCatchDistL = distLeft < ControllerLeftHand.CATCH_DISTANCE;
        bool isSmallerThanCatchDistR = distRight < ControllerRightHand.CATCH_DISTANCE;

        if (!ControllerLeftHand.IsGetTreasureFlag && !ControllerRightHand.IsGetTreasureFlag)
        {
            if (isSmallerThanCatchDistL || isSmallerThanCatchDistR)
            {
                rd.material = canCatchMAT;
            }
            else
            {
                rd.material = normalMAT;
            }
        }
        else
        {
            rd.material = normalMAT;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (ControllerLeftHand.IsGetTreasureFlag || ControllerRightHand.IsGetTreasureFlag)
            {
                //TODO::ゲームオーバー
                _warningText.GetComponent<WarningText>().ShowText();
                isDead = true;
            }
        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    public Vector3 OriginalScale
    {
        get
        {
            return originalScale;
        }
    }

    public void StayScale()
    {
        Vector3 loss = transform.lossyScale;
        Vector3 local = transform.localScale;

        transform.localScale = new Vector3( transform.localScale.x / transform.lossyScale.x * originalScale.x, 
            transform.localScale.y / transform.lossyScale.y * originalScale.y,
            transform.localScale.z / transform.lossyScale.z * originalScale.z);
    }
}
