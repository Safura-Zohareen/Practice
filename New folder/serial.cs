using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using SampleConApp.Day2;

namespace SampleConApp.Day4
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class Serialization
    {
        static void Main(string[] args)
        {
            binaryExample();
            //xmlExample();
            Console.ReadKey();
        }

        private static void binaryExample()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializing();
            else
                serializing();
           // serializing();
           // deserializing();
        }

        private static void deserializing()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Student s  = fm.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            fs.Close();
        }

        private static void serializing()
        {
            //What to serialize:
            Student s = new Student { Address = "Mysore", Name = "Martin", Phone = 23423423 };
            //how to serialize:
            BinaryFormatter fm = new BinaryFormatter();
            //Where to serialize:
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, s);
            fs.Close();
        }

        private static void xmlExample()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializingXml();
            else
                serializingXml();
        }

        private static void deserializingXml()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
                Student s = (Student)sl.Deserialize(fs);
                //old style type casting(UNBOXING)
                Console.WriteLine(s);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializingXml()
        {
            Student s = new Student();
            s.Name = MyConsole.getString("Enter the name");
            s.Address = MyConsole.getString("Enter the address");
            s.Phone = MyConsole.getNumber("Enter the landline Phone no");
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, s);
            fs.Flush();//Clears the buffer into the destination so that no unused stream is left over before U close the Stream...
            fs.Close();

        }
    }
}