using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {
    [System.Serializable]
    public struct RorateState
    {
        public bool isRorate;                 //回転するか
        public bool isRorateDirectionIsLeft;  //回転方向は左なのか
        [Range(0, 100)]
        public float speedRotate;             //回転速度
    }

    [System.Serializable]
    public struct MoveState
    {
        public bool isMove;                    //移動するか
        [Range(0, 10.0f)]
        public float moveSpeed;                //移動速度
        public Vector3[] goalPositions;        //移動先の位置
        [Range(0, 20)]
        public float timeGoalWait;             //ゴールに着いた後の待ち時間
    }

    [SerializeField]
    RorateState _rotateState;            //回転ステート
    [SerializeField]
    MoveState _moveState;

    //private変数
    Vector3 _originPosition;                  //初期位置
    bool _isAscendingOrderGoalPosition;       //昇順
    int _goalPositionNumber;    //ゴールのナンバー
    float _timeStopRot;         //回転止まる時間
    float _timeStopMove;        //移動停止時間

    //const変数
    const float DIST_IN_GOAL = 0.01f; 

    // Use this for initialization
    void Awake() {
        _originPosition = transform.position;
        _isAscendingOrderGoalPosition = true;

        //移動方向初期化
        if (_moveState.goalPositions != null && _moveState.goalPositions.Length > 0)
        {
            _goalPositionNumber = 1;
        }

        _timeStopRot = 0;
        _timeStopMove = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Move();         //移動
        Rotate();       //回転
    }

    void Rotate()
    {
        //回転しないなら
        if (!_rotateState.isRorate)
        {
            return;
        }

        //止まる時間が0以上の場合、カウントダウンして、何もしない
        if (_timeStopRot > 0)
        {
            _timeStopRot -= Time.deltaTime;
            return;
        }

        //回転速度を決める
        float rotSpeed;
        if (_rotateState.isRorateDirectionIsLeft)
            rotSpeed = -_rotateState.speedRotate;
        else
            rotSpeed = _rotateState.speedRotate;

        //回転する
        transform.Rotate(new Vector3(1, 0, 0), rotSpeed);
    }

    void Move()
    {
        //移動ステート
        if (!_moveState.isMove)
        {
            return;
        }

        //止まる時間が0以上の場合、カウントダウンして、何もしない
        if (_timeStopMove > 0)
        {
            _timeStopMove -= Time.deltaTime;
            return;
        }

        //移動目的地をチェック
        Vector3 goalPosition;
        if (_goalPositionNumber == 0 && !_isAscendingOrderGoalPosition)
        {
            goalPosition = _originPosition;
        }
        else
        {
            goalPosition = _moveState.goalPositions[_goalPositionNumber - 1];
        }

        Vector3 moveVec = (goalPosition - transform.position).normalized;
        transform.position += _moveState.moveSpeed * moveVec;

        //目標につく判定
        float Dist = Vector3.Distance(goalPosition, transform.position);
        if (Dist < DIST_IN_GOAL + _moveState.moveSpeed)
        {
            //次の目的地を指定
            if (_isAscendingOrderGoalPosition)
            {
                if (_goalPositionNumber == _moveState.goalPositions.Length)
                {
                    _isAscendingOrderGoalPosition = false;
                    _goalPositionNumber--;
                }
                else
                {
                    _goalPositionNumber++;
                }
            }
            else
            {
                if (_goalPositionNumber == 0)
                {
                    _isAscendingOrderGoalPosition = true;
                    _goalPositionNumber++;
                }
                else
                {
                    _goalPositionNumber--;
                }
            }
            
            //待ち時間をセット
            _timeStopMove = _moveState.timeGoalWait;
        }
    }
}
