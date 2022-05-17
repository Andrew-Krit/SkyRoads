// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SkyRoads
{
	public class AudioManager : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSourceSFX;
		[SerializeField] private AudioSource _audioSourceMusic;
		[SerializeField] private AudioMixer _audioMixer;

		private readonly Dictionary<string, AudioClip> _audio = new Dictionary<string, AudioClip>();

		private static AudioManager _instance;
		public static bool IsSFXOn { get; private set; }
		public static bool IsMusicOn { get; private set; }

		private void Awake()
		{
			_instance = this;
			IsSFXOn = true;
			IsMusicOn = true;

			var audio = Resources.LoadAll<AudioClip>("Audio/");
			foreach (var audioClip in audio)
				_audio.Add(audioClip.name, audioClip);

			IsSFXOn = PlayerPrefs.GetInt("SFX") == 1;
			IsMusicOn = PlayerPrefs.GetInt("Music") == 1;
		}

		public void Start()
		{
			if (!IsSFXOn)
				_audioMixer.SetFloat("SFX", -80);
			if (!IsMusicOn)
				_audioMixer.SetFloat("Music", -80);
		}

		public static void PlaySound(string sound)
		{
			_instance._audioSourceSFX.PlayOneShot(_instance._audio[sound]);
		}

		public static void PlayMusic(string music, bool loopable)
		{
			_instance._audioSourceMusic.clip = _instance._audio[music];
			_instance._audioSourceMusic.loop = loopable;
			_instance._audioSourceMusic.Play();
		}

		public static void PauseMusic()
		{
			_instance._audioSourceMusic.Pause();
		}

		public static void UnpauseMusic()
		{
			_instance._audioSourceMusic.UnPause();
		}

		public static void SFXTurn(bool turnOn)
		{
			if (turnOn)
				_instance._audioMixer.SetFloat("SFX", 0);
			else
				_instance._audioMixer.SetFloat("SFX", -80);

			IsSFXOn = !IsSFXOn;

			PlayerPrefs.SetInt("SFX", IsSFXOn ? 1 : 0);
		}

		public static void MusicTurn(bool turnOn)
		{
			if (turnOn)
				_instance._audioMixer.SetFloat("Music", 0);
			else
				_instance._audioMixer.SetFloat("Music", -80);

			IsMusicOn = !IsMusicOn;

			PlayerPrefs.SetInt("Music", IsMusicOn ? 1 : 0);
		}
	}
}