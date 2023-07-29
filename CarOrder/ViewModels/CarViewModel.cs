using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOrder.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string BrandTitle { get; set; }
        public string ModelTitle { get; set; }
        public string BodyKitType { get; set; }
        public int DoorCount { get; set; }
        public int WindowCount { get; set; }
    }
}
