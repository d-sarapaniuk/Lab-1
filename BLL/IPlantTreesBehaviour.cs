using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface IPlantTreesBehaviour
    {
        void PlantTree();
    }
    public class PlantSomeTree : IPlantTreesBehaviour
    {
        public void PlantTree()
        {
            Console.WriteLine(" has planted a tree...");
        }
    }
    public class CantPlantTrees : IPlantTreesBehaviour
    {
        public void PlantTree()
        {
            Console.WriteLine(" can't plant trees!");
        }
    }

}
