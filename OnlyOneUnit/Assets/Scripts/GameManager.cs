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

	public static GameManager instance;

	void Awake()
	{
		instance = this;
		Initialize();
	}

    void Start()
    {
		StartGame();
    }

	private void Initialize()
	{
		colorIdComponent.SetColorIdList();
		spriteIdComponent.SetSpriteIdList();
	}
	private void StartGame()
	{
		Cursor.visible = false;
	}

	public void GameOver()
	{

	}

}
