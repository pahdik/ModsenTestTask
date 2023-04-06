using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.BLL.Models
{
    public class ResponseAuthModel
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
