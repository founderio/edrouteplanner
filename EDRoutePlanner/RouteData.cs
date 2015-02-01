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
using System.Windows.Forms;

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

	public class CommoditySorter : System.Collections.IComparer, IComparer<ListViewItem>, IComparer<ComparedCommodity>
	{
		public CommoditySorterCriteria criteria = CommoditySorterCriteria.Group;
		public SortOrder sortOrder;
		public int Compare(ListViewItem x, ListViewItem y)
		{
			if (criteria == CommoditySorterCriteria.Group)
			{
				int returnVal = 0;
				returnVal = string.Compare(x.Group.Header, y.Group.Header);
				if (sortOrder == SortOrder.Descending)
				{
					returnVal *= -1;
				}
				return returnVal;
			}

			ComparedCommodity cx = (ComparedCommodity)x.Tag;
			ComparedCommodity cy = (ComparedCommodity)y.Tag;

			return Compare(cx, cy);
		}

		public int Compare(object x, object y)
		{
			return Compare((ListViewItem)x, (ListViewItem)y);
		}

		public int Compare(ComparedCommodity cx, ComparedCommodity cy)
		{
			int returnVal = 0;
			switch (criteria)
			{
				default:
				case CommoditySorterCriteria.Group:
					// Cannot compare what we don't have
					returnVal = 0;
					break;
				case CommoditySorterCriteria.Commodity:
					returnVal = string.Compare(cx.Commodity, cy.Commodity);
					break;
				case CommoditySorterCriteria.Demand:
					returnVal = (int)cx.demand - (int)cy.demand;
					break;
				case CommoditySorterCriteria.PriceSell:
					returnVal = cx.priceSell - cy.priceSell;
					break;
				case CommoditySorterCriteria.PriceBuy:
					returnVal = cx.priceBuy - cy.priceBuy;
					break;
				case CommoditySorterCriteria.Profit:
					returnVal = cx.profitPer - cy.profitPer;
					break;
			}
			if (sortOrder == SortOrder.Descending)
			{
				returnVal *= -1;
			}
			return returnVal;
		}
	}

	public enum CommoditySorterCriteria
	{
		Group,
		Commodity,
		Demand,
		PriceSell,
		PriceBuy,
		Profit
	}
}
