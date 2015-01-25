using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDRoutePlanner
{
	public class CmdrsLogData
	{
		private CmdrsLogDataReader readerCommodityData;
		private CmdrsLogDataReader readerSystemData;

		public IDictionary<string, string[]> commodities;
		public string[] allCommodities;
		public IDictionary<string, SystemData> systems;

		public class SystemData
		{
			public string name;
			public IDictionary<string, StationData> stations;
		}

		public class StationData
		{
			public string name;
			public IDictionary<string, CommodityPrice> commodityData;
			public string economy;
			public string government;
			public string faction;

			public CommodityPrice GetPrice(string commodity)
			{
				CommodityPrice price = null;
				commodityData.TryGetValue(commodity, out price);
				return price;
			}
		}

		public enum DemandType
		{
			LowDemand,
			MediumDemand,
			HighDemand,
			LowSupply,
			MediumSupply,
			HighSupply,
			None,
			Illegal,
			NotSet
		}

		public class CommodityPrice
		{
			public string commodity;
			public DemandType demandType;
			public int price;
			public int quantity;
		}

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

			commodities = new Dictionary<string, string[]>();
			systems = new Dictionary<string, SystemData>();

			reparse();
		}

		public void reload()
		{
			readerCommodityData.reload();
			readerSystemData.reload();

			reparse();
		}

		private void reparse()
		{
			List<string> allCommodities = new List<string>();

			foreach (string commodityGroup in readerCommodityData.rootSection.subsections.Keys)
			{
				CmdrsLogDataReader.Section groupSection = readerCommodityData.rootSection.subsections[commodityGroup];

				allCommodities.AddRange(groupSection.textContent);
				commodities[commodityGroup] = groupSection.textContent.ToArray();
			}

			this.allCommodities = allCommodities.ToArray();

			//TODO: Respect saveVersion!

			systems.Clear();

			/*
			 * Systems
			 */
			foreach (string system in readerSystemData.rootSection.subsections.Keys)
			{
				CmdrsLogDataReader.Section systemSection = readerSystemData.rootSection.subsections[system];

				SystemData sysData = new SystemData();
				sysData.stations = new Dictionary<string, StationData>();
				sysData.name = system;
				systems[system] = sysData;

				/*
				 * Stations
				 */
				foreach (string station in systemSection.subsections.Keys)
				{
					CmdrsLogDataReader.Section stationSection = systemSection.subsections[station];

					StationData stationData = new StationData();
					stationData.name = station;
					stationData.commodityData = new Dictionary<string, CommodityPrice>();
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

						CommodityPrice cp = new CommodityPrice();
						cp.commodity = commodity;
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

		public StationData GetStation(string system, string station)
		{
			SystemData systemData = null;
			StationData stationData = null;

			systems.TryGetValue(system, out systemData);
			if (systemData != null)
			{
				systemData.stations.TryGetValue(station, out stationData);
			}
			return stationData;
		}

	}
}
