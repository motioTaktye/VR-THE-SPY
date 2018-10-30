using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {

    enum STATE
    {
        GAME = 0,
        GAMEOVER
    };

    STATE _gameState;

    // Use this for initialization
    void Awake () {
        _gameState = STATE.GAME;
    }
	
	// Update is called once per frame
	void Update () {
        switch (_gameState)
        {
            case STATE.GAME:
                break;
            case STATE.GAMEOVER:
                break;
        }
	}
}
