using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
	[SerializeField]
	private float m_snapDistance = 0.5f;

	public float SnapDistance { get => m_snapDistance; set => m_snapDistance = value; }

	public void Snap()
	{
		Transform transform = gameObject.transform;
		Vector3 position = transform.position;

		position.x = FindNearestSnapValue(position.x);
		position.y = FindNearestSnapValue(position.y);
		transform.position = position;
	}

	private float FindNearestSnapValue(float position)
	{
		bool negative = position < 0;
		float snapValue = 0.0f;
		float remainder = position % m_snapDistance;
		bool roundUp = (Mathf.Abs(remainder) >= (m_snapDistance / 2));

		snapValue = Mathf.Abs(position) - Mathf.Abs(remainder);
		if ( roundUp )
		{
			snapValue += m_snapDistance;
		}

		return negative ? -snapValue : snapValue;
	}
}
