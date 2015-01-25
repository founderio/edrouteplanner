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

			reload();
		}

		public void reload()
		{
			dsCommodities.reloadCommodities(this);
			dsStations.reloadStations(this);
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

	public class CommodityPrice
	{
		public string commodity;
		public DemandType demandType;
		public int price;
		public int quantity;
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
