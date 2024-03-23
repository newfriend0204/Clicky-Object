// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("U2krsYQTjITfeR2B3m5a72PCLiO+Ri13XaQvh3DrpcVYCi9ncknAcsR2mLYedgeOVXSnecbapDXD9EHifgM1RocbiOmW3HOjxFFKibDEu9awMYGmnwGg6TmxF75zsoj3SlqLcXuZ2KpdkIug/jSJ6k372JojB++U9+FHVYuzNRjnan5QjoN58iJTk74JuKZrYMmRpxHdlwExL5MZepNTusAWdQyH5h2UK47H2BSx2EMle2fsIpATMCIfFBs4lFqU5R8TExMXEhG7oXL1puOYn3ZtqL5wQqmjqXeyKf/Ed2HK+GmFYhLouk0TlkhMUhE0kBMdEiKQExgQkBMTEsNCWVQrmvcfrrCFFkCNGAI6GDJctXRYBCDMMDCvrlzC2tCZIRARExIT");
        private static int[] order = new int[] { 10,13,12,9,6,7,9,8,8,10,10,11,13,13,14 };
        private static int key = 18;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
