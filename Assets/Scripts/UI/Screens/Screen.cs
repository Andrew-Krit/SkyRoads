// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace SkyRoads
{
	public class Screen : UI
	{
		protected void Close()
		{
			gameObject.SetActive(false);
			UIManager.Close(this);
		}
	}
}