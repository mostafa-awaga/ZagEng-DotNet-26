using System;
using System.Runtime.InteropServices;
namespace TaskOnePartOneCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 2:
            enum FuatureType
            {
               Login,
               Export,
               AdminPanal
            }
            
            class Feature
            {
                public FuatureType Type { get; set; }
                public bool IsEnabled { get; set; }
                public bool MinRequired { get; set; }
            }
       }
    }
}