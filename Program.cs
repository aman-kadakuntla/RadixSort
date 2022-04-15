using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radix_Sort
{
    internal class Program
    {
        static void RadixSort(int[] arr)
        {
            int MaxLength = 0;
            //loop to find the maxlength of the largest number
            foreach(int i in arr)
            {
                MaxLength = Math.Max(MaxLength, i.ToString().Length);
            }
            //create an string array of size same as input array
            string[] strArray = new string[arr.Length];
            //Console.WriteLine(string.Join(" ", arr));
            // loops that makes the each digit length in the input array equal to maxlength by adding 0 to left side
            for(int i=0;i<arr.Length;i++)
            {
                string s = arr[i].ToString();
                if(s.Length!=MaxLength)
                {
                    while(s.Length!=MaxLength)
                    {
                        s = "0" + s;
                    }
                }
                strArray[i] = s;
            }
            //Console.WriteLine(string.Join(" ", strArray));
            Dictionary<char, List<string>> dict = new Dictionary<char, List<string>>();//to implement the buckets
            for(int i=MaxLength-1;i>=0;i--)
            {
                for (int i1 = 0; i1 < 10; i1++)
                {
                    if (!dict.ContainsKey(char.Parse(i1.ToString())))
                        dict.Add(char.Parse(i1.ToString()), new List<string>());
                    else
                        dict[char.Parse(i1.ToString())] = new List<string>();
                }
                for (int j=0;j<strArray.Length;j++)
                {
                    dict[strArray[j][i]].Add(strArray[j]);
                }
                int index = 0;
                foreach (KeyValuePair<char,List<string>> kv in dict)
                {
                    foreach (string k in kv.Value)
                    {
                        strArray[index] = k;
                        index++;
                    }
                }
            }
            Converter<string, int> converter = new Converter<string, int>(stringtoint);
            arr = Array.ConvertAll(strArray, converter);
            Console.WriteLine(string.Join(" ", arr));
        }
        static int stringtoint(string s)
        {
            return Convert.ToInt32(s);
        }
        static void Main(string[] args)
        {
            RadixSort(new int[] { 3, 2, 10, 45, 300 });
            RadixSort(new int[] { 98,5, 33, 2123, 980, 90 });
            Console.ReadLine();
        }
    }
}
