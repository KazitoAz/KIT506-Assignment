using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public class Supervision
    {
        public int Supervisor { get; set; } //researcher table supervisor_id
        public int SupervisingStudent { get; set; } //researcher table id
    }
}
