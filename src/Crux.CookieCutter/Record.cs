using System;
using System.IO;
using System.Text;

namespace CookieCutter
{
	public class Record
	{
		private readonly ColumnSet _columnSet;
		private readonly RecordAccessor _accessor;

		internal Record(ColumnSet columnSet)
		{
			_columnSet = columnSet;
			_accessor = CreateNewAccessor();
		}

		public string this[string columnName]
		{
			get { return GetValue(columnName); }
			set { SetValue(columnName, value); }
		}

		private string GetValue(string columnName)
		{
			Column column = _columnSet[columnName];
			return _accessor.GetValue(column.StartPosition, column.Length);
		}

		private void SetValue(string columnName, string value)
		{
			Column column = _columnSet[columnName];
			double output;

			// Validate Input
			if (column.Type == ColumnType.Numeric && !Double.TryParse(value, out output)) {
				throw new FormatException(String.Format("Column {0} requires a numeric value.", columnName));
			}

			// Trim to appropriate length if required
			int valueLength = value.Length;

			if (valueLength > column.Length) {
				value = value.Substring(0, column.Length);
			} else if (valueLength < column.Length) {
				// Pad value with appropriate number of padding chars
				value = column.Orientation == ColumnOrientation.Left
						? value.PadRight(column.Length, column.PaddingChar)
						: value.PadLeft(column.Length, column.PaddingChar);
			}

			_accessor.SetValue(column.StartPosition, value);
		}

		private RecordAccessor CreateNewAccessor()
		{
			var builder = new StringBuilder(_columnSet.RecordLength);


			foreach (Column column in _columnSet.Columns) {
				builder.Append(column.DefaultValue);
			}

			return new RecordAccessor(builder.ToString());
		}

		public void Write(TextWriter writer)
		{
			writer.WriteLine(_accessor.CharBuffer);
		}
	}
}
