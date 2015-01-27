using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDRoutePlanner
{
	public class Defaults
	{
		public string pathCommodityData;
		public string pathStationData;
		public DataSourceType typeStationData;
	}

	public enum DataSourceType
	{
		RegulatedNoise = 0,
		CmdrsLogV1 = 1
	}
}
