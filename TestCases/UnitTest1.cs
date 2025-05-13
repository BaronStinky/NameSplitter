using System;
using System.Linq;
using System.Text.RegularExpressions;
using NameSplitter;
using NUnit.Framework;

namespace NameSplitter.Tests
{
	[TestFixture]
	public class NameSplitterTests
	{
		private NameSplitterClass _nameSplitter;

		[SetUp]
		public void Setup()
		{
			_nameSplitter = new NameSplitterClass();
		}

		[Test]
		public void FirstName_And_LastName()
		{
			string name = "John Doe";
			string expectedFirstName = "John";
			string expectedLastName = "Doe";

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

		[Test]
		public void Three_Names()
		{
			string name = "Alice Anderson Test";
			string expectedFirstName = "Alice Anderson";
			string expectedLastName = "Test";

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

		[Test]
		public void SingleName()
		{
			string name = "Alice";
			string expectedFirstName = "Alice";
			string expectedLastName = "";

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

		[Test]
		public void Trailing_And_Leading_Whitespaces()
		{
			string name = "  John Doe  ";
			string expectedFirstName = "John";
			string expectedLastName = "Doe";

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

		[Test]
		public void Multiple_White_Spaces_And_Three_Names()
		{
			string name = "Carl  Anders   Svensson";
			string expectedFirstName = "Carl Anders";
			string expectedLastName = "Svensson";

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}


		[Test]
		public void String_With_Numbers()
		{
			string name = "12345";
			string expectedFirstName = "Error";
			string expectedLastName = null;

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

		[Test]
		public void Name_With_Special_Characters()
		{
			string name = "John Doe!";
			string expectedFirstName = "Error";
			string expectedLastName = null;

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo(expectedFirstName));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

		[Test]
		public void EmptyName()
		{
			string name = "   ";
			string expectedFirstName = "   ";
			string expectedLastName = null;

			(string firstName, string lastName) actual = _nameSplitter.NameSplit(name);

			Assert.That(actual.firstName, Is.EqualTo("Error"));
			Assert.That(actual.lastName, Is.EqualTo(expectedLastName));
		}

	}
}
