// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SkyRoads
{
	public class PauseWindow : Window
	{
		[SerializeField] private Toggle _sfx;
		[SerializeField] private Toggle _music;
		[SerializeField] private Button _exitToMainMenu;

		public override void Awake()
		{
			base.Awake();
			_exitToMainMenu.onClick.AddListener(GoToMainMenu);
			_sfx.isOn = AudioManager.IsSFXOn;
			_music.isOn = AudioManager.IsMusicOn;

			_sfx.onValueChanged.AddListener(AudioManager.SFXTurn);
			_music.onValueChanged.AddListener(AudioManager.MusicTurn);

			_closeButton.onClick.AddListener(GameManager.UnpauseGame);
		}

		private void GoToMainMenu()
		{
			LevelManager.Load("MainMenu");
		}
	}
}