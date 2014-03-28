using System.Collections.Generic;

namespace Crux.CookieCutter
{
	public class ColumnSet
	{
		private readonly IDictionary<string, Column> _namedColumns;
		private readonly IList<Column> _columns;
		private int _recordLength;

		public ColumnSet()
		{
			_namedColumns = new Dictionary<string, Column>();
			_columns = new List<Column>();
		}

		internal Column this[string name]
		{
			get { return _namedColumns[name]; }
		}

		internal IList<Column> Columns
		{
			get { return _columns; }
		}

		public void AddColumn(string name, int length, ColumnType type)
		{
			var column = new Column(name, length, type);
			AddNamedColumn(column);
		}

		public void AddColumn(string name, int length)
		{
			var column = new Column(name, length);
			AddNamedColumn(column);
		}

		public void AddColumn(string name, int length, ColumnType type, ColumnOrientation orientation, char paddingChar)
		{
			var column = new Column(name, length, type, orientation, paddingChar);
			AddNamedColumn(column);
		}

		public void AddConstant(string constantValue)
		{
			var column = new Column(constantValue.Length) { DefaultValue = constantValue };
			AddColumn(column);
		}

		public void AddPadding(int length)
		{
			var column = new Column(length);
			AddColumn(column);
		}

		private void AddNamedColumn(Column column)
		{
			column.StartPosition = GetNextStartPosition();
			_namedColumns.Add(column.Name, column);
			_columns.Add(column);
			IncrementStartPosition(column.Length);
		}

		private void AddColumn(Column column)
		{
			column.StartPosition = GetNextStartPosition();
			_columns.Add(column);
			IncrementStartPosition(column.Length);
		}

		private int GetNextStartPosition()
		{
			return (_recordLength == 0) ? 0 : _recordLength - 1;
		}

		private void IncrementStartPosition(int length)
		{
			_recordLength += length;
		}

		public int RecordLength
		{
			get { return _recordLength; }
		}
	}
}
