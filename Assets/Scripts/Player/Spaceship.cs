// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace SkyRoads
{
	public class Spaceship : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _explodeEffect;

		[Header("Spaceship")] 
		public readonly float MoveSpeedX = 50;
		public readonly float RotationSpeedZ = 120;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag.Equals("Asteroid"))
			{
				var explosion = Instantiate(_explodeEffect, transform.position, Quaternion.identity);
				Destroy(explosion.gameObject, explosion.main.duration);
				AudioManager.PlaySound("Exsplosion");

				gameObject.SetActive(false);
				GameManager.OverGame();
			}
		}

		public void ResetSpaceship()
		{
			transform.position = new Vector3(0f, 3f, 0f);
			transform.rotation = Quaternion.identity;

			gameObject.SetActive(true);
		}
	}
}