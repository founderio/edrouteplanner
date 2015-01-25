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
			// Match for "key = value", Quotes optional, ignores space around the '='
			Match match = Regex.Match(line, "^([a-zA-Z0-9]+)\\s*=\\s*\"?(.*)\"?$");
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
