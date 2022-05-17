// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkyRoads
{
	public class Road : MonoBehaviour
	{
		[SerializeField] private float _offset;

		public static event Action<RoadTile> OnTilePassed;

		private float _speed;

		private Queue<RoadTile> _tiles;
		private Transform _tilesTransform;

		private void Awake()
		{
			_tiles = new Queue<RoadTile>(GetComponentsInChildren<RoadTile>());
			_tilesTransform = transform.GetChild(0);
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag.Equals("RoadTile"))
			{
				var removedTile = _tiles.Dequeue();
				removedTile.transform.position = new Vector3(0f, 0f, _tiles.Last().transform.position.z + _offset);
				_tiles.Enqueue(removedTile);

				OnTilePassed?.Invoke(removedTile);
			}
		}

		private void Update()
		{
			if (!GameManager.IsGameOver && !GameManager.IsGameOnPause)
				_tilesTransform.localPosition -= Vector3.forward * _speed;
		}

		public void AddSpeed(float speedToAdd)
		{
			_speed += speedToAdd;
		}

		public void ResetRoad()
		{
			foreach (var tileRoad in _tiles)
				tileRoad.ClearTile();
			_speed = 0.1f;
		}
	}
}