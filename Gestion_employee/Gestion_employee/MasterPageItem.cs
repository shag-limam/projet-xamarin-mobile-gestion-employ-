using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_employee
{
    public class MasterPageItem
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }

    }
}
