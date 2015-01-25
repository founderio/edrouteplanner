using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDRoutePlanner
{
	public class CmdrsLogData : IDataSourceStations, IDataSourceCommodities
	{
		private CmdrsLogDataReader readerCommodityData;
		private CmdrsLogDataReader readerSystemData;

		static DemandType[] statiV1;

		static CmdrsLogData() {
			statiV1 = new DemandType[9];
			statiV1[8] = DemandType.NotSet;
			statiV1[7] = DemandType.Illegal;
			statiV1[6] = DemandType.HighDemand;
			statiV1[5] = DemandType.MediumDemand;
			statiV1[4] = DemandType.LowDemand;
			statiV1[3] = DemandType.None;
			statiV1[2] = DemandType.LowSupply;
			statiV1[1] = DemandType.MediumSupply;
			statiV1[0] = DemandType.HighSupply;
		}
			
		public static DemandType parseStatusCmdrsLogV1 (int status) {
			if (status < 0 || status > 8)
			{
				return DemandType.NotSet;
			}
			else
			{
				return statiV1[status];
			}
		}

		public CmdrsLogData(string basePath)
		{
			string pathSystemData = Path.Combine(basePath, "system_data.txt");
			string pathCommodityData = Path.Combine(basePath, "default_commodity_data.txt");

			readerCommodityData = new CmdrsLogDataReader(pathCommodityData);
			readerSystemData = new CmdrsLogDataReader(pathSystemData);
		}

		public void reloadStations(Data data)
		{
			//TODO: Respect saveVersion!

			data.systems.Clear();

			/*
			 * Systems
			 */
			foreach (string system in readerSystemData.rootSection.subsections.Keys)
			{
				CmdrsLogDataReader.Section systemSection = readerSystemData.rootSection.subsections[system];

				SystemData sysData = new SystemData(system);
				data.systems[system] = sysData;

				/*
				 * Stations
				 */
				foreach (string station in systemSection.subsections.Keys)
				{
					CmdrsLogDataReader.Section stationSection = systemSection.subsections[station];

					StationData stationData = new StationData(station);
					sysData.stations[station] = stationData;
					stationSection.dictionary.TryGetValue("economy", out stationData.economy);
					stationSection.dictionary.TryGetValue("government", out stationData.government);
					stationSection.dictionary.TryGetValue("faction", out stationData.faction);
					//TODO: Respect hidden
					//TODO: Respect blackmarket?

					//TODO: DAU-Safe code (make wrapper inside Section class!)
					CmdrsLogDataReader.Section commoditiesSection = stationSection.subsections["Commodities"];

					//TODO: Load Notes?

					/*
					 * Commodities
					 */
					foreach (string commodity in commoditiesSection.subsections.Keys)
					{
						CmdrsLogDataReader.Section commoditySection = commoditiesSection.subsections[commodity];

						CommodityPrice cp = new CommodityPrice(commodity);
						stationData.commodityData[commodity] = cp;
						string status = null;
						string modTime = null;
						string price = null;
						string quantity = null;
						commoditySection.dictionary.TryGetValue("status", out status);
						commoditySection.dictionary.TryGetValue("modTime", out modTime);
						commoditySection.dictionary.TryGetValue("price", out price);
						commoditySection.dictionary.TryGetValue("quantity", out quantity);

						int statusAsInt = 8;

						//TODO: respect modTime?
						int.TryParse(price, out cp.price);
						int.TryParse(quantity, out cp.quantity);
						int.TryParse(status, out statusAsInt);

						cp.demandType = parseStatusCmdrsLogV1(statusAsInt);
					}
				}
			}
		}

		public void reloadCommodities(Data data)
		{
			List<string> allCommodities = new List<string>();

			foreach (string commodityGroup in readerCommodityData.rootSection.subsections.Keys)
			{
				CmdrsLogDataReader.Section groupSection = readerCommodityData.rootSection.subsections[commodityGroup];

				allCommodities.AddRange(groupSection.textContent);
				data.commodities[commodityGroup] = groupSection.textContent.ToArray();
			}

			data.allCommodities = allCommodities.ToArray();
		}

	}
}
