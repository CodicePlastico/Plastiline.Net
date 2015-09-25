namespace Plastiline.Core.Mapping
{
    public static class DynamicMapper
    {
        public static short? ToShort(dynamic d)
        {
            return d != null ? short.Parse(d.ToString()) : null;
        }
    }
}
