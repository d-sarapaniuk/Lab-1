﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IWritePoemsBehaviour
    {
        void Write();
    }
    public class WriteFunnyPoem : IWritePoemsBehaviour
    {
        public void Write()
        {
            Console.WriteLine(" is writing a funny poem...");
        }
    }
    public class WriteSadPoem : IWritePoemsBehaviour
    {
        public void Write()
        {
            Console.WriteLine(" is writing a sad poem...");
        }
    }
    public class CantWritePoems : IWritePoemsBehaviour
    {
        public void Write() 
        {
            Console.WriteLine(" can't write poems!");
        }
    }
}
