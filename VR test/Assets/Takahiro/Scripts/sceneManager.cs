using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour {

	public enum SCENE
	{
		SCENE_TITLE = 0,
		SCENE_GAME,
		SCENE_RESULT,
		SCENE_MAX
	}

	[SerializeField]
	private Image fadeImage;
	[SerializeField]
	private float fadeSecond;

	private bool fade;
	private bool fadeIn;
	private float fadeSpeed;
	private SCENE sceneNow;
	private SCENE sceneBefor;



	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		sceneNow = SCENE.SCENE_TITLE;
		sceneBefor = SCENE.SCENE_TITLE;
		fade = true;
		fadeIn = true;
		fadeSpeed = 1.0f / fadeSecond / 60.0f;
	}

	private void Start()
	{
		sceneNow = SCENE.SCENE_TITLE;
		sceneBefor = SCENE.SCENE_TITLE;
		fadeIn = true;
		fade = true;
		fadeSpeed = 1.0f / fadeSecond / 60.0f;
		// 即座に画面を真っ白に
		SteamVR_Fade.Start(Color.black, 0f);
		// 2秒かけてクリアに戻す
		SteamVR_Fade.Start(Color.clear, 3f);
	}

	private void Update()
	{
        /*
		if(Input.GetKeyDown(KeyCode.Return))
		{
			gameOver();
		}
        */
	}

	public void SceneChange(SCENE scene)
	{
		sceneBefor = sceneNow;
		sceneNow = scene;
	}



	public void gameOver()
	{
		// 即座に画面を真っ白に
		SteamVR_Fade.Start(Color.black, 0f);
		// 現在のScene名を取得する
		Scene loadScene = SceneManager.GetActiveScene();
		// Sceneの読み直し
		SceneManager.LoadScene(loadScene.name);
	}


}
