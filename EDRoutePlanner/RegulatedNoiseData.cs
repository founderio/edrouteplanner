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

namespace EDRoutePlanner
{
	public class RegulatedNoiseData : IDataSourceStations
	{

		private CsvReader autoSaveCsvReader;

		public RegulatedNoiseData(string path)
		{
			autoSaveCsvReader = new CsvReader(path);
		}

		public void reloadStations(Data data)
		{
			autoSaveCsvReader.Open();
			autoSaveCsvReader.ReadHeaders();

			data.systems.Clear();

			string[] line = null;

			while ((line = autoSaveCsvReader.ReadLine()) != null)
			{
				string system = line[0];
				string station = line[1];
				string commodity = line[2];
				string sellPrice = line[3];
				string buyPrice = line[4];
				string demandAmount = line[5];
				string demandLevel = line[6];
				string supplyAmount = line[7];
				string supplyLevel = line[8];
				string date = line[9];
				string sourceScreenshot = line[10];

				SystemData systemData = data.GetSystem(system);
				if (systemData == null)
				{
					systemData = new SystemData(system);
					data.systems[system] = systemData;
				}

				StationData stationData = systemData.GetStation(station);
				if (stationData == null)
				{
					stationData = new StationData(station);
					systemData.stations[station] = stationData;
				}

				CommodityPrice cp = stationData.GetPrice(commodity);
				if (cp == null)
				{
					cp = new CommodityPrice(commodity);
					stationData.commodityData[commodity] = cp;
				}

				if (demandLevel == "Low")
				{
					cp.demandType = DemandType.LowDemand;
					int.TryParse(sellPrice, out cp.price);
					int.TryParse(demandAmount, out cp.quantity);
				}
				else if (demandLevel == "Med")
				{
					cp.demandType = DemandType.MediumDemand;
					int.TryParse(sellPrice, out cp.price);
					int.TryParse(demandAmount, out cp.quantity);
				}
				else if (demandLevel == "High")
				{
					cp.demandType = DemandType.HighDemand;
					int.TryParse(sellPrice, out cp.price);
					int.TryParse(demandAmount, out cp.quantity);
				}
				else if (supplyLevel == "Low")
				{
					cp.demandType = DemandType.LowSupply;
					int.TryParse(buyPrice, out cp.price);
					int.TryParse(supplyAmount, out cp.quantity);
				}
				else if (supplyLevel == "Med")
				{
					cp.demandType = DemandType.MediumSupply;
					int.TryParse(buyPrice, out cp.price);
					int.TryParse(supplyAmount, out cp.quantity);
				}
				else if (supplyLevel == "High")
				{
					cp.demandType = DemandType.HighSupply;
					int.TryParse(buyPrice, out cp.price);
					int.TryParse(supplyAmount, out cp.quantity);
				}
				else
				{
					cp.demandType = DemandType.NotSet;
				}

			}

			autoSaveCsvReader.Close();
		}

	}
}
