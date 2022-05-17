// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace SkyRoads
{
	public class RecordsWindow : Window
	{
		[SerializeField] private GameObject _recordsContainer;
		[SerializeField] private RecordItemView _recordItem;

		public void Start()
		{
			var records = RecordManager.Records;

			for (var i = 0; i < records.Count; i++)
			{
				records[i].Rank = i + 1;
				var recordItem = CreateItem(records[i]);
				Instantiate(recordItem, _recordsContainer.transform);
			}
		}

		private RecordItemView CreateItem(Record record)
		{
			var item = _recordItem;
			item.SetInfo(record);

			return item;
		}
	}
}