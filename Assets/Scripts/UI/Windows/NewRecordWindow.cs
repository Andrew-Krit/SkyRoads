// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SkyRoads
{
	public class NewRecordWindow : Window
	{
		[SerializeField] private Button _restartButton;
		[SerializeField] private RecordItemView _recordItemView;

		public override void Awake()
		{
			_restartButton?.onClick.AddListener(Restart);
			_closeButton?.onClick.AddListener(GoToMenu);
		}

		private void Start()
		{
			AudioManager.PlayMusic("Garoad - CALICOMP 1.1 Startup", false);
		}

		private void Restart()
		{
			GameManager.StartGame();
			UIManager.Close(this);
		}

		private void GoToMenu()
		{
			LevelManager.Load("MainMenu");
		}

		public void Initialize(Record record)
		{
			_recordItemView.SetInfo(record);
		}
	}
}