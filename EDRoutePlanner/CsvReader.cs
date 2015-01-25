using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDRoutePlanner
{
	public class CsvReader
	{
		//private List<string> headers;
		private string path;

		private TextReader reader;

		public CsvReader(string path)
		{
			this.path = path;
		}

		public void Open()
		{
			reader = new StreamReader(path);
		}

		public void Close()
		{
			reader.Close();
			reader = null;
		}

		public bool IsOpen
		{
			get { return reader != null; }
		}

		public void ReadHeaders()
		{
			//TODO: parse when required.
			reader.ReadLine();
		}

		public string[] ReadLine()
		{
			string line = reader.ReadLine();
			if (line == null || line.Trim().Length == 0)
			{
				return null;
			}
			else
			{
				return line.Split(';');
			}
		}

	}
}
