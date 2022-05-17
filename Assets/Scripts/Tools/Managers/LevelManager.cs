// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> _scenes = new List<GameObject>();
	[SerializeField] private GameObject _currentScene;

	private static LevelManager _instance;

	private void Awake()
	{
		_instance = this; 
	}

	public static GameObject Load(string sceneName)
	{
		UnloadCurrent();
		var scene = _instance._scenes.FirstOrDefault(ui => ui.gameObject.name == sceneName);
		_instance._currentScene = Instantiate(scene, _instance.gameObject.transform);
		return scene;
	}

	private static void UnloadCurrent()
	{
		Destroy(_instance._currentScene);
	}
}