using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MenuComponent : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup gameOverCanvasGroup;

	[SerializeField]
	private GameObject startScreen;

	[SerializeField]
	private TextMeshProUGUI message;

	private void Start()
	{
		gameOverCanvasGroup.DOFade(0f, 0f);
		gameOverCanvasGroup.DOFade(1f, 1f);
	}

	public void StartGame()
	{
		GameManager.instance.StartGame();
		startScreen.SetActive(false);
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(0);
	}
}
