using System.Collections.Generic;

namespace ProductComponentExample
{
    class Bundle
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
