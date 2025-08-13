using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Utilities.CommonDTOs
{
    public class ResponseDTO<T>
    {
        public int Status { get; set; } = 1;
        public string Message { get; set; } = "";
        public T Data { get; set; }
    }
}
