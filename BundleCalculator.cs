using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductComponentExample
{
    class BundleCalculator
    {
        public static int CalculateMaxBundles(Bundle bundle, List<Bundle> allBundles, Stock stock)
        {
            var requiredComponents = GetRequiredComponents(bundle, allBundles);
            int maxBundles = int.MaxValue;

            foreach (var (bundleId, requiredQuantity) in requiredComponents)
            {
                var stockItem = stock.Lignes.FirstOrDefault(ls => ls.IdBundle == bundleId);
                var subBundle = allBundles.FirstOrDefault(b => b.Id == bundleId);
                
                int availableQuantity = stockItem?.Qte ?? 0;

                if (subBundle != null && subBundle.Products.Any())
                {
                    int subComponentsAvailable = CalculateMaxBundles(subBundle, allBundles, stock);
                    availableQuantity += subComponentsAvailable;
                }

                int possibleBundles = availableQuantity / requiredQuantity;
                maxBundles = Math.Min(maxBundles, possibleBundles);
            }

            return maxBundles;
        }

        private static Dictionary<int, int> GetRequiredComponents(Bundle bundle, List<Bundle> allBundles)
        {
            var requiredComponents = new Dictionary<int, int>();
            AddComponents(bundle, 1, requiredComponents, allBundles);
            return requiredComponents;
        }

        private static void AddComponents(Bundle bundle, int quantity, Dictionary<int, int> components, List<Bundle> allBundles)
        {
            foreach (var product in bundle.Products)
            {
                if (!components.ContainsKey(product.IdBundle))
                {
                    components[product.IdBundle] = 0;
                }
                components[product.IdBundle] += quantity * product.Nb;
            }
        }
    }
}