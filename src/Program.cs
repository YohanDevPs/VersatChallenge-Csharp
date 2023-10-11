using EstudioCsharp.src.Domain.entities;
using EstudioCsharp.src.Domain.mocks;
using System;
using System.Drawing;
using System.Reflection;

namespace EstudioCsharp.enums
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            foreach (AccountRecord arg in MockAccountRecord.GenerateRandomAccountRecords(500)) { 
                Console.WriteLine(arg);
            }
        }
    }
}