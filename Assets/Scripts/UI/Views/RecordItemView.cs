// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace SkyRoads
{
	public class RecordItemView : View
	{
		[SerializeField] private Text _rank;
		[SerializeField] private Text _date;
		[SerializeField] private Text _score;
		[SerializeField] private Text _time;

		public void SetInfo(Record record)
		{
			_rank.text = record.Rank.ToString();
			_date.text = record.Date.ToString();
			_score.text = record.Score.ToString();
			_time.text = record.Time.ToString("00:00:00");
		}
	}
}