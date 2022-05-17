// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class DefaultButton : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<Button>().onClick.AddListener(Click);
		}

		private void Click()
		{
			AudioManager.PlaySound("UI Click 13");
		}
	}
}