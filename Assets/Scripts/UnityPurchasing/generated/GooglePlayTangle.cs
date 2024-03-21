// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("+ixPNr3cJ64RtP3iLovieR9BXdZEOQ98vSGy06zmSZn+a3Cziv6B7GlTEYu+Kba+5UMnu+RUYNVZ+BQZJZSKvyx6tyI4ACIIZo9OYj4a9gozgpxRWvOrnSvnrTsLFakjQKlpgKopJygYqikiKqopKSj5eGNuEaDNgZtIz5zZoqVMV5KESniTmZNNiBPN231vsYkPIt1QRGq0uUPIGGmphBiqKQoYJS4hAq5grt8lKSkpLSgrxf5NW/DCU79YKNKAdymscnZoKw5Bo+KQZ6qxmsQOs9B3weKgGT3Vrv5MoowkTD20b06dQ/zgng/5znvYhHwXTWeeFb1K0Z//YjAVXUhz+kiKC7ucpTua0wOLLYRJiLLNcGCxSwqVlGb44OqjGyorKSgp");
        private static int[] order = new int[] { 5,9,10,10,8,9,8,10,9,11,10,12,13,13,14 };
        private static int key = 40;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
