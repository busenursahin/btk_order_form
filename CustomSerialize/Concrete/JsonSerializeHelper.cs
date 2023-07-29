using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CustomSerialize.Abstract;
using Newtonsoft.Json;

namespace CustomSerialize.Concrete
{

    public class JsonSerializationHelper<T> : ICustomSerialize<T> where T : class, new()
    {
        public void CustomSerialize(T entity, string path = "")
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, entity);
                    
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
            finally
            {

            }

        }

        public T CustomDeserailize(string path = "")
        {

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader file = File.OpenText(path))
            using (JsonReader reader = new JsonTextReader(file))
            {
                T entity = (T)serializer.Deserialize(reader, typeof(T));
               
            }


            // Dosyadan JSON verilerini oku
            string json = File.ReadAllText(path);

            // JSON verilerini T tipine çevir
            return JsonConvert.DeserializeObject<T>(json);

        }


    }
}