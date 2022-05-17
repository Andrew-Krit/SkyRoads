// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

namespace SkyRoads
{
	[Serializable]
	public class UI : MonoBehaviour
	{
		public string Name => gameObject.name;

		protected void Hide()
		{
			gameObject.SetActive(false);
		}

		protected void Show()
		{
			gameObject.SetActive(true);
		}
	}
}