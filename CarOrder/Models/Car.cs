using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOrder.Models
{
    public class Car
    {
        public int Id { get; set; }

        public int WindowCount { get; set; }
        public int DoorCount { get; set; }

        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int BodyKitId { get; set; }
    }
}
