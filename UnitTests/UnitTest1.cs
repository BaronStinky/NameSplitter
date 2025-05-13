using NameSplitter;

namespace NameSplitter.Tests
{
	[TestFixture]
	public class NameSplitterTests
	{
		private NameSplitter _nameSplitter;

		public void Setup()
		{
			_nameSplitter = new NameSplitterClass();
		}

		[Test]
		public void NameSplit_TwoPartName_ReturnsFirstNameLastName()
		{
			// Arrange
			string name = "John Doe";
			string expected = "John Doe";

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_ThreePartName_ReturnsFirstNameLastName()
		{
			// Arrange
			string name = "Alice Anderson Test";
			string expected = "Alice Anderson Test"; // "Alice Anderson" is first, "Test" is last

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_SingleName_ReturnsSingleName()
		{
			// Arrange
			string name = "Alice";
			string expected = "Alice"; // Single name is treated as the first name

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_LeadingAndTrailingSpaces_ReturnsSplitName()
		{
			// Arrange
			string name = "  John Doe  ";
			string expected = "John Doe"; // Leading/trailing spaces should be trimmed

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_MultipleInternalStandardSpaces_ReturnsSplitName()
		{
			// Arrange
			string name = "Test  Test2   Test3";
			string expected = "Test Test2 Test3"; // Multiple internal spaces should be handled

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_MultipleInternalNonBreakingSpaces_ReturnsSplitName()
		{
			// Arrange
			// Using Unicode escape sequences for non-breaking spaces (\u00A0)
			string name = "Test\u00A0\u00A0Test2\u00A0\u00A0Test3";
			string expected = "Test Test2 Test3"; // Multiple internal non-breaking spaces should be handled

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_MixedInternalWhitespace_ReturnsSplitName()
		{
			// Arrange
			string name = "Test \t Test2\u00A0 Test3"; // Standard space, tab, non-breaking space
			string expected = "Test Test2 Test3"; // Mixed internal whitespace should be handled

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}


		[Test]
		public void NameSplit_EmptyString_ReturnsOriginalEmptyString()
		{
			// Arrange
			string name = "";
			string expected = ""; // HelperMethod should return false

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_NullString_ReturnsNull()
		{
			// Arrange
			string name = null;
			string expected = null; // HelperMethod should return false, and null is handled

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_StringWithOnlySpaces_ReturnsOriginalString()
		{
			// Arrange
			string name = "   ";
			string expected = "   ";

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_StringWithNumbersOnly_ReturnsOriginalString()
		{
			// Arrange
			string name = "12345";
			string expected = "12345"; // HelperMethod regex should not match

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_StringWithSpecialCharacters_ReturnsOriginalString()
		{
			// Arrange
			string name = "John Doe!";
			string expected = "John Doe!"; // HelperMethod regex should not match

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_NameWithNumberInWord_ReturnsOriginalString()
		{
			// Arrange
			string name = "Test1 Name";
			string expected = "Test1 Name"; // HelperMethod regex should not match

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NameSplit_SingleWordWithNumber_ReturnsOriginalString()
		{
			// Arrange
			string name = "Name1";
			string expected = "Name1"; // HelperMethod regex should not match

			// Act
			string actual = _nameSplitter.NameSplit(name);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
