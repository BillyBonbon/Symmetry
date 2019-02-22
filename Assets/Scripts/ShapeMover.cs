using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMover : MonoBehaviour
{
	[SerializeField]
	SnapToGrid m_SnapToGrid = null;

	private bool dragging = false;
	private float distance;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp()
	{
		dragging = false;
		m_SnapToGrid.Snap();
	}

	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}

	}
}

