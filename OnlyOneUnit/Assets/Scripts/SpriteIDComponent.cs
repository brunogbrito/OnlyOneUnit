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
		if (GameManager.instance.NumberOfShapesActive > 4)
		{
			id = SpriteID.spriteIdInstance.GetRandomID();
		}
		else
		{
			id = GameManager.instance.NumberOfShapesActive;
		}
		SetSpriteArt(id);
	}

	public void SetSpriteArt(int newId)
	{
		id = newId;
		spriteRenderer.sprite = SpriteID.spriteIdInstance.GetSprite(newId);

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
