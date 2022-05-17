// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SkyRoads
{
	public class LoseWindow : Window
	{
		[SerializeField] private Button _restartButton;

		public override void Awake()
		{
			_closeButton?.onClick.AddListener(GoToMenu);
			_restartButton?.onClick.AddListener(GameManager.StartGame);
			_restartButton?.onClick.AddListener(BackToMenu);
		}

		public void Start()
		{
			AudioManager.PlayMusic("Garoad - CALICOMP 1.1 Shutdown", false);
		}

		private void GoToMenu()
		{
			LevelManager.Load("MainMenu");
		}

		private void BackToMenu()
		{
			Destroy(gameObject);
		}
	}
}