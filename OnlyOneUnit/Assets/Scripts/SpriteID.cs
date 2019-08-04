using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteID : MonoBehaviour
{
	[SerializeField]
	private List<Sprite> spritesIds;

	public static SpriteID spriteIdInstance;

	private static int listIdIndex;

	public void Awake()
	{
		spriteIdInstance = this;
	}

	public int GetRandomID()
	{
		var randomIndex = Random.Range(0, spritesIds.Count);
		return randomIndex;
	}

	public Sprite GetRandomSprite(int index)
	{
		var selectedSprite = spritesIds[index];
		return selectedSprite;
	}
}
