using System.Collections.Generic;
using System.IO;

namespace CookieCutter
{
	public class FixedRecordFile
	{
		public const string DEFAULT_EXTENSION = "frf";

		private readonly IDictionary<string, ColumnSet> _columnSets;
		private ColumnSet _defaultColumnSet;
		private readonly IList<Record> _records;

		public FixedRecordFile()
		{
			_columnSets = new Dictionary<string, ColumnSet>();
			_records = new List<Record>();
		}

		public IList<Record> Records
		{
			get { return _records; }
		}

		public Record NewRecord()
		{
			return NewRecord(_defaultColumnSet);
		}

		public Record NewRecord(string columnSetName)
		{
			var columnSet = _columnSets[columnSetName];
			return NewRecord(columnSet);
		}

		private Record NewRecord(ColumnSet columnSet)
		{
			var record = new Record(columnSet);
			_records.Add(record);
			return record;
		}

		public void RegisterColumnSet(string name, ColumnSet columnSet)
		{
			var isDefault = (_columnSets.Count == 0);
			RegisterColumnSet(name, columnSet, isDefault);
		}

		public void RegisterColumnSet(string name, ColumnSet columnSet, bool isDefault)
		{
			if (isDefault) {
				_defaultColumnSet = columnSet;
			}

			_columnSets.Add(name, columnSet);
		}

		public void Save(StreamWriter writer)
		{
			foreach (var record in _records) {
				record.Write(writer);
			}

			writer.Flush();
		}
	}
}
