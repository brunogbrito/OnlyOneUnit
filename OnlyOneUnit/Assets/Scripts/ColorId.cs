using System.Collections.Generic;
using UnityEngine;

public class ColorId : MonoBehaviour
{
	[SerializeField]
	private List<ColorIDType> colorIds;

	private int listIdIndex;

	private static ColorIDType currentColorId;

	public void SetColorIdList()
	{
		listIdIndex = Random.Range(0, colorIds.Count);
		currentColorId = colorIds[listIdIndex];
	}

	public static Color GetColor(int id)
	{
		var selectedColor = currentColorId.colors[id];
		return selectedColor;
	}

}
