using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new SerializeDataSaver();
        protected T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
        }

        protected void Save(string fileName, object item)
        {
            saver.Save(fileName, item);
        }
    }
}
