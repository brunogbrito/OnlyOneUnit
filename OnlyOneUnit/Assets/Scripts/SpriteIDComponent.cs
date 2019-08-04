using UnityEngine;

public class SpriteIDComponent : MonoBehaviour
{
	public int SpriteIdValue { get { return id; } private set { } }

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	private int id;

	private PolygonCollider2D polygonCollider;

	private void Start()
	{
		id = SpriteID.spriteIdInstance.GetRandomID();

		SetSpriteArt(id);
	}

	public void SetSpriteArt(int newId)
	{
		id = newId;
		spriteRenderer.sprite = SpriteID.spriteIdInstance.GetRandomSprite(newId);

		if (polygonCollider == null)
		{
			polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
		}
		else
		{
			Destroy(polygonCollider);
			polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
		}
	}
}
