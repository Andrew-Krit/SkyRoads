// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;
using DG.Tweening;
using UnityEngine;

namespace SkyRoads
{
	public class Asteroid : MonoBehaviour
	{
		public static event Action<Asteroid> Passed;

		private Tween _rotationTween;

		private void Start()
		{
			var rotation = new Vector3(0, 360, 0);
			_rotationTween = transform.DOLocalRotate(rotation, 5).SetLoops(-1, LoopType.Incremental)
				.SetEase(Ease.Linear).SetRelative();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag.Equals("Road"))
			{
				Passed?.Invoke(this);
				Destroy(gameObject);
			}
		}

		private void OnDestroy()
		{
			_rotationTween.Kill();
		}
	}
}