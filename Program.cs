using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductComponentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example stock and bundle setup
            var stock = new Stock
            {
                Id = 1,
                Designation = "test Stock",
                Lignes = new List<LigneStock>
                {
                    new LigneStock { Id = 1, IdBundle = 2, Qte = 50 }, 
                    new LigneStock { Id = 2, IdBundle = 3, Qte = 60 }, 
                    new LigneStock { Id = 3, IdBundle = 4, Qte = 60 },  
                    new LigneStock { Id = 4, IdBundle = 5, Qte = 35 },  

                }
            };

            var bundles = new List<Bundle>
            {
                new Bundle
                {
                    Id = 1,
                    Designation = "wheel",
                    Products = new List<Product>
                    {
                        new Product { Id = 1, IdBundle = 4, Nb = 1 }, 
                        new Product { Id = 2, IdBundle = 5, Nb = 1 }  
                    }
                },
                new Bundle
                {
                    Id = 2,
                    Designation = "seat"
                },
                new Bundle
                {
                    Id = 3,
                    Designation = "pedal"
                },
                new Bundle
                {
                    Id = 4,
                    Designation = "frame"
                },
                new Bundle
                {
                    Id = 5,
                    Designation = "tube"
                },
                new Bundle
                {
                    Id = 6,
                    Designation = "Bike",
                    Products = new List<Product>
                    {
                        new Product { Id = 3, IdBundle = 1, Nb = 2 }, 
                        new Product { Id = 4, IdBundle = 2, Nb = 1 },
                        new Product { Id = 5, IdBundle = 3, Nb = 2 }  


                    }
                }
            };

             var Biciclette = bundles.First(b => b.Designation == "Bike");
            int maxBundles = BundleCalculator.CalculateMaxBundles(Biciclette, bundles, stock);

            Console.WriteLine($"\nMaximum number of Biciclette bundles that can be created: {maxBundles}");
}
    }
}
