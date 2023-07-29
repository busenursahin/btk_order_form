using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CustomSerialize.Abstract;

namespace CustomSerialize.Concrete
{

    public class XmlSerializationHelper<T> : ICustomSerialize<T> where T : class, new()
    {
        public void CustomSerialize(T entity,string path = "")
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream fsout = new FileStream("employee.xml", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, entity);

                    System.Console.WriteLine("Bilgiler Serialize Edildi");

                    // form reset
                    /*txtAd.Text = "";
                    txtTelefon.Text = "";
                    txtDepartman.Text = "";
                    txtMaas.Text = "";
                    dateTimePicker1.Value = DateTime.Now; */

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
            finally
            {
                fsout.Close();
            }

        }

        public T CustomDeserailize(string path = "")
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream fsin = new FileStream("employee.xml", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    return (T)xs.Deserialize(fsin);
                    System.Console.WriteLine("Object DeSerilize Edildi.");

                }
            }

            catch (Exception ex)
            {
                ex.Message.ToString();

            }

            return new T();
        }
    }

}