using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[Header("IDs")]
	[SerializeField]
	private ColorId colorIdComponent;

	[SerializeField]
	private SpriteID spriteIdComponent;

	[Header("UI")]
	[SerializeField]
	private GameObject startScreen;

	[SerializeField]
	private GameObject gameOverScreen;

	[Header("Game Settings")]
	[SerializeField]
	private ColorIdComponent playerColorIDComponent;

	[SerializeField]
	private SpriteIDComponent playerSpriteIDComponent;

	[SerializeField]
	private float levelDurationCountdown = 5f;

	[SerializeField]
	private float countdownSpeed = 1f;

	[SerializeField]
	private GameObject shapesPrefab;

	[SerializeField]
	private ColorIdComponent bg;


	public static GameManager instance;

	private float timeLeft;

	private bool gameStarted = false;

	private int currentLevel;

	private int numberOfShapesActive;

	private List<ColorIdComponent> activeShapesColorIDList;

	private List<SpriteIDComponent> activeShapesSpriteIDList;

	private bool isPossibleMatch;

	private int playerScore;

	public int NumberOfShapesActive { get { return numberOfShapesActive; } private set { } }

	public int PlayerScore { get { return playerScore; } private set { } }

	void Awake()
	{
		instance = this;
		Initialize();
	}

	private void Update()
	{

		if (gameStarted)
		{
			if (numberOfShapesActive > 0)
			{
				StartCountdown();
			}
			if (numberOfShapesActive == 0)
			{
				gameStarted = false;
				NextLevel();
				Debug.Log("2");
			}
			if (!isPossibleMatch)
			{
				gameStarted = false;
				GameOver();
				Debug.Log("3");
			}
		}
	}

	private void StartCountdown()
	{
		timeLeft -= Time.deltaTime * countdownSpeed;
		if (timeLeft < levelDurationCountdown)
		{

		}
	}

	private void Initialize()
	{
		colorIdComponent.SetColorIdList();
		spriteIdComponent.SetSpriteIdList();
		currentLevel = 0;
		numberOfShapesActive = 0;
		activeShapesColorIDList = new List<ColorIdComponent>();
		activeShapesSpriteIDList = new List<SpriteIDComponent>();
		isPossibleMatch = true;
		//startScreen.SetActive(true);
	}
	public void StartGame()
	{
		ClearBoard();
		numberOfShapesActive = 0;
		timeLeft = levelDurationCountdown;
		activeShapesColorIDList = new List<ColorIdComponent>();
		activeShapesSpriteIDList = new List<SpriteIDComponent>();
		Cursor.visible = false;
		isPossibleMatch = true;
		currentLevel++;
		InstantiatePrefab(currentLevel);
	}

	private void NextLevel()
	{
		colorIdComponent.SetColorIdList();
		spriteIdComponent.SetSpriteIdList();
		bg.SetRandomID();
		playerColorIDComponent.SetRandomID();
		//Debug.Log("here");
		StartGame();
	}

	private void InstantiatePrefab(int levelProgression)
	{
		for (int i = 0; i < levelProgression + 10 ; i++)
		{
			var gameObj = Instantiate(shapesPrefab, RandomizePosition(), RandomizeRotation());
			activeShapesColorIDList.Add(gameObj.GetComponent<ColorIdComponent>());
			activeShapesSpriteIDList.Add(gameObj.GetComponent<SpriteIDComponent>());
			numberOfShapesActive++;
		}
		Invoke("ValidateMatch", 1f);
	}

	private void ValidateMatch()
	{
		bool isValid = false;

		foreach (var item in activeShapesColorIDList)
		{
			if (playerColorIDComponent.ColorIdValue == item.ColorIdValue)
			{
				isValid = true;
			}
		}

		foreach (var item in activeShapesSpriteIDList)
		{
			if (playerSpriteIDComponent.SpriteIdValue == item.SpriteIdValue)
			{
				isValid = true;
			}
		}

		if (!isValid)
		{
			GenerateNewMatch();
		}
		else
		{
			gameStarted = true;
		}
	}

	private void CheckMatchPossibilities()
	{
		bool isValid = false;

		foreach (var item in activeShapesColorIDList)
		{
			if (playerColorIDComponent.ColorIdValue == item.ColorIdValue)
			{
				isValid = true;
			}
		}

		foreach (var item in activeShapesSpriteIDList)
		{
			if (playerSpriteIDComponent.SpriteIdValue == item.SpriteIdValue)
			{
				isValid = true;
			}
		}

		isPossibleMatch = isValid;
		Debug.Log(isValid);
	}

	private void GenerateNewMatch()
	{
		foreach (var item in activeShapesColorIDList)
		{
			Destroy(item.gameObject);
		}
		activeShapesColorIDList.Clear();
		activeShapesSpriteIDList.Clear();
		numberOfShapesActive = 0;
		InstantiatePrefab(currentLevel);
	}

	private void ClearBoard()
	{
		foreach (var item in activeShapesColorIDList)
		{
			Destroy(item.gameObject);
		}
		activeShapesColorIDList.Clear();
		activeShapesSpriteIDList.Clear();
		numberOfShapesActive = 0;
	}

	private Vector3 RandomizePosition()
	{
		Vector3 position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4f), 0f);

		return position;
	}

	private Quaternion RandomizeRotation()
	{
		Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 179f));
		return rotation;
	}

	public void DecreaseNumberOfActiveShapes(SpriteIDComponent sprite, ColorIdComponent color)
	{
		numberOfShapesActive--;
		activeShapesColorIDList.Remove(color);
		activeShapesSpriteIDList.Remove(sprite);
		AddScore();
		CheckMatchPossibilities();
	}

	private void AddScore()
	{
		playerScore = playerScore + 10;
	}

	public void GameOver()
	{
		Cursor.visible = true;
		gameOverScreen.SetActive(true);
	}

}
