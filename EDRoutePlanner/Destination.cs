using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDRoutePlanner
{
	public class Destination
	{
		public string system;
		public string station;

		public List<Transaction> transactions;

		public Destination()
		{
			transactions = new List<Transaction>();
		}
	}
}
