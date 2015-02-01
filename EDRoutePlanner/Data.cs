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

	public interface IDataSourceStations
	{
		void reloadStations(Data data);
	}

	public interface IDataSourceCommodities
	{
		void reloadCommodities(Data data);
	}

	public class Data
	{

		public IDictionary<string, string[]> commodities;
		public string[] allCommodities;
		public IDictionary<string, SystemData> systems;

		public IDataSourceStations dsStations;
		public IDataSourceCommodities dsCommodities;

		public Data(IDataSourceStations dsStations, IDataSourceCommodities dsCommodities)
		{
			this.dsStations = dsStations;
			this.dsCommodities = dsCommodities;

			commodities = new Dictionary<string, string[]>();
			systems = new Dictionary<string, SystemData>();

			Reload();
		}

		public void Reload()
		{
			dsCommodities.reloadCommodities(this);
			dsStations.reloadStations(this);
		}

		public SystemData GetSystem(string system)
		{
			SystemData systemData = null;
			systems.TryGetValue(system, out systemData);
			return systemData;
		}

		public StationData GetStation(string system, string station)
		{
			SystemData systemData = GetSystem(system);
			if (systemData == null)
			{
				return null;
			}
			else
			{
				return systemData.GetStation(station);
			}
		}

		public List<StationData> Stations
		{
			get
			{
				List<StationData> stations = new List<StationData>();
				foreach(SystemData system in systems.Values) {
					stations.AddRange(system.stations.Values);
				}
				return stations;
			}
		}
	}

	public class SystemData
	{
		public string name;
		public Dictionary<string, StationData> stations;

		public SystemData() : this("") { }

		public SystemData(string name)
		{
			this.name = name;
			this.stations = new Dictionary<string, StationData>();
		}

		public StationData GetStation(string station)
		{
			StationData stationData = null;
			stations.TryGetValue(station, out stationData);
			return stationData;
		}
	}

	public class StationData
	{
		public string system;
		public string name;
		public Dictionary<string, CommodityPrice> commodityData;
		public string economy;
		public string government;
		public string faction;

		public StationData() : this("", "") { }

		public StationData(string system, string name)
		{
			this.system = system;
			this.name = name;
			this.commodityData = new Dictionary<string, CommodityPrice>();
		}

		public CommodityPrice GetPrice(string commodity)
		{
			CommodityPrice price = null;
			commodityData.TryGetValue(commodity, out price);
			return price;
		}

		public override bool Equals(object obj)
		{
			// Just to be sure, we will have the Equals method here.

			StationData other = obj as StationData;
			if (obj == null)
			{
				return false;
			}
			if (this.system != other.system)
			{
				return false;
			}
			if (this.name != other.name)
			{
				return false;
			}
			// Disregards prices & other data as the *should* not change.
			return true;
		}
	}

	public class CommodityPrice
	{
		public string commodity;
		public DemandType demandType;
		public int priceSell;
		public int priceBuy;
		public int quantity;

		public CommodityPrice() : this("") { }

		public CommodityPrice(string commodity)
		{
			this.commodity = commodity;
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
}
