using Business_Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class Person
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public IStudyBehaviour studyBehaviour = new CantStudy();
        public IPlantTreesBehaviour plantTreesBehaviour = new CantPlantTrees();
        public IWritePoemsBehaviour writePoemsBehaviour = new CantWritePoems();
        public Person() { }
        public Person(string first_Name, string last_Name, string gender)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Gender = gender;
        }
        public string[] getBehaviours()
        {
            string[] behaviours = new string[0];
            if (studyBehaviour is not CantStudy)
            {
                Array.Resize(ref behaviours, behaviours.Length + 1);
                behaviours[behaviours.Length - 1] = "Study";
            }
            if (writePoemsBehaviour is not CantWritePoems)
            {
                Array.Resize(ref behaviours, behaviours.Length + 1);
                behaviours[behaviours.Length - 1] = "Write a poem";
            }
            if (plantTreesBehaviour is not CantPlantTrees)
            {
                Array.Resize(ref behaviours, behaviours.Length + 1);
                behaviours[behaviours.Length - 1] = "Plant a tree";
            }
            return behaviours;
        }
        public void doBehaviour(string behaviour)
        {
            switch(behaviour)
            {
                case "Study": this.performStudy(); break;
                case "Write a poem": this.performWritePoem(); break;
                case "Plant a tree": this.performPlantTree(); break;
            }
        }

        public virtual void performStudy() 
        {
            studyBehaviour.Study();
        }
        public virtual void performWritePoem() 
        {
            writePoemsBehaviour.Write();
        }
        public virtual void performPlantTree() 
        {
            plantTreesBehaviour.PlantTree();
        }
        public abstract override string ToString();
    }
}