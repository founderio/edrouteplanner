using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDRoutePlanner
{
	public class CmdrsLogCommoditiesData : IDataSourceCommodities
	{
		private CmdrsLogDataReader readerCommodityData;

		public CmdrsLogCommoditiesData(string basePath)
		{
			readerCommodityData = new CmdrsLogDataReader(basePath);
		}

		public void reloadCommodities(Data data)
		{
			List<string> allCommodities = new List<string>();

			if(readerCommodityData.rootSection != null) {
				foreach (string commodityGroup in readerCommodityData.rootSection.subsections.Keys)
				{
					CmdrsLogDataReader.Section groupSection = readerCommodityData.rootSection.subsections[commodityGroup];

					allCommodities.AddRange(groupSection.textContent);
					data.commodities[commodityGroup] = groupSection.textContent.ToArray();
				}
			}

			data.allCommodities = allCommodities.ToArray();
		}

	}
}
