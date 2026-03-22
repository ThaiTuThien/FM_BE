namespace FM.API
{
    public static class MappingExtensions
    {
        public static Guid ToOracleGuid(this string hex)
        {
            if (string.IsNullOrEmpty(hex) || hex.Length != 32)
                return Guid.Empty;

            byte[] bytes = Enumerable.Range(0, hex.Length / 2)
                .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                .ToArray();
            return new Guid(bytes);
        }
    }
}
