using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.ComponentModel;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (System.IO.File.Exists(@".\App_Data\en.json"))
            {
                using (StreamReader file = File.OpenText(@".\App_Data\en.json"))
                {
                    var jObject = JsonConvert.DeserializeObject<JObject>(file.ReadToEnd());
                    if (jObject != null && jObject.Children().Any())
                    {
                        foreach (var child in jObject.Children().ToList())
                        {
                            LoopThroughJTokens(child);
                        }
                    }


                }
            }


            Console.ReadKey();
        }

        static void LoopThroughJTokens(JToken jToken)
        {
            if(jToken != null && jToken.Children().Any())
            {
                foreach(var child in jToken.Children().ToList())
                {
                    if (child.GetType() == typeof(JValue))
                    {
                        Console.WriteLine(((JProperty)child.Parent).Name + " : " + child.ToString() + " [" + child.Path +  "]") ;
                    }
                    else
                        LoopThroughJTokens(child);
                }
            }
        }

    }
}
