// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class ScoreManager : MonoBehaviour
	{
		[SerializeField] private Text _scoreText;
		public static int Score;

		private void Awake()
		{
			TimeManager.SecondAdded += OnSecondAdded;
			Asteroid.Passed += OnAsteroidPassed;
		}

		private void OnAsteroidPassed(Asteroid asteroid)
		{
			AddPoints(5);
		}

		private void OnSecondAdded()
		{
			if(GameManager.IsDeccelerationSpeed)
				return;

			AddPoints(GameManager.IsAccelerationSpeed ? 2 : 1);
		}

		private void OnDestroy()
		{
			TimeManager.SecondAdded -= OnSecondAdded;
			Asteroid.Passed -= OnAsteroidPassed;
		}

		private void AddPoints(int points)
		{
			Score += points;
			_scoreText.text = $"Score: {Score}";
		}

		public void ResetScore()
		{
			Score = 0;
			_scoreText.text = $"Score: {Score}";
		}
	}
}