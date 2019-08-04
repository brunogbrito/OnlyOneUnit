using UnityEngine;

public class SpriteIDComponent : MonoBehaviour
{
	public int SpriteIdValue { get { return id; } private set { } }

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	private int id;

	private void Start()
	{
		id = SpriteID.spriteIdInstance.GetRandomID();

		SetSpriteArt(id);
	}

	public void SetSpriteArt(int newId)
	{
		spriteRenderer.sprite = SpriteID.spriteIdInstance.GetRandomSprite(newId);
	}
}
