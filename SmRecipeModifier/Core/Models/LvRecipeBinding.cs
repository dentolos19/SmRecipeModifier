﻿namespace SmRecipeModifier.Core.Models
{

    public class LvRecipeBinding
    {

        public LvRecipeBinding(string name, string id, SmRecipe recipe)
        {
            Name = name;
            Id = id;
            Recipe = recipe;
        }

        public string Name { get; }

        public string Id { get; }

        public SmRecipe Recipe { get; set; }

    }

}