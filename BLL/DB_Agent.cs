using DAL;
using System.Reflection;

namespace BLL

{
    public class DB_Agent
    {
        public static Person[] getEntities(string fileText)
        {
            Person[] entities = new Person[100];
            string[] strings = fileText.Split('\n');
            int i = 0;
            int k = 0;
            int entity_index = 0;
            while (i < strings.Length)
            {
                if (strings[i] == "}")  //found an entity
                {
                    string className = strings[k].Split(' ')[0];
                    Dictionary<string, string> classProperties = new Dictionary<string, string> ();
                    for (int propN = k+2; propN < i; propN++)
                    {
                        string[] PropAndVal = strings[propN].Split(": ");
                        classProperties.Add(PropAndVal[0], PropAndVal[1]);
                    }

                    var EntityType = Type.GetType("BLL." + className) ?? throw new Exception("Unknown Entity");
                    var Entity = Activator.CreateInstance(EntityType);

                    foreach (var property in classProperties)
                    {
                        var propInfo = EntityType.GetProperty(property.Key);
                        propInfo?.SetValue(Entity,
                        Convert.ChangeType(property.Value, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType)
                        , null);
                        
                    }
                    entities[entity_index] = (Person)Entity;


                    k = i + 1;
                    entity_index++;
                }
                i++;
            }

            return entities;
        }

    }
}