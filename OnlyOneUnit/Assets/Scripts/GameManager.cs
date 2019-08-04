using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private ColorIdComponent colorIdComponent;

	void Awake()
	{
		Initialize();
	}

    void Start()
    {
		StartGame();
    }

	private void Initialize()
	{
		colorIdComponent.SetColorIdList();
	}
	private void StartGame()
	{
		Cursor.visible = false;
	}

}
