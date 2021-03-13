using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Models;

namespace DataBase.DataInfo

{
    public class Datausers
    {
        public static List<user> Users { get; set; } = new List<user>();

        public static bool IsCreateUser { get; set; } = true;

    }
}
