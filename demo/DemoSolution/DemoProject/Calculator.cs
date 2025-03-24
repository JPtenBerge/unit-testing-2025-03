using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject;

public class Calculator
{
    public int Result { get; set; }
    public void Add(int x)
    {
        Result += x;
    }
}
