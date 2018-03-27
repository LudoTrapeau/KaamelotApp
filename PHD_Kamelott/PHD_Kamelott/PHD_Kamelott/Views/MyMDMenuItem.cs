using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHD_Kamelott.Views
{

    public class MyMDMenuItem
    {
        public MyMDMenuItem()
        {
            TargetType = typeof(MyMDDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}