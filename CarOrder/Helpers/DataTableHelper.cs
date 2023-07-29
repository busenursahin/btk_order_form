using CarOrder.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOrder.Helpers
{
    public class DataTableHelper
    {
        public DataTable GetDataTableByCarViewNodel(List<CarViewModel> carViewModels)
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Marka", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("Kasa", typeof(string));
            table.Columns.Add("Pencere Sayısı", typeof(int));
            table.Columns.Add("Kapı Sayısı", typeof(int));

            foreach (var car in carViewModels)
            {
                table.Rows.Add(car.Id, car.BrandTitle, car.ModelTitle, car.BodyKitType, car.WindowCount, car.DoorCount);
            }

            return table;
        }


    }
}
