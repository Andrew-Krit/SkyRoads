// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace SkyRoads
{
	public class SpaceshipController : MonoBehaviour
	{
		[SerializeField] private Spaceship _spaceship;

		public enum SpaceshipStates
		{
			Normal,
			Acceleration,
			Deceleration
		}

		public static SpaceshipStates State = SpaceshipStates.Normal;
		private Joystick _joystick;

		private void Awake()
		{
			_joystick = GetComponent<Joystick>();
		}

		private void Update()
		{
			if (!GameManager.IsGameOver && !GameManager.IsGameOnPause)
			{
				Movement();
				Rotation();
				StatementsCheck();
			}
		}

		private void Movement()
		{
			var speedDirection = _spaceship.MoveSpeedX * _joystick.Horizontal * Time.deltaTime;

			var position = _spaceship.transform.position;

			var moveX = Mathf.Clamp(position.x + speedDirection, -10, 10);
			var moveTo = new Vector3(moveX, position.y, position.z);

			_spaceship.transform.position = moveTo;
		}

		private void Rotation()
		{
			var rotationZ = Mathf.Clamp(_joystick.Horizontal * _spaceship.RotationSpeedZ, -40f, 40f);
			var rotation = _spaceship.transform.rotation;
			rotation = Quaternion.Lerp(rotation, Quaternion.Euler(rotation.x, rotation.y, -rotationZ),
				Time.deltaTime * 5);
			_spaceship.transform.rotation = rotation;
		}

		private void StatementsCheck()
		{
			if (_joystick.Vertical > 0.60f)
				State = SpaceshipStates.Acceleration;
			else if (_joystick.Vertical < -0.60f)
				State = SpaceshipStates.Deceleration;
			else
				State = SpaceshipStates.Normal;
		}
	}
}