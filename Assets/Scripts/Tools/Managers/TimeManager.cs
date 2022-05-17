// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace SkyRoads
{
	public class TimeManager : MonoBehaviour
	{
		[SerializeField] private Text _timeText;

		public static float PlayTime;

		public static event Action SecondAdded;

		private float _min;
		private float _hours;
		private float _sec;

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		public void ResetTime()
		{
			_timeText.text = "Time: 00:00:00";
			PlayTime = 0;
			StartCoroutine(Tick());
		}

		private IEnumerator Tick()
		{
			while (true)
			{
				if (!GameManager.IsGameOnPause)
				{
					SecondAdded?.Invoke();
					PlayTime++;

					_hours = (int) (PlayTime / 3600);
					_min = (int) (PlayTime / 60 % 60);
					_sec = (int) (PlayTime % 60);

					_timeText.text = $"Time: {_hours:00}:{_min:00}:{_sec:00}";
				}

				if (GameManager.IsGameOver)
					yield break;

				yield return new WaitForSeconds(1f);
			}
		}
	}
}