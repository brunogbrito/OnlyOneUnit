using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeType
{
	public enum ShapesEnum
	{
		Circle,
		Square,
		Triangle,
		X
	}
	public ShapesEnum shapeForm;
	public List<Image> shapeArt;

}
