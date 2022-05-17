// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class Comix : Screen
	{
		[SerializeField] private Button _nextButton;
		[SerializeField] private Sprite[] _slides = new Sprite[3];
		[SerializeField] private Image _comixSlide;

		private int _slideIndex;

		public void Awake()
		{
			_nextButton.onClick.AddListener(NextImage);
		}

		private void Start()
		{
			AudioManager.PlayMusic("Garoad - Hopes And Dreams", true);
			_comixSlide.sprite = _slides[_slideIndex];
		}

		private void NextImage()
		{
			if (_slideIndex < _slides.Length - 1)
				_slideIndex++;
			else
			{
				PlayerPrefs.SetInt("ComixViewed", 1);
				Close();
			}

			_comixSlide.sprite = _slides[_slideIndex];
		}
	}
}