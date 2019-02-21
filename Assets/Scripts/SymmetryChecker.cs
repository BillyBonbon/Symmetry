using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmetryChecker : MonoBehaviour
{
	[SerializeField]
	Camera m_CameraLeft = null;
	[SerializeField]
	Camera m_CameraRight = null;

	[SerializeField]
	float m_AllowableDelta = 0.1f;

	RenderTexture m_RenderTextureLeft = null;
	RenderTexture m_RenderTextureRight = null;

	Texture2D m_Texture2DLeft = null;
	Texture2D m_Texture2DRight = null;




	void Start()
    {
		m_RenderTextureLeft = m_CameraLeft.targetTexture;
		m_RenderTextureRight= m_CameraRight.targetTexture;

		m_Texture2DLeft = new Texture2D(m_RenderTextureLeft.width, m_RenderTextureLeft.height);
		m_Texture2DRight = new Texture2D(m_RenderTextureRight.width, m_RenderTextureRight.height);
	}

	// Update is called once per frame
	void Update()
    {
		Color[] colorsL = GetRenderTexturePixels(m_RenderTextureLeft, m_Texture2DLeft);
		Color[] colorsR = GetRenderTexturePixels(m_RenderTextureRight, m_Texture2DRight);

		if (colorsL.Length > 0)
		{
			bool identical = true;
			for (int index = 0; index < colorsL.Length; index++)
			{
				Color colorLeft = colorsL[index];
				Color colorRight = colorsR[index];
				if (!colorLeft.Equals(colorRight))
				{
					float dotProd = Vector4.Dot(Vector4.Normalize(colorLeft), Vector4.Normalize(colorRight));
					float diff = 1.0f - Mathf.Abs(dotProd);
					if (diff > m_AllowableDelta)
					{
						identical = false;
						break;
					}
				}
			}

			if (identical)
			{
				Debug.Log("ITS RUDDY IDENTICAL");
			}
			else
			{
				Debug.Log("ITS NOT RUDDY IDENTICAL");
			}
		}

	}

	private Color[] GetRenderTexturePixels(RenderTexture renderTexture, Texture2D texture2D)
	{
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		texture2D.Apply();
		return texture2D.GetPixels();
	}
}
