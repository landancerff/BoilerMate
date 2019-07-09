using System;
using System.Collections.Generic;
using System.Text;

namespace BoilerMate.Models
{
    public enum MenuItemType
    {
        Jobs,
        Export,
        About,
        Settings
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
