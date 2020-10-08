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
        static Dictionary<string, string> dhcp = new Dictionary<string, string>();
        static Dictionary<string, string> res = new Dictionary<string, string>();
        static List<string> com = new List<string>();
        static void ol(List<string>a,string cim)
        {
            try
            {
                StreamReader ol = new StreamReader(cim);
                try
                {
                    while (!ol.EndOfStream)
                    {
                        a.Add(ol.ReadLine());
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
        static void oldic(Dictionary<string,string>s,string falnem)
        {
            try
            {
                StreamReader ol = new StreamReader(falnem);
                try
                {
                    while (!ol.EndOfStream)
                    {
                        string[] f = ol.ReadLine().Split(';');
                        s.Add(f[0], f[1]);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void feladat(string a)
        {
            if (a.Contains("request"))
            {
               
            }
            else
            {
               
            }
        }
        static void Main(string[] args)
        {
            ol(exc,"excluded.csv");
            ol(com,"test.csv");
            oldic(dhcp,"dhcp.csv");
            oldic(res, "reserved.csv");
            foreach (var item in com)
            {
                feladat(item);
            }
            Console.ReadKey();
        }
    }
}
