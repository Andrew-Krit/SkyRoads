// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace SkyRoads
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Spaceship _spaceship;

		private void Update()
		{
			if (!GameManager.IsGameOver)
				CameraFollow();
		}

		private void CameraFollow()
		{
			var spaceshipPositionX = _spaceship.transform.position.x;

			switch (SpaceshipController.State)
			{
				case SpaceshipController.SpaceshipStates.Normal:
					transform.position = new Vector3(spaceshipPositionX,
						Mathf.Lerp(transform.position.y, 6, Time.deltaTime),
						Mathf.Lerp(transform.position.z, -7, Time.deltaTime));
					break;
				case SpaceshipController.SpaceshipStates.Acceleration:
					transform.position = new Vector3(spaceshipPositionX,
						Mathf.Lerp(transform.position.y, 9, Time.deltaTime),
						Mathf.Lerp(transform.position.z, -9, Time.deltaTime));
					break;
				case SpaceshipController.SpaceshipStates.Deceleration:
					transform.position = new Vector3(spaceshipPositionX,
						Mathf.Lerp(transform.position.y, 4, Time.deltaTime),
						Mathf.Lerp(transform.position.z, -4, Time.deltaTime));
					break;
			}
		}
	}
}