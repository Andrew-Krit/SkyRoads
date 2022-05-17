// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkyRoads
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private Spaceship _spaceship;
		[SerializeField] private Road _road;
		[SerializeField] private ScoreManager _scoreManager;
		[SerializeField] private TimeManager _timeManager;

		[SerializeField] private List<ConfigData> _roadConfig = new List<ConfigData>();

		private int _currentConfig;
		private Vector3 _lastAsteroidPosition;
		private static GameManager _instance;

		public static bool IsGameOver { get; private set; }
		public static bool IsGameOnPause { get; private set; }
		public static bool IsAccelerationSpeed { get; private set; }
		public static bool IsDeccelerationSpeed { get; private set; }
		private void Start()
		{
			_instance = this;

			IsGameOver = true;
			IsGameOnPause = false;
			IsAccelerationSpeed = false;
			IsDeccelerationSpeed = false;
			_lastAsteroidPosition = new Vector3(0, 0, 0);

			Road.OnTilePassed += OnRoadTilePassed;
			StartGame();
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		public static void StartGame()
		{
			if (!IsGameOver)
				return;

			IsGameOver = !IsGameOver;

			_instance._spaceship.ResetSpaceship();
			_instance._road.ResetRoad();
			_instance._scoreManager.ResetScore();
			_instance._timeManager.ResetTime();
			ConfigReset();

			_instance.StartCoroutine(SpeedUp());
			AudioManager.PlayMusic("Aphex Twin - Xtal", true);
		}

		public static void OverGame()
		{
			if (IsGameOver)
				return;

			IsGameOver = !IsGameOver;

			_instance.StopCoroutine(SpeedUp());

			var newRecord = RecordManager.CreateRecord(ScoreManager.Score, TimeManager.PlayTime);

			if (RecordManager.Records.Any())
			{
				if (newRecord.Score > RecordManager.Records[0].Score)
				{
					var newRecordWindow = UIManager.Open("NewRecord") as NewRecordWindow;
					newRecordWindow.Initialize(newRecord);
				}
				else
					UIManager.Open("Lose");
			}
			else
			{
				var newRecordWindow = UIManager.Open("NewRecord") as NewRecordWindow;
				newRecordWindow.Initialize(newRecord);
			}

			RecordManager.Add(newRecord);

			SaveManager.SaveRecords(RecordManager.Records);
		}

		public static void PauseGame()
		{
			if (IsGameOnPause)
				return;

			IsGameOnPause = !IsGameOnPause;
			AudioManager.PauseMusic();
		}

		public static void UnpauseGame()
		{
			if (!IsGameOnPause)
				return;

			IsGameOnPause = !IsGameOnPause;
			AudioManager.UnpauseMusic();
		}

		private static IEnumerator SpeedUp()
		{
			while (true)
			{
				if (!IsGameOnPause)
				{
					switch (SpaceshipController.State)
					{
						case SpaceshipController.SpaceshipStates.Normal:
							IsAccelerationSpeed = false;
							IsDeccelerationSpeed = false;
							_instance._road.AddSpeed(0.001f);
							break;
						case SpaceshipController.SpaceshipStates.Acceleration:
							IsAccelerationSpeed = true;
							IsDeccelerationSpeed = false;
							_instance._road.AddSpeed(0.005f);
							break;
						case SpaceshipController.SpaceshipStates.Deceleration:
							IsAccelerationSpeed = false;
							IsDeccelerationSpeed = true;
							break;
					}
				}

				if (IsGameOver)
					yield break;

				yield return new WaitForSeconds(0.1f);
			}
		}

		private void OnRoadTilePassed(RoadTile passedTile)
		{
			if (_roadConfig[_currentConfig].PassedTiles >= _roadConfig[_currentConfig].TilesForPass &&
				_currentConfig < _roadConfig.Count - 1)
				_currentConfig++;

			_roadConfig[_currentConfig].PassedTiles++;

			var chanceNotToSpawn = Random.Range(1, 10);

			if (chanceNotToSpawn > _roadConfig[_currentConfig].Frequency)
				return;

			var asteroidCount = Random.Range(1, 2);
			var positionIndex = Random.Range(0, passedTile.SpawnPositions.Count);

			for (var i = 0; i < asteroidCount; i++)
			{
				if (asteroidCount > 0)
				{
					while (passedTile.SpawnPositions[positionIndex] == _lastAsteroidPosition)
						positionIndex = Random.Range(0, passedTile.SpawnPositions.Count);
				}

				_lastAsteroidPosition = passedTile.SpawnPositions[positionIndex];

				passedTile.SpawnAsteroid(_lastAsteroidPosition);
			}
		}

		private static void ConfigReset()
		{
			foreach (var config in _instance._roadConfig) 
				config.PassedTiles = 0;
		}
	}
}