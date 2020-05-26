﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SmRecipeModifier.Core.Models
{

    public class SmItemDictionary
    {

        private readonly string _path;

        public SmItem[] Items { get; private set; }

        public SmItemDictionary(string path)
        {
            _path = path;
            Refresh();
        }

        public void Refresh()
        {
            var data = File.ReadAllText(_path);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            var list = new List<SmItem>();
            foreach (var (key, value) in dictionary)
                list.Add(new SmItem(key, value));
            Items = list.ToArray();
        }

    }

}