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
