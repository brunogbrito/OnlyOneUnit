using UnityEngine;
using UnityEngine.UI;

public class ColorIdComponent : MonoBehaviour
{
	public int ColorIdValue	{ get {	return id;}	private set { } }

	[SerializeField]
	private SpriteRenderer sprite;

	[SerializeField]
	private Image image;

	[SerializeField]
	private bool isCollectable;

	[SerializeField]
	private int id;

	private void Start()
	{
		if (isCollectable)
		{
			id = Random.Range(1, 4);
		}
		SetSpriteColor(id);
	}

	public void SetRandomID()
	{
		Start();
	}
	public void SetSpriteColor(int newId)
	{
		id = newId;
		if (sprite != null)
		{
			sprite.color = ColorId.GetColor(newId);
		}
		else
		{
			image.color = ColorId.GetColor(newId);
		}

	}
}
