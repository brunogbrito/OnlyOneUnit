using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{
	[SerializeField]
	private ColorId playerColorId;

	[SerializeField]
	private SpriteIDComponent playerSpriteId;

	void Update()
    {
		var mouseLocation = Input.mousePosition;
		mouseLocation.z = 10f;
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(mouseLocation);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "collectible")
		{
			if (playerColorId.ColorIdValue == collision.gameObject.GetComponent<ColorId>().ColorIdValue)
			{
				playerSpriteId.SetSpriteArt(collision.gameObject.GetComponent<SpriteIDComponent>().SpriteIdValue);
				Destroy(collision.gameObject);
			}
			else if (playerSpriteId.SpriteIdValue == collision.gameObject.GetComponent<SpriteIDComponent>().SpriteIdValue)
			{
				playerColorId.SetSpriteColor(collision.gameObject.GetComponent<ColorId>().ColorIdValue);
				Destroy(collision.gameObject);
			}
			else
			{
				Debug.Log("Game Over");
			}

		}

	}
}
