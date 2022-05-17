// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System;

namespace SkyRoads
{
	[Serializable]
	public class Record
	{
		public int Rank { get; set; }
		public float Time { get; private set; }
		public DateTime Date { get; private set; }
		public int Score { get; private set; }

		public Record(int score, float time)
		{
			Date = DateTime.Now;
			Score = score;
			Time = time;
			Rank = 1;
		}
	}
}