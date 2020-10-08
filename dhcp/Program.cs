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
            if (de<200)
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
                string[] asd = a.Split(';');
                string b = asd[1];
                if (dhcp.ContainsKey(b))
                {
                   // Console.WriteLine(dhcp[b]);
                }
                else
                {
                    if (res.ContainsKey(b))
                    {
                        Console.WriteLine($"{b} --->{res[b]}");
                        dhcp.Add(b, res[b]);
                    }
                    else
                    {
                        string indulo = "192.168.10.100";
                        int okt4 = 100;
                        while ( dhcp.ContainsValue(indulo) || res.ContainsValue(indulo) || exc.Contains(indulo) )
                        {
                            okt4++;
                            indulo = cimegyenlő(indulo);
                        }
                        if (okt4<200)
                        {
                            Console.WriteLine($"Kiosztott {b} ip:{indulo}");
                            dhcp.Add(b, indulo);
                        }
                        else
                        {
                            Console.WriteLine($"Nincs kiosztható cím erre: {b}");
                        }
                    }
                }
            }
            else 
            {
                
                string[] asd = a.Split(';');
                string b = asd[1];
               
                    foreach (var item in dhcp)
                    {
                        if (item.Value == b)
                        {
                            dhcp.Remove(item.Key);
                            break;

                        }
                    }
                    foreach (var item in res)
                    {
                        if (item.Value == b)
                        {
                            res.Remove(item.Key);
                            break;

                        }
                    }
              
                exc.Remove(b);
                Console.WriteLine("\bTÖRÖLVE: {0}",b);
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
