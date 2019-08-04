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


	public static GameManager instance;

	private float timeLeft;

	private bool gameStarted = false;

	private int currentLevel;

	private int numberOfShapesActive;

	private List<ColorIdComponent> activeShapesColorIDList;

	private List<SpriteIDComponent> activeShapesSpriteIDList;

	private bool isPossibleMatch;

	public int NumberOfShapesActive { get { return numberOfShapesActive; } private set { } }


	void Awake()
	{
		instance = this;
		Initialize();
	}

    void Start()
    {
		StartGame();
	}

	private void Update()
	{

		if (gameStarted)
		{
			if (numberOfShapesActive > 0)
			{
				StartCountdown();
				Debug.Log("1");
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
	private void StartGame()
	{
		//colorIdComponent.SetColorIdList();
		//spriteIdComponent.SetSpriteIdList();
		timeLeft = levelDurationCountdown;
		Cursor.visible = false;
		ClearBoard();
		currentLevel++;
		InstantiatePrefab(currentLevel);
	}

	private void NextLevel()
	{
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
		CheckMatchPossibilities();
	}

	public void GameOver()
	{
		ClearBoard();
		Initialize();
		StartGame();
	}

}
