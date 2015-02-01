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
	public class Route
	{
		public String name;
		public List<Destination> destinations;
		public bool loopRoute = false;

		public Route()
		{
			this.name = "New Route";
			destinations = new List<Destination>();
		}
	}

	public class Transaction
	{
		public string commodity;
		public int amount;

		public Transaction()
		{
		}

		public int GetAmount(int maxAmount)
		{
			if (amount == 0)
			{
				return maxAmount;
			}
			else
			{
				return amount;
			}
		}
	}

	public class ComparedCommodity
	{
		public string commodity;
		public DemandType demand;
		public int priceSell;
		public int priceBuy;
		public int profitPer;
		public int profit;

		public ComparedCommodity(string commodity, int amount, CommodityPrice ourPrice, CommodityPrice theirPrice)
		{
			this.commodity = commodity;
			if (ourPrice != null)
			{
				priceBuy = ourPrice.priceBuy;
				priceSell = ourPrice.priceSell;
				demand = ourPrice.demandType;
				if (theirPrice != null && theirPrice.priceSell > 0 && ourPrice.priceBuy > 0)
				{
					profitPer = theirPrice.priceSell - ourPrice.priceBuy;
				}
			}
			profit = profitPer * amount;
		}

		public string Commodity
		{
			get { return commodity; }
		}

		public string Demand
		{
			get { return demand.ToString(); }
		}

		public string PriceSell
		{
			get { return priceSell == 0 ? "" : priceSell.ToString("N0"); }
		}

		public string PriceBuy
		{
			get { return priceBuy == 0 ? "" : priceBuy.ToString("N0"); }
		}

		public string ProfitPer
		{
			get { return profitPer == 0 ? "" : profitPer.ToString("N0"); }
		}

		public string Profit
		{
			get { return profit == 0 ? "" : profit.ToString("N0"); }
		}

	}
}
