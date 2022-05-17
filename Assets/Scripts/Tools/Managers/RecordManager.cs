// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SkyRoads
{
	[Serializable]
	public class RecordManager : MonoBehaviour
	{
		public static List<Record> Records { get; private set; }

		private void Start()
		{
			Records = new List<Record>();

			if (File.Exists(SaveManager.RecordPath))
				Records = SaveManager.LoadRecords();
		}

		public static void Add(Record record)
		{
			Records.Add(record);
			Records = Records.OrderByDescending(record => record.Score).ToList();
		}

		public static Record CreateRecord(int score, float time)
		{
			var record = new Record(score, time);

			return record;
		}
	}
}