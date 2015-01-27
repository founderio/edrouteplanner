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
