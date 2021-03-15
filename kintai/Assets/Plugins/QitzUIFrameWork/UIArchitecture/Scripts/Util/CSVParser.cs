using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Qitz.UISystem
{
    public class CSVParser
    {
        public static List<T> GetTeargetTypeDataFromLocalCSV<T>(string csv)
        {
            string[] stringArray = GetJsonArrayFromCSV(csv);
            List<T> _list = new List<T>();
            foreach (var json in stringArray)
            {
                var _item = JsonUtility.FromJson<T>(json);
                _list.Add(_item);

            }
            return _list;
            //return stringArray.Select(json => JsonUtility.FromJson<T>(json)).ToList();
        }

        static string[] GetJsonArrayFromCSV(string csv)
        {
            string[] lines = csv.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] jsonArray = new string[lines.Length - 1];
            List<string> data = lines.Skip(1).ToList();
            string[] head = lines[0].Split(',');
            int count = 0;
            foreach (var d in data)
            {
                string[] elements = d.Split(',');
                string json = "{\"";
                for (int i = 0; i < head.Length; i++)
                {
                    if (i != 0) json += "\"";
                    json += head[i];
                    json += "\":\"";
                    json += elements[i];
                    json += "\"";
                    if (i != head.Length - 1)
                    {
                        json += ",";
                    }
                }
                json += "}";
                jsonArray[count] = json;
                count++;
            }
            return jsonArray;
        }
    }
}
