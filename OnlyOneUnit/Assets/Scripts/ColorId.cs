using UnityEngine;

public class ColorId : MonoBehaviour
{
	public int ColorIdValue	{ get {	return id;}	private set { } }

	[SerializeField]
	private SpriteRenderer sprite;

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

	public void SetSpriteColor(int newId)
	{
		id = newId;
		sprite.color = ColorIdComponent.GetColor(newId);
	}
}
