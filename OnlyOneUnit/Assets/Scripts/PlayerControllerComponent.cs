﻿using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{
	[SerializeField]
	private ColorIdComponent playerColorId;

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
			if (playerColorId.ColorIdValue == collision.gameObject.GetComponent<ColorIdComponent>().ColorIdValue)
			{
				playerSpriteId.SetSpriteArt(collision.gameObject.GetComponent<SpriteIDComponent>().SpriteIdValue);
				GameManager.instance.DecreaseNumberOfActiveShapes(collision.gameObject.GetComponent<SpriteIDComponent>(), collision.gameObject.GetComponent<ColorIdComponent>());
				Destroy(collision.gameObject);
			}
			else if (playerSpriteId.SpriteIdValue == collision.gameObject.GetComponent<SpriteIDComponent>().SpriteIdValue)
			{
				playerColorId.SetSpriteColor(collision.gameObject.GetComponent<ColorIdComponent>().ColorIdValue);
				GameManager.instance.DecreaseNumberOfActiveShapes(collision.gameObject.GetComponent<SpriteIDComponent>(), collision.gameObject.GetComponent<ColorIdComponent>());
				Destroy(collision.gameObject);
			}
			else
			{
				//TODO increase barspeed

			}
		}
	}
}
