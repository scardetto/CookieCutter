namespace CookieCutter
{
    internal class RecordAccessor
    {
        private readonly char[] _buffer;

        internal char[] CharBuffer
        {
            get { return _buffer; }
        }

        public RecordAccessor(string recordData)
        {
            _buffer = recordData.ToCharArray();
        }

        public string GetValue(int startPosition, int length)
        {
            var copy = new char[length];
            BlockCopy(_buffer, startPosition, copy, 0, length);
            return copy.ToString().Trim();
        }

        public void SetValue(int startPosition, string value)
        {
            char[] newValue = value.ToCharArray();
            BlockCopy(newValue, 0, _buffer, startPosition + 1, newValue.Length);
        }

        private static void BlockCopy(char[] source, int sourceOffset, char[] destination, int destinationOffset, int count)
        {
            for (int i = 0; i < count; i++) {
                destination[destinationOffset + i] = source[sourceOffset + i];
            }
        }

    }
}
