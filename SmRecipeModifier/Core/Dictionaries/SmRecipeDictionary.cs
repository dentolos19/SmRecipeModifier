﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SmRecipeModifier.Core.Models;

namespace SmRecipeModifier.Core.Dictionaries
{

    public class SmRecipeDictionary
    {

        private readonly string _path;

        public SmRecipeDictionary(string path)
        {
            _path = path;
            Refresh();
        }

        public SmRecipe[] Items { get; private set; }

        public void Refresh()
        {
            var data = File.ReadAllText(_path);
            var dictionary = JsonConvert.DeserializeObject<List<SmRecipe>>(data);
            Items = dictionary.ToArray();
        }

    }

}