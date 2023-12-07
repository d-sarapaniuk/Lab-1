using DAL;
using System;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace BLL

{
    public class DB_Agent
    {
        private Person[] entities = new Person[0];
        private Student[] students = new Student[0];
        private Seller[] sellers = new Seller[0];
        private Gardener[] gardeners = new Gardener[0];
        public Person[] Entities { get { return entities; } }
        public Student[] Students { get { return students; } }
        public Seller[] Sellers { get { return sellers; } }
        public Gardener[] Gardeners { get { return gardeners; } }
        public DB_Agent()
        {
            getEntities(DB.load());

        }
        public void refresh()
        {
            getEntities(DB.load());
        }
        private void getEntities(string fileText)
        {
            string[] strings = fileText.Split('\n');
            int i = 0;
            int k = 1;
            int entity_index = 0;
            int student_index = 0;
            int seller_index = 0;
            int gardener_index = 0;
            while (i < strings.Length)
            {
                if (strings[i] == "}")  //found a person
                {
                    // placing object properties into a dictionary

                    string className = strings[k].Split(' ')[0];
                    
                    Dictionary<string, string> classProperties = new Dictionary<string, string> ();
                    for (int propN = k+2; propN < i; propN++)
                    {
                        string[] PropAndVal = strings[propN].Split(": ");
                        classProperties.Add(PropAndVal[0], PropAndVal[1]);
                    }       


                    // creating an instance

                    var entityType = Type.GetType("BLL." + className) ?? throw new Exception("Unknown Entity");
                    var entity = Activator.CreateInstance(entityType);

                    // assigning properties

                    foreach (var property in classProperties)
                    {
                        var propInfo = entityType.GetProperty(property.Key);
                        propInfo?.SetValue(entity,
                            Convert.ChangeType(property.Value, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType)
                            , null);


                    }


                    // adding the new object to arrays

                    entity_index++;
                    Array.Resize(ref entities, entity_index);
                    entities[entity_index - 1] = (Person)entity;                    

                    if (className == "Student")
                    {
                        student_index++;
                        Array.Resize(ref students, student_index);
                        students[student_index - 1] = (Student)entity;                        
                    }
                    if (className == "Seller")
                    {
                        seller_index++;
                        Array.Resize(ref sellers, seller_index);
                        sellers[seller_index - 1] = (Seller)entity;                        
                    }
                    if (className == "Gardener")
                    {
                        gardener_index++;
                        Array.Resize(ref gardeners, gardener_index);
                        gardeners[gardener_index - 1] = (Gardener)entity;                        
                    }


                    k = i + 1;

                }
                i++;
            }

        }
        public void updateFile()
        {
            DB.clean();
            foreach (var entity in entities)
            {
                DB.write(entity, entity.Last_Name);
            }
        }
        public Student[] filter()
        {
            Student[] filteredStudents = new Student[0];
            int i = 0;
            foreach (Student student in students)
            {
                if (student.Course == 3 && student.Gender == "male" && student.Dormitory == true)
                {
                    Array.Resize(ref filteredStudents, i + 1);
                    filteredStudents[i] = student;
                    i++;
                }
            }
            return filteredStudents;
        }

        public void addEntity (Person person)
        {
            if (person.GetType().Name == "Student")
            {
                DB.write(person, person.Last_Name);
            }
            else
            {
                DB.write(person, person.First_Name);
            }
        }
    }
}