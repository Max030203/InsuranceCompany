using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace InsuranceCompany.Model
{
    static public class XmlWorker
    {
        static private XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataModel));

        static public void Save(DataModel data)
        {
            using (var writer = new StreamWriter("Db.xml"))
            {
                xmlSerializer.Serialize(writer, data);
            }
        }

        static public DataModel Load()
        {
            DataModel data = new DataModel();

            using (FileStream fs = new FileStream("Db.xml", FileMode.OpenOrCreate))
            {
                data = xmlSerializer.Deserialize(fs) as DataModel;
            }

            return data;    
        }
    }
}
