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
	private GameObject startScreen;

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
