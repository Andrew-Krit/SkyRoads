// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class HUD : Screen
	{
		[SerializeField] private Button _pause;

		public void Awake()
		{
			_pause.onClick.AddListener(Pause);
		}

		private void Pause()
		{
			UIManager.Open("Pause");
			GameManager.PauseGame();
		}
	}
}