using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Serilization_and_Deserilization
{
    public class SerializeDemo
    {
        public static void Main(string[] args)
        {
            Person[] people =
            {
                new Person("LiMing", 18),
                new Person("WangQiang",19),
            };

            //二进制序列化
            BinaryFormatter bf = new BinaryFormatter();
            String FileName = "s.temp";
            BinarySerialize(bf, FileName, people);

            //二进制反序列化
            Person[] people2 = BinaryDeserialize(bf, FileName) as Person[];
            foreach(Person p in people)
            {
                Console.WriteLine(p);
            }

            //XML序列化
            XmlSerializer xmlser = new XmlSerializer(typeof(Person[]));
            String xmlFileName = "s.xml";
            XmlSerialize(xmlser, xmlFileName, people);

            //显示XML脚本
            string xml = File.ReadAllText(xmlFileName);
            Console.WriteLine(xml);

            Console.ReadKey();
        }

        public static void BinarySerialize(IFormatter formatter, string filename, object obj)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static object BinaryDeserialize(IFormatter formatter, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            fs.Close();
            return obj;
        }

        public static void XmlSerialize(XmlSerializer ser, string filename, object obj)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
    }
}
