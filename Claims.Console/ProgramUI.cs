using Claims.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class ProgramUI
    {
        List<Claim> _claims = new List<Claim>();
        public void Run()
        {
            Console.WriteLine("1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n");
            string menuSelection = Console.ReadLine();
        }
    }
}
