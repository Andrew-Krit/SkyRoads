// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

namespace SkyRoads
{
	public class RoadTile : MonoBehaviour
	{
		[SerializeField] private GameObject _asteroid;

		[SerializeField] private List<Vector3> _spawnPositions;

		private List<GameObject> _asteroids = new List<GameObject>();

		public List<Vector3> SpawnPositions => _spawnPositions;
		private void Start()
		{
			Asteroid.Passed += AsteroidRemove;
		}

		private void AsteroidRemove(Asteroid asteroid)
		{
			_asteroids.Remove(asteroid.gameObject);
		}

		public void SpawnAsteroid(Vector3 position)
		{
			var spawnedAsteroid = Instantiate(_asteroid, transform);
			spawnedAsteroid.transform.localPosition = position;
			_asteroids.Add(spawnedAsteroid);
		}

		public void ClearTile()
		{
			foreach (var asteroid in _asteroids)
				Destroy(asteroid);

			_asteroids.Clear();
		}
	}
}