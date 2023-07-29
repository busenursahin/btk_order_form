using CarOrder.Data;
using CarOrder.Helpers;
using CarOrder.Models;
using CustomSerialize.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarOrder
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();

        BrandRepository brandRepository = new BrandRepository();
        ModelRepository modelRepository = new ModelRepository();
        CarRepository carRepository = new CarRepository();
        BodyKitRepository bodyKitRepository = new BodyKitRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addCar = new Car();
            addCar.BrandId = ((Brand)cmbBrand.SelectedItem).Id;
            addCar.ModelId = ((Model)cmbModel.SelectedItem).Id;
                addCar.BodyKitId = ((BodyKit)cmbBody.SelectedItem).Id;
                addCar.DoorCount = Convert.ToInt32(txtDoorCount.Text);
                addCar.WindowCount = Convert.ToInt32(txtWindowCount.Text);

            
           carRepository.Add(addCar);

            RefreshGrid();

            Console.WriteLine("hehe");
            Console.WriteLine("hehe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbBrand.DataSource = brandRepository.GetList();
            cmbBrand.DisplayMember = "Title";
            cmbBrand.ValueMember = "Id";
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBrand = (Brand) cmbBrand.SelectedItem;

            cmbModel.DataSource = modelRepository.GetListWhere("Brand" , selectedBrand.Id);
            cmbModel.DisplayMember = "Title";
            cmbModel.ValueMember = "Id";

            cmbBody.DataSource = bodyKitRepository.GetList();
            cmbBody.DisplayMember = "Title";
            cmbBody.ValueMember = "Id";


            //  dataGridOrders.DataSource = (new GenericRepository<Car>()).GetList();

            RefreshGrid();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
           
           var serializeManager = new SerializeManager<List<Car>>(new JsonSerializationHelper<List<Car>>());
            serializeManager.CustomSerialize(carRepository.GetList() , @"C:\Users\Administrator\Documents\json.json");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var serializeManager = new SerializeManager<List<Car>>(new JsonSerializationHelper<List<Car>>());
            var cars = serializeManager.CustomDeserailize(@"C:\Users\Administrator\Documents\json.json");

            carRepository.Add(cars[0]);

            MessageBox.Show("veri tabanına kaydedildi");
            RefreshGrid();
        }

        public void RefreshGrid()
        {
            var carViewModelList = (new CarRepository()).GetCarViewModelList();
            table = (new DataTableHelper()).GetDataTableByCarViewNodel(carViewModelList);
            dataGridOrders.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
