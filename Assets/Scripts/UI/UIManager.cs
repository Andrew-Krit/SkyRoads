// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkyRoads
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private List<UI> _uiElements = new List<UI>();

		private static UIManager _instance;

		private void Awake()
		{
			_instance = this;
		}

		private void Start()
		{
			if (PlayerPrefs.GetInt("ComixViewed") == 0)
				Open("Comix");
		}

		public static void Close(UI window)
		{
			Destroy(window.gameObject);
		}

		public static UI Open(string uiName)
		{
			var uiElement = _instance._uiElements.FirstOrDefault(ui => ui.Name == uiName);
			return Instantiate(uiElement, _instance.gameObject.transform);
		}
	}
}