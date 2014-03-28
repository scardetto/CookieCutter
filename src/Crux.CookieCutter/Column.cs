using System;

namespace Crux.CookieCutter
{
	public enum ColumnType
	{
		Alphanumeric,
		Numeric
	}

	public enum ColumnOrientation
	{
		Left,
		Right
	}

	internal class Column
	{
		private const char DEFAULT_PADDING_CHAR = ' ';

		public string Name { get; set; }
		public int StartPosition { get; set; }
		public int Length { get; set; }
		public ColumnType Type { get; set; }
		public ColumnOrientation Orientation { get; set; }

		internal string DefaultValue { get; set; }
		internal char PaddingChar { get; set; }

		public Column(string name, int lenght, ColumnType type, ColumnOrientation orientation, char paddingChar)
		{
			Name = name;
			Length = lenght;
			Type = type;
			Orientation = orientation;
			PaddingChar = paddingChar;

			DefaultValue = String.Empty.PadLeft(lenght, PaddingChar);
		}

		public Column(string name, int lenght, ColumnType type)
			: this(name, lenght, type, ColumnOrientation.Left, DEFAULT_PADDING_CHAR) { }

		public Column(string name, int lenght)
			: this(name, lenght, ColumnType.Alphanumeric) { }

		internal Column(int length)
			: this("", length) { }
	}
}
