using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
	[SerializeField]
	private float m_gridSize = 0.5f;

	[SerializeField]
	LineRenderer m_gridLine = null;

	float screenWidth = 20.0f;
	float screenHeight = 20.0f;

	// Start is called before the first frame update
	void Start()
    {
		for (int i = 0; i < screenWidth; i++)
		{
			CreateGridline(false, i);
			CreateGridline(false, -i);
			CreateGridline(true, i);
			CreateGridline(true, -i);
		}
	}

	private void CreateGridline(bool horizonatal, int delta)
	{
		float length = horizonatal ? screenWidth : screenHeight;

		LineRenderer lineRenderer = Instantiate(m_gridLine, this.transform);
		Vector3 start = new Vector3(horizonatal ? length : m_gridSize * delta, horizonatal ? m_gridSize * delta : length);
		Vector3 end = new Vector3(horizonatal ? -length : m_gridSize * delta, horizonatal ? m_gridSize * delta : -length);
		lineRenderer.SetPosition(0, start);
		lineRenderer.SetPosition(1, end);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
