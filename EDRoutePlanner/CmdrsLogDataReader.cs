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
using System.Text.RegularExpressions;

namespace EDRoutePlanner
{
	public class CmdrsLogDataReader
	{
		public class Section
		{
			public string name;
			public IList<string> textContent;
			public IDictionary<string, Section> subsections;
			public IDictionary<string, string> dictionary;

			public Section() : this("") { }

			public Section(string name)
			{
				this.name = name;
				this.textContent = new List<string>();
				this.subsections = new Dictionary<string, Section>();
				this.dictionary = new Dictionary<string, string>();
			}
		}

		public Section rootSection;
		public string path;

		public CmdrsLogDataReader(string path)
		{
			this.path = path;
			reload();
		}

		public void reload()
		{
			rootSection = null;
			if (path == null || !File.Exists(path))
			{
				return;
			}
			string[] lines = File.ReadAllLines(path, Encoding.UTF8);

			Stack<Section> sections = new Stack<Section>();
			Section currentSection = null;

			string sectionNameCandidate = null;

			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i].Trim();
				if (line.Length == 0)
				{
					continue;
				}
				if (line == "{")
				{
					if (sectionNameCandidate == null)
					{
						throw new Exception("Unexpected section start at line " + (i + 1));
					}
					else
					{
						Section newSection = new Section(sectionNameCandidate);
						if (currentSection == null)
						{
							rootSection = newSection;
						}
						else
						{
							currentSection.subsections.Add(sectionNameCandidate, newSection);
						}
						sections.Push(newSection);
						currentSection = newSection;
						sectionNameCandidate = null;
					}
				}
				else
				{
					if (sectionNameCandidate != null)
					{
						// Process line that was discarded as section candidate
						processRegularLine(sectionNameCandidate, currentSection);
						sectionNameCandidate = null;
					}
					if (line == "}")
					{
						sections.Pop();
						if (sections.Count == 0)
						{
							return;
						}
						currentSection = sections.Peek();
					}
					else
					{
						sectionNameCandidate = line;
					}
				}

			}
			if (sectionNameCandidate != null)
			{
				// Process discarded candidate on the last line (there will not be a { after.)
				processRegularLine(sectionNameCandidate, currentSection);
			}
		}

		private void processRegularLine(string line, Section currentSection)
		{
			// Match for 'key = "value"', ignores space around the '='
			Match match = Regex.Match(line, "^([a-zA-Z0-9]+)\\s*=\\s*\"(.*)\"$");
			if (match.Success)
			{
				currentSection.dictionary[match.Groups[1].Value] = match.Groups[2].Value;
				return;
			}
			// Match for 'key = value', unquoted, ignores space around the '='
			match = Regex.Match(line, "^([a-zA-Z0-9]+)\\s*=\\s*(.*)$");
			if (match.Success)
			{
				currentSection.dictionary[match.Groups[1].Value] = match.Groups[2].Value;
				return;
			}
			// Quoted text
			match = Regex.Match(line, "^\"(.*)\"$");
			if (match.Success)
			{
				currentSection.textContent.Add(match.Groups[1].Value);
				return;
			}
			// anything else than "key = value" or "value" will be considered unquoted text
			currentSection.textContent.Add(line);
		}
	}
}
