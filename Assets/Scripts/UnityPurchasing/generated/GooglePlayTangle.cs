// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("+kjL6PrHzMPgTIJMPcfLy8vPyslo6Vl+R9l4MeFpz2aralAvkoJTqSccr7kSILFdusowYpXLTpCUisnsZp71r4V891+oM30dgNL3v6qRGKpjeaotfjtAR661cGaomnF7ca9q8RyuQG7Grt9Wjax/oR4CfO0bLJk60WB+s7gRSX/JBU/Z6fdLwaJLi2KjQQByhUhTeCbsUTKVIwBC+983TIux82lcy1RcB6HFWQa2gje7Gvb7LzmfjVNr7cA/sqaIVluhKvqLS2bHdmhdzphVwNriwOqEbayA3PgU6BjOrdRfPsVM81YfAMxpAJv9o780ptvtnl/DUDFOBKt7HImSUWgcYw5Iy8XK+kjLwMhIy8vKG5qBjPNCL+h3doQaAghB+cjJy8rL");
        private static int[] order = new int[] { 0,6,11,13,4,12,8,7,10,13,11,12,13,13,14 };
        private static int key = 202;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
