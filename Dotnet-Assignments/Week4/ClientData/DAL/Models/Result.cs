using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Result
    {
        public int status { get; set; }

        public string message { get; set; }

        public List<ClientData>? ClientList { get; set; }
    }
}
