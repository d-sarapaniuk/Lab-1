using BLL;
using System.Diagnostics;
using System.Reflection;

namespace PL
{
    public class Menu
    {
        private int selectedOption = 0;
        private string[] options = {"View the database",
            "Add a person",
            "Calculate the number and get the data\n   of 3rd-year male students living in a dormitory",
            "Exit"};
        private DB_Agent DB_Agent;

        public Menu()
        {
            DB_Agent = new DB_Agent();
        }
        public void start()
        {
            selectedOption = 0;
            string[] options =
           {"View the database",
            "Add a person",
            "Perform actions",
            "Calculate the number and get the data\n   of 3rd-year male students living in a dormitory",
            "Exit"};
            int selected = getChosenOption(options);
            switch (selected)
            {
                case 0: databaseOptions(); break;
                case 1: addingOptions(); break;
                case 2: showListOfEveryone(); break;
                case 3: filter(); break;
                case 4: exit(); break;
            }
        }
        private void displayOptions(string[] options, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < options.Length; i++)
            {
                string prefix;
                if (i == selectedOption)
                {
                    prefix = " > ";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = "   ";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(prefix + options[i]);
            }
            Console.ResetColor();
        }
        private int getChosenOption(string[] options, string title = "Choose an option using ↑↓ and ENTER:")
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                displayOptions(options, title);

                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption == options.Length) selectedOption = 0;
                }
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption == -1) selectedOption = options.Length - 1;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return selectedOption;
        }

        private void databaseOptions()
        {
            this.DB_Agent.refresh();
            selectedOption = 0;
            string[] options =
           {"Database of students",
            "Database of sellers",
            "Database of gardeners"};
            int selected = getChosenOption(options);
            switch (selected)
            {
                case 0: getDBofStudents(); break;
                case 1: getDBofSellers(); break;
                case 2: getDBofGardeners(); break;
            }
        }
        private void addingOptions()
        {
            selectedOption = 0;
            string[] options =
           {"Add a student",
            "Add a seller",
            "Add a gardener"};
            int selected = getChosenOption(options);
            Console.Clear();
            switch (selected)
            {
                case 0: addStudent(); break;
                case 1: addSeller(); break;
                case 2: addGardener(); break;
            }
        }

        private string getFromUser(Validator.Mode inputType)
        {
            string? input;
            do
            {
                Console.Write("Enter " + Validator.display[inputType] + ":  ");
                input = Console.ReadLine();

            } while (!Validator.IsValid(inputType, input));
            return input;


        }
        private void addStudent()
        {
            Student student = new Student();
            student.First_Name = getFromUser(Validator.Mode.FirstName);
            student.Last_Name = getFromUser(Validator.Mode.LastName);
            student.Gender = getFromUser(Validator.Mode.Gender);
            student.Course = Convert.ToInt16(getFromUser(Validator.Mode.Course));
            student.Student_card = getFromUser(Validator.Mode.StudentCard);
            student.Dormitory = getFromUser(Validator.Mode.Dormitory) == "yes" ? true : false;
            student.Place_of_residence = student.Dormitory == true ? getFromUser(Validator.Mode.ResidenceDorms) : getFromUser(Validator.Mode.ResidenceDefault);

            DB_Agent.addEntity(student);
            Console.WriteLine("\nA new student was successfully added to the database!");
            returnESC();
        }
        private void addSeller()
        {
            Seller seller = new Seller();
            seller.First_Name = getFromUser(Validator.Mode.FirstName);
            seller.Last_Name = getFromUser(Validator.Mode.LastName);
            seller.Gender = getFromUser(Validator.Mode.Gender);
            DB_Agent.addEntity(seller);
            Console.WriteLine("\nA new seller was successfully added to the database!");
            returnESC();
        }
        private void addGardener()
        {
            Gardener gardener = new Gardener();
            gardener.First_Name = getFromUser(Validator.Mode.FirstName);
            gardener.Last_Name = getFromUser(Validator.Mode.LastName);
            gardener.Gender = getFromUser(Validator.Mode.Gender);
            DB_Agent.addEntity(gardener);
            Console.WriteLine("\nA new gardener was successfully added to the database!");
            returnESC();
        }
        private void getDBofStudents()
        {
            Console.Clear();
            if (DB_Agent.Students.Length == 0)
            {
                Console.WriteLine("   The database of students is empty!");
                returnESC();
            }
            else
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-10} {6,-20}", "First Name", "Last Name", "Gender", "Course", "Student card", "Dormitory", "Place of residence", Console.ForegroundColor = ConsoleColor.Cyan);
                Console.ResetColor();
                foreach (Student student in DB_Agent.Students)
                {
                    Console.WriteLine(student.ToString(true));
                }
                returnESC();
            }
        }

        private void getDBofSellers()
        {
            Console.Clear();
            if (DB_Agent.Sellers.Length == 0)
            {
                Console.WriteLine("   The database of sellers is empty!");
                returnESC();
            }
            else
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-10}", "First Name", "Last Name", "Gender", Console.ForegroundColor = ConsoleColor.Cyan); ;
                Console.ResetColor();
                foreach (Seller seller in DB_Agent.Sellers)
                {
                    Console.WriteLine(seller);
                }
                returnESC();
            }
        }

        private void getDBofGardeners()
        {
            Console.Clear();
            if (DB_Agent.Gardeners.Length == 0)
            {
                Console.WriteLine("   The database of gardeners is empty!");
                returnESC();
            }
            else
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-10}", "First Name", "Last Name", "Gender", Console.ForegroundColor = ConsoleColor.Cyan);
                Console.ResetColor();
                foreach (Gardener gardener in DB_Agent.Gardeners)
                {
                    Console.WriteLine(gardener);
                }
                returnESC();
            }
        }

        private void showListOfEveryone()
        {
            selectedOption = 0;
            string[] people = new string[DB_Agent.Entities.Length];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = DB_Agent.Entities[i].ToString();
            }
            int selected = getChosenOption(people);
            showBehaviours(selected);
        }
        private void showBehaviours(int personIndex)
        {
            selectedOption = 0;
            Console.Clear();
            Person person = DB_Agent.Entities[personIndex];
            ConsoleKey keyPressed;
            string[] behaviours = person.getBehaviours();
            do
            {
                //Console.WriteLine(person);
                int selected = getChosenOption(behaviours, "Select a behaviour:");
                person.doBehaviour(behaviours[selected]);
                DB_Agent.updateFile();

                Console.WriteLine("\n   [SPACE] to perform another action\n   [ESC] to return to main menu");
                keyPressed = Console.ReadKey(true).Key;
            } while ((keyPressed != ConsoleKey.Escape) && (keyPressed != ConsoleKey.Spacebar));

            if (keyPressed == ConsoleKey.Escape) start();
            else showBehaviours(personIndex);

        }
        private void filter()
        {
            Console.Clear();
            if (DB_Agent.filter().Length ==  0)
            {
                Console.WriteLine("There are no students who are male,\nstudy in 3rd year and live in dormitory.");
                returnESC();
            }
            else
            {
                Console.WriteLine($"Number of student who are male, study in 3rd year and live in dormitory: {DB_Agent.filter().Length}");
                foreach (Student student in DB_Agent.filter())
                {
                    Console.WriteLine(student);
                }
                returnESC();
            }
            

        }

        private void returnESC ()
        {
            Console.WriteLine("\n   [ESC] to return to main menu");
            ConsoleKey keyPressed;
            do
            {
                keyPressed = Console.ReadKey(true).Key;
            } while (keyPressed != ConsoleKey.Escape);
            start();
        }
            
        private void exit()
        {
            Environment.Exit(0);
        }
    }
}