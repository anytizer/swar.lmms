using dtos;
using System;
using System.Collections.Generic;

namespace libraries
{
    public class Converters
    {
        public List<ComboItem> getSourceFormats()
        {
            List<ComboItem> ci = new List<ComboItem>();

            ci.Add(new ComboItem()
            {
                Text = "Single Character SARGAM Representation",
                Value = "1",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "Proper SARGAM Representation",
                Value = "2",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "Pre-Converted/English Scales",
                Value = "3",
                ExtraValue = "",
            });

            return ci;
        }

        public List<ComboItem> beats()
        {
            List<ComboItem> ci = new List<ComboItem>();
            
            ci.Add(new ComboItem() {
                Text = "2/4",
                Value = "2/4",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "3/4",
                Value = "3/4",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "4/4",
                Value = "4/4",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "6/8",
                Value = "6/8",
                ExtraValue = "",
            });

            return ci;
        }

        public List<ComboItem> tempos()
        {
            List<ComboItem> ci = new List<ComboItem>();

            ci.Add(new ComboItem()
            {
                Text = "72",
                Value = "72",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "80",
                Value = "80",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "90",
                Value = "90",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "123",
                Value = "123",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "140",
                Value = "140",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "210",
                Value = "210",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "280",
                Value = "280",
                ExtraValue = "",
            });

            ci.Add(new ComboItem()
            {
                Text = "308",
                Value = "308",
                ExtraValue = "",
            });

            return ci;
        }
    }
}