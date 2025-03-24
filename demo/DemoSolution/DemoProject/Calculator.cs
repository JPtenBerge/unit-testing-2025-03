using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    private int MagicHelper()
    {
        return 42;
    }

    // "unit" - kleinst mogelijk ding wat je kan testen
    // - private MagicHelper in zelfde class - PRIMA
    // - public MagicHelper in zelfde class - PRIMA
    // - andereInstance.MagicHelper() in andere class - niet ok
    // - static AndereClass.MagicHelper - PRIMA
    // - MagicHelper onderdeel van .NET - PRIMA
    // - MagicHelper onderdeel van .NET wat een webservice in Zweden aanroept - niet ok
    
    // DateTime.Now
    // File.AppendAllTextAsync()
    // Logger.Log()


}
