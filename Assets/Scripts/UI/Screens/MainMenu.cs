// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class MainMenu : Screen
	{
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _recordsButton;
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _exitGameButton;

		public void Awake()
		{
			_playButton?.onClick.AddListener(Play);
			_recordsButton?.onClick.AddListener(GoToRecords);
			_settingsButton?.onClick.AddListener(GoToSettings);
			_exitGameButton?.onClick.AddListener(Exit);
		}

		private void Start()
		{
			AudioManager.PlayMusic("Garoad - Hopes And Dreams", true);
		}

		private void GoToRecords()
		{
			UIManager.Open("Records");
		}

		private void GoToSettings()
		{
			UIManager.Open("Settings");
		}

		private void Exit()
		{
			UIManager.Open("Exit");
		}

		private void Play()
		{
			LevelManager.Load("Game");
		}
	}
}