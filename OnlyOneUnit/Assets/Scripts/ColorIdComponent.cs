using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

	private float rotationSpeed;

	private void Start()
	{
		if (isCollectable)
		{
			id = Random.Range(1, 4);
			gameObject.transform.DOScale(0f, 0f);
			gameObject.transform.DOScale(0.65f, 1f).SetEase(Ease.InOutElastic);
			rotationSpeed = Random.Range(0.1f, 2f);
		}
		SetSpriteColor(id);
	}

	private void Update()
	{
		if (isCollectable)
		{
			gameObject.transform.Rotate(0, 0, rotationSpeed, Space.Self);
		}

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
	}
}
