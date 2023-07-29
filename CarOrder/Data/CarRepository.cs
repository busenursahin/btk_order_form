using CarOrder.Models;
using CarOrder.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOrder.Data
{
    public class CarRepository : GenericRepository<Car>
    {
        public List<CarViewModel> GetCarViewModelList()
        {
            List<CarViewModel> carList = new List<CarViewModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT Car.Id, Brand.Title AS BrandTitle, Model.Title AS ModelTitle, BodyKit.Title AS BodyKitTitle,
                    WindowCount, DoorCount
                    FROM Car
                    INNER JOIN Brand ON Car.BrandId = Brand.Id
                    INNER JOIN Model ON Car.ModelId = Model.Id
                    INNER JOIN BodyKit ON Car.BodyKitId = BodyKit.Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                carList.Add(new CarViewModel { 
                                    Id = (int)reader["Id"],
                                    BrandTitle = (string)reader["BrandTitle"],
                                    ModelTitle = (string)reader["ModelTitle"],
                                    BodyKitType = (string)reader["BodyKitTitle"],
                                    DoorCount = Convert.ToInt32(reader["DoorCount"]),
                                    WindowCount = Convert.ToInt32(reader["WindowCount"])
                                });

                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return carList;
        }
    }
}
