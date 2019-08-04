using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{


	void Update()
    {
		var mouseLocation = Input.mousePosition;
		mouseLocation.z = 10f;
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(mouseLocation);
	}
}
