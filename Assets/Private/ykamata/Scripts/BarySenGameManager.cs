using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public enum BarySenGameStatus {TITLE, GAME, RESULT, CREDIT}

public class BarySenGameManager : SingletonMonoBehaviour<BarySenGameManager>
{
	public BarySenGameStatus CurrentStatus { get; set; }

	[SerializeField] UnityEvent OnChangeToTitle;
	[SerializeField] UnityEvent OnChangeToGame;
	[SerializeField] UnityEvent OnChangeToResult;
	[SerializeField] UnityEvent OnChangeToCredit;

	private BarySenGameStatus _beforeStatus;
	private List<Quiz> quizList;
	private Quiz currentQuiz;
	private static System.Random _Rand = new System.Random();
	private int buttonClickCount;
	private bool isCorrect = true;

	public int selectPointer
	{
		get
		{
//			Debug.Log ((int) Mathf.Repeat (buttonClickCount, 3));
			return (int) Mathf.Repeat (buttonClickCount, 3);
		}
	}

	[Header("稼いだBP")]
    public int PlusBP = 0;

	[Header("損したBP")]
	public int MinusBP = 0;

	[Header("ゲームの選択ボタンに置くテクスチャ")]
	public RawImage[] GameButtonTextures;

	[Header("完成後イメージのUI")]
	public GameObject CompletedImage;

	[Header("できたものUI")]
	public GameObject[] ShipPartsImageMadeByBary;

    void OnEnable ()
	{
		init ();
	}

	void Update ()
	{
		checkStatus ();
	}

	private void checkStatus ()
	{
		if (CurrentStatus == _beforeStatus)
			return;

		OnStatusChange (CurrentStatus);
		_beforeStatus = CurrentStatus;
	}

	private void OnStatusChange (BarySenGameStatus status)
	{
		switch (status) {
		case BarySenGameStatus.TITLE:
			OnChangeToTitle.Invoke ();
			Debug.Log ("status is changed to TITLE");
			break;
		case BarySenGameStatus.GAME:
			OnChangeToGame.Invoke ();
			Debug.Log ("status is changed to GAME");
			break;
		case BarySenGameStatus.RESULT:
			OnChangeToResult.Invoke ();
			Debug.Log ("status is changed to RESULT");
			break;
		case BarySenGameStatus.CREDIT:
			OnChangeToCredit.Invoke ();
			Debug.Log ("status is changed to CREDIT");
			break;
		}
	}

	/// <summary>
	/// ゲーム開始時の初期化
	/// </summary>
	private void init ()
	{
		quizList = GetComponent<QuizList> ().quizList;
		QuizInit ();
		CurrentStatus = BarySenGameStatus.TITLE;
		SceneManager.LoadSceneAsync ("Title", LoadSceneMode.Additive);
	}

	/// <summary>
	/// クイズの初期化
	/// </summary>
	public void QuizInit ()
	{
		buttonClickCount = 0;
		currentQuiz = quizList.ElementAt (_Rand.Next (quizList.Count()));
		List<Texture2D> partsTexture = new List<Texture2D> ();
		partsTexture.Add (currentQuiz.TopPart);
		partsTexture.Add (currentQuiz.MiddlePart);
		partsTexture.Add (currentQuiz.BottomPart);
		int n = partsTexture.Count ();
		while (n > 1) {
			n--;
			int k = _Rand.Next (n + 1);  
			Texture2D value = partsTexture [k];  
			partsTexture [k] = partsTexture [n];  
			partsTexture [n] = value; 
		}
		int i = 0;
		foreach (Texture2D tex in partsTexture) {
//			Debug.Log ("set texture:" + tex.name);
			GameButtonTextures[i].texture = tex;
			GameButtonTextures [i].transform.parent.GetComponent<PressButton> ().selectedTexture = tex;
			i++;
		}
	}

	/// <summary>
	/// タイトルからゲームシーンへ。タイトルシーンをアンロード
	/// </summary>
	public void GoToGameFromTitle ()
	{
		SceneManager.UnloadScene ("Title");
		SceneManager.LoadSceneAsync ("Game", LoadSceneMode.Additive);
	}

	/// <summary>
	/// 結果画面からタイトルへ。ゲームシーンをアンロード
	/// </summary>
	public void GoToTitleFromResult ()
	{
		HideResultPanel ();
		SceneManager.UnloadScene ("Game");
		SceneManager.LoadSceneAsync ("Title", LoadSceneMode.Additive);
	}

    /// <summary>
    /// スタッフロールからタイトルへ。スタッフロールをアンロード
    /// </summary>
    public void GoToTitleFromCredit()
    {
        HideResultPanel();
        SceneManager.UnloadScene("StaffRoll");
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
    }

    /// <summary>
    /// 結果画面のパネルを表示
    /// </summary>
    public void ShowResultPanel ()
	{
        //SceneManager.UnloadScene("Game");
        SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
    }

	/// <summary>
	/// 結果画面のパネルを隠す
	/// </summary>
	public void HideResultPanel ()
	{
        //GameObject resultPanel = GameObject.FindWithTag ("ResultPanel");
        //if (resultPanel != null) {
        //	resultPanel.SetActive (false);
        //}

        SceneManager.UnloadScene("Result");
    }

    public void ShowCreditPanel()
    {
        //SceneManager.UnloadScene("Main");
        SceneManager.LoadSceneAsync("StaffRoll", LoadSceneMode.Additive);
    }


    public void HideCreditPanel()
    {
        SceneManager.UnloadScene("StaffRoll");
        //SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
    }

    public void ShowCompletedImage ()
	{
		CompletedImage.SetActive (true);
	}

	public void HideCompletedImage ()
	{
		CompletedImage.SetActive (false);
	}

	public void Select (Texture2D texture2d)
	{
		RawImage rawImage = ShipPartsImageMadeByBary [selectPointer].GetComponent<RawImage> ();
		if (rawImage == null) {
			rawImage = ShipPartsImageMadeByBary [selectPointer].AddComponent<RawImage> ();
		}
		rawImage.texture = texture2d;

		buttonClickCount++;
	}
}
