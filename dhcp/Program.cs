using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dhcp
{
    class Program
    {
        static List<string> exc = new List<string>();
        static void exol()
        {
            try
            {
                StreamReader ol = new StreamReader("excluded.csv");
                try
                {
                    while (!ol.EndOfStream)
                    {
                        exc.Add(ol.ReadLine());
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                ol.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        static string cimegyenlő(string cim)
        {
            string[] asd = cim.Split('.');
            int de = int.Parse(asd[3]);
            if (de<255)
            {
                de++;
            }
            string das = asd[0]+"." + asd[1] + "." + asd[2] + "." + Convert.ToString(de);
            return das;
        }
        static void Main(string[] args)
        {
            exol();
            
            Console.ReadKey();
        }
    }
}
