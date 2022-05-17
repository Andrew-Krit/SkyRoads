// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class SettingsWindow : Window
	{
		[SerializeField] private Toggle _sfx;
		[SerializeField] private Toggle _music;

		public override void Awake()
		{
			base.Awake();
			_sfx.isOn = AudioManager.IsSFXOn;
			_music.isOn = AudioManager.IsMusicOn;

			_sfx.onValueChanged.AddListener(AudioManager.SFXTurn);
			_music.onValueChanged.AddListener(AudioManager.MusicTurn);
		}
	}
}