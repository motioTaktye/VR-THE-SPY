using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnim : MonoBehaviour 
{
    private Animator Anim;  //Animatorコンポーネント

    /*---------------------------
     初期化
     ---------------------------*/
	void Start () 
    {
        Anim = GetComponent<Animator>();    //自分のAnimatorコンポーネントを取得
	}//end_of_start

    /*---------------------------
     更新
     ---------------------------*/
	void Update () 
    {
        /*動作確認用。
        if (Input.GetMouseButton(0))
        {
            AnimFist(true);
        }
        else
        {
            AnimFist(false);
        }
        */
	}

    /*---------------------------
     関数名:握る処理 
     引数:true  = 握る
         false = ひらく
     ---------------------------*/
    void AnimFist(bool State)
    {
        if (State)
        {
            Anim.SetFloat("FistState",1.0f);
           //print("閉じる");
            return;
        }
        else
        {
            Anim.SetFloat("FistState",0.0f);
            //print("開く");
            return;
        }//end_of_if
    }//end_of_Func"AnimFist"
}
