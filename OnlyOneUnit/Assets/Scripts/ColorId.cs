using UnityEngine;

public class ColorId : MonoBehaviour
{
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

		sprite.color = ColorIdComponent.GetColor(id);
	}
}
