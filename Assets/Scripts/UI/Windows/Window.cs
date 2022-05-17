// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class Window : UI
	{
		[SerializeField] protected Button _closeButton;

		public virtual void Awake()
		{
			_closeButton.onClick.AddListener(Close);
		}

		private void Close()
		{
			UIManager.Close(this);
		}
	}
}