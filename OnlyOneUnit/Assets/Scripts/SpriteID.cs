using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteID : MonoBehaviour
{
	[SerializeField]
	private List<SpriteIDType> spritesIds;

	public static SpriteID spriteIdInstance;

	private int listIdIndex;

	private static SpriteIDType currentSpriteId;

	public void Awake()
	{
		spriteIdInstance = this;
	}

	public void SetSpriteIdList()
	{
		listIdIndex = Random.Range(0, spritesIds.Count);
		currentSpriteId = spritesIds[listIdIndex];
	}

	public int GetRandomID()
	{
		var randomIndex = Random.Range(0, currentSpriteId.shapes.Length);
		return randomIndex;
	}

	public Sprite GetSprite(int index)
	{
		var selectedSprite = currentSpriteId.shapes[index];
		return selectedSprite;
	}
}
