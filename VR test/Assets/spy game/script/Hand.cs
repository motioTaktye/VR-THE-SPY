using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour {
    GameObject Treasure;
    bool IsGetTreasure;
    bool IsDead;
    bool IsHitByLazer;
    SteamVR_Controller.Device Controller;
    public GameObject GameOverText;

    public float CATCH_DISTANCE = 5.0f;
    public float TreasureRelativeDistZ = 1.0f;
    public float offsetY = 2;

    // Use this for initialization
    void Awake () {
        IsGetTreasure = false;
        Treasure = GameObject.Find("treasure");
        IsDead = false;
        IsHitByLazer = false;
        GameOverText.SetActive(false);
    }

    void Start()
    {
        Controller = transform.parent.GetComponent<VR_Controller>().Controller;
    }

    // Update is called once per frame
    void Update ()
    {
        //UIを表示
        if (IsHitByLazer)
        {
            GameOverText.SetActive(true);
        }
        else
        {
            GameOverText.SetActive(false);
        }

        Vector3 handPosition = transform.position + transform.up * offsetY;
        float dist = Vector3.Distance(transform.position, Treasure.transform.position);
        if (dist < CATCH_DISTANCE)
        {
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                //Treasure.transform.parent = transform;
                //Treasure.transform.localPosition = new Vector3(0,0, TreasureRelativeDistZ);
                //Treasure.transform.rotation = Quaternion.identity;
                //Treasure.GetComponent<Treasure>().StayScale();
                //Treasure.transform.rotation = Quaternion.identity;
                IsGetTreasure = true;
            }
        }

        if (IsGetTreasure)
        {
            Treasure.transform.position = transform.position + transform.up * offsetY;
            Treasure.transform.rotation = transform.rotation;
        }

        /*
        if (Treasure.GetComponent<Treasure>().IsDead || IsDead)
        {
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                SceneManager.LoadScene("spy");
            }
        }
        */
        IsHitByLazer = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            IsHitByLazer = true;
        }
    }

    public bool IsGetTreasureFlag
    {
        get
        {
            return IsGetTreasure;
        }
    }
}
