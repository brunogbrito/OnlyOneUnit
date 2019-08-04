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
		if (gameStarted && numberOfShapesActive > 0)
		{
			StartCountdown();
		}
		else if (numberOfShapesActive == 0)
		{
			gameStarted = false;
			NextLevel();
		}
	}

	private void StartCountdown()
	{
		timeLeft -= Time.deltaTime * countdownSpeed;
		if (timeLeft < levelDurationCountdown)
		{
			GameOver();
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
		//startScreen.SetActive(true);
	}
	private void StartGame()
	{
		//colorIdComponent.SetColorIdList();
		//spriteIdComponent.SetSpriteIdList();
		timeLeft = levelDurationCountdown;
		Cursor.visible = false;
		activeShapesColorIDList.Clear();
		activeShapesSpriteIDList.Clear();
		numberOfShapesActive = 0;
		currentLevel++;
		InstantiatePrefab(currentLevel);
		ValidateMatch();

	}

	private void NextLevel()
	{

		StartGame();
	}

	private void InstantiatePrefab(int levelProgression)
	{
		for (int i = 0; i < levelProgression + 4 ; i++)
		{
			var gameObj = Instantiate(shapesPrefab, RandomizePosition(), RandomizeRotation());
			activeShapesColorIDList.Add(gameObj.GetComponent<ColorIdComponent>());
			activeShapesSpriteIDList.Add(gameObj.GetComponent<SpriteIDComponent>());
			numberOfShapesActive++;
		}
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

	private void GenerateNewMatch()
	{
		Debug.Log("NewMatch");
		foreach (var item in activeShapesColorIDList)
		{
			Destroy(item.gameObject);
		}
		activeShapesColorIDList.Clear();
		activeShapesSpriteIDList.Clear();
		numberOfShapesActive = 0;
		InstantiatePrefab(currentLevel);
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

	public void DecreaseNumberOfActiveShapes()
	{
		numberOfShapesActive--;
	}

	public void GameOver()
	{
		//gameStarted = false;
	}

}
