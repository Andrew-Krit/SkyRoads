﻿// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
	public float MoveThreshold
	{
		get => moveThreshold;
		set => moveThreshold = Mathf.Abs(value);
	}

	[SerializeField] private float moveThreshold = 1;

	protected override void Start()
	{
		MoveThreshold = moveThreshold;
		base.Start();
		background.gameObject.SetActive(false);
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
		background.gameObject.SetActive(true);
		base.OnPointerDown(eventData);
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		background.gameObject.SetActive(false);
		base.OnPointerUp(eventData);
	}

	protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
	{
		if (magnitude > moveThreshold)
		{
			var difference = normalised * (magnitude - moveThreshold) * radius;
			background.anchoredPosition += difference;
		}

		base.HandleInput(magnitude, normalised, radius, cam);
	}
}