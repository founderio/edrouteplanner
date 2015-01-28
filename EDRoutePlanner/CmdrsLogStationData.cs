/* Copyright 2015 Oliver Kahrmann
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDRoutePlanner
{
	public class CmdrsLogStationData : IDataSourceStations
	{
		private CmdrsLogDataReader readerSystemData;

		static DemandType[] statiV1;

		static CmdrsLogStationData() {
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

		public CmdrsLogStationData(string basePath)
		{
			readerSystemData = new CmdrsLogDataReader(basePath);
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
						int priceAsInt = 0;

						//TODO: respect modTime?
						int.TryParse(price, out priceAsInt);
						int.TryParse(quantity, out cp.quantity);
						int.TryParse(status, out statusAsInt);

						cp.demandType = parseStatusCmdrsLogV1(statusAsInt);

						switch (cp.demandType)
						{
							case DemandType.HighDemand:
							case DemandType.MediumDemand:
							case DemandType.LowDemand:
								cp.priceBuy = priceAsInt;
								break;
							case DemandType.HighSupply:
							case DemandType.MediumSupply:
							case DemandType.LowSupply:
								cp.priceSell = priceAsInt;
								break;
						}
					}
				}
			}
		}

	}
}
