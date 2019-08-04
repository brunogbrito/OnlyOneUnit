using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
	{
		gameObject.transform.DOScale(1.1f, 0.2f);
	}

	public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
	{
		gameObject.transform.DOScale(1f, 0.2f);
	}
}
