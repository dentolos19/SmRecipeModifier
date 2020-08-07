﻿using System.Windows;
using System.Windows.Controls;
using SmRecipeModifier.Core.Models;

namespace SmRecipeModifier.Graphics
{

    public partial class WnModifyRequirement
    {

        public SmRequirement RequirementResult { get; }

        public WnModifyRequirement(SmRequirement requirement = null)
        {
            RequirementResult = requirement;
            InitializeComponent();
            var index = -1;
            var count = -1;
            foreach (var item in App.AvailableItems)
            {
                count++;
                if (requirement != null && item.Id.Equals(requirement.Id))
                    index = count;
                ItemList.Items.Add(new ComboBoxItem { Content = item.InGameName ?? item.Name, Tag = item });
            }
            ItemList.SelectedIndex = 0;
            if (requirement == null)
            {
                RequirementResult = new SmRequirement();
                QuantityBox.Value = 0;
                return;
            }
            QuantityBox.Value = requirement!.Quantity;
            if (!(index <= 0))
                ItemList.SelectedIndex = index;
        }

        private void Continue(object sender, RoutedEventArgs args)
        {
            var item = (ComboBoxItem)ItemList.SelectedItem;
            RequirementResult.Quantity = (int)QuantityBox.Value!;
            RequirementResult.Id = ((SmItem)item.Tag).Id;
            DialogResult = true;
            Close();
        }

    }

}