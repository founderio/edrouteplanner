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
		public string name;
		public Dictionary<string, CommodityPrice> commodityData;
		public string economy;
		public string government;
		public string faction;

		public StationData() : this("") { }

		public StationData(string name)
		{
			this.name = name;
			this.commodityData = new Dictionary<string, CommodityPrice>();
		}

		public CommodityPrice GetPrice(string commodity)
		{
			CommodityPrice price = null;
			commodityData.TryGetValue(commodity, out price);
			return price;
		}
	}

	public class CommodityPrice
	{
		public string commodity;
		public DemandType demandType;
		public int price;
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
