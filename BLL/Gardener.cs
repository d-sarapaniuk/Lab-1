using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Gardener: Person
    {
        public int TreesPlanted { get; set; } = 0;

        public Gardener() 
        {
            plantTreesBehaviour = new PlantSomeTree();
        }
        public Gardener(string first_Name, string last_Name, string gender) : base(first_Name, last_Name, gender) 
        {
            plantTreesBehaviour = new PlantSomeTree();
        }

        public override string ToString()
        {
            return String.Format($"Gardener {First_Name} {Last_Name}, {Gender}, planted {TreesPlanted} trees");
        }
        public string ToString(bool inTable = false)
        {
            if (!inTable) return ToString();
            return String.Format("{0,-15} {1,-15} {2,-10}", First_Name, Last_Name, Gender);            
        }
        
        public override void performPlantTree()
        {
            TreesPlanted++;
            Console.Write(First_Name);
            base.performPlantTree();
            Console.WriteLine($"{First_Name} has planted {TreesPlanted} trees total.");
        }
    }
}
