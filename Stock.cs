using System.Collections.Generic;

namespace ProductComponentExample
{
    class Stock
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public List<LigneStock> Lignes { get; set; }
    }

    
}
