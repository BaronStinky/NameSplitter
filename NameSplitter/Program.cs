
using System;
using System.Linq; 
using System.Text.RegularExpressions;
using NameSplitter;
using NUnit.Framework;

namespace NameSplitter
{
	public class NameSplitterClass
	{
		public (string firstName, string lastName) NameSplit(string userName)
		{
			string trimmedName = userName.Trim();
			if (HelperMethod(trimmedName))
			{
				string[] rawNameParts = Regex.Split(trimmedName, @"\s+");
				string[] nameParts = rawNameParts.Where(part => !string.IsNullOrWhiteSpace(part)).ToArray();

				if (nameParts.Length > 1)
				{
					string lastName = nameParts[nameParts.Length - 1];
					string firstName = string.Join(" ", nameParts.Take(nameParts.Length - 1));
					return (firstName, lastName);
				}
				if (nameParts.Length == 1)
				{
					return (nameParts[0], "");
				}
				return ("Error", null);

			}
			return ("Error", null);
		}

		public bool HelperMethod(string name)
		{

			return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$");

		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			NameSplitterClass nameSplitter = new NameSplitterClass();
		}
	}
}