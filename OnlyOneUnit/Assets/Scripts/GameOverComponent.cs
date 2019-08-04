using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameOverComponent : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI message;

	[SerializeField]
	private CanvasGroup gameOverCanvasGroup;

	private void Start()
	{
		message.text = GameManager.instance.PlayerScore.ToString();
		gameOverCanvasGroup.DOFade(0f, 0f);
		gameOverCanvasGroup.DOFade(1f, 1f);
	}
}
