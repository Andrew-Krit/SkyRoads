// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class ExitConfirm : Popup
	{
		[SerializeField] private Button _yes;
		[SerializeField] private Button _no;

		public void Awake()
		{
			_yes?.onClick.AddListener(Quit);
			_no?.onClick.AddListener(ReturnToMenu);
		}

		private void Quit()
		{
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#endif
			Application.Quit();
		}

		private void ReturnToMenu()
		{
			UIManager.Close(this);
		}
	}
}