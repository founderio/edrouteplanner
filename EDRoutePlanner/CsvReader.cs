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
			if (path != null && File.Exists(path))
			{
				reader = new StreamReader(path);
			}
		}

		public void Close()
		{
			if (reader != null)
			{
				reader.Close();
				reader = null;
			}
		}

		public bool IsOpen
		{
			get { return reader != null; }
		}

		public void ReadHeaders()
		{
			if (reader != null) {
				//TODO: parse when required.
				reader.ReadLine();
			}
		}

		public string[] ReadLine()
		{
			if (reader == null)
			{
				return null;
			}
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
