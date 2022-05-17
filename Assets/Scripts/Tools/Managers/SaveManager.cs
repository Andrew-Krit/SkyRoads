// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SkyRoads
{
	public class SaveManager : MonoBehaviour
	{
		public static string RecordPath { get; private set;}
		private void Awake()
		{
			RecordPath = Application.persistentDataPath + "/records.txt";
		}
		public static void SaveRecords(List<Record> list)
		{
			var binFormatter = new BinaryFormatter();
			using var memoryStream = new MemoryStream();
			binFormatter.Serialize(memoryStream, list);

			File.WriteAllBytes(RecordPath, memoryStream.ToArray());
		}

		public static List<Record> LoadRecords()
		{
			var binFormatter = new BinaryFormatter();
			var bytes = File.ReadAllBytes(RecordPath);

			using var memoryStream = new MemoryStream(bytes);

			var records = (List<Record>) binFormatter.Deserialize(memoryStream);

			return records;
		}
	}
}