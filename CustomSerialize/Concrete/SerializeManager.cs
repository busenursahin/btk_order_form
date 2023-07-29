using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSerialize.Abstract;

namespace CustomSerialize.Concrete
{

    public class SerializeManager<T>
    {
        private readonly ICustomSerialize<T> _customSerialize;
        public SerializeManager(ICustomSerialize<T> customSerialize)
        {
            _customSerialize = customSerialize;
        }

        public void CustomSerialize(T entity, string path = "")
        {
            _customSerialize.CustomSerialize(entity, path);
        }

        public T CustomDeserailize(string path = "")
        {
            return _customSerialize.CustomDeserailize(path);
        }

    }
}