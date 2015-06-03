using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Teacher
            Teacher Alan = new Teacher("Alan", 4, 7);
            Alan.Teach();

            Console.ReadKey();

            //Students
            Laptop sethLaptop = new Laptop("Windows", "Model-T", 1);
            Person Seth = new Person("Seth", 70, "Male", 1000);
            Seth.Laptop = sethLaptop;
            Seth.Thinking();
            Console.Write(Seth.Name + " types: " + Seth.Laptop.TypeAlotOfCode());
            Console.WriteLine("\n");

            Console.ReadKey();
            
            Laptop tylerLaptop = new Laptop("Windows", "Model-A", 1);
            Person Tyler = new Person("Tyler", 70, "Male", 1000);
            Tyler.Laptop = tylerLaptop;
            Tyler.PowerLevel += 1000;
            Console.Write(Tyler.Name + " types " + Tyler.Laptop.TypeAlotOfCode());
            Console.WriteLine("\n");

            Console.ReadKey();

            Laptop robLaptop = new Laptop("Expensive", "Pro", 9);
            Person Rob = new Person("Rob", 71, "Female", 1000);
            Rob.Laptop = robLaptop;
            Rob.Sleeping();
            Console.WriteLine("Rob slept a long time. He is now: " + Rob.getAgeInAYear() + " years old.");
            Console.Write(Rob.Name + " types " + Rob.Laptop.TypeAlotOfCode());
            Console.WriteLine("\n");

            Person[] students = new Person[3];
            students[0] = Seth;
            students[1] = Tyler;
            students[2] = Rob;

            Console.ReadKey();

            //Classroom
            Classroom DotNetClass = new Classroom(79, 0, students);
            Console.WriteLine(DotNetClass.BetterWifi);
            DotNetClass.ActivateBetterLearningEnvironment(Alan);
            DotNetClass.ComplainAboutAirConditioning("OMGWTFBBQ I'M MELTHING");
            Console.WriteLine("Alan dismisses class.");
            Console.ReadKey();
        }
    }

    public class Classroom
    {
        //Fields
        private const string _betterWifi = "This is better Wifi! Alan said so.";
        private Person[] _students = new Person[7];

        //Properties
        public int Temperature { get; set; }
        public int LearningEnvironment { get; set; }
        public string BetterWifi
        {
            get { return _betterWifi; }
        }
        public Person[] Students
        {
            get { return _students; }
            set { _students = value; }
        }

        //Methods
        public void ActivateBetterLearningEnvironment(Teacher teach)
        {
            LearningEnvironment += teach.LearningEnvironmentStat;
        }

        public void ComplainAboutAirConditioning(string complaint)
        {
            Console.WriteLine(complaint);
        }

        //Constructor
        public Classroom(int temp, int learnEnv, Person[] students)
        {
            Temperature = temp;
            LearningEnvironment = learnEnv;
            Students = students;
        }
    }

    public class Teacher
    {
        //Properties
        public string Name { get; set; }
        public int ExperienceLevel { get; set; }
        public int LearningEnvironmentStat { get; set; }
        //Methods
        public void Teach()
        {
            Console.WriteLine("Bueller....Bueller....");
            Console.WriteLine("WAH WAH WAH WAH WAH WAH WAH");
        }

        //Constructor
        public Teacher(string name, int experience, int stat)
        {
            Name = name;
            ExperienceLevel = experience;
            LearningEnvironmentStat = stat;
        }
    }

    public class Person
    {
        //Fields
        private int _powerLevel;
        
        //Automatic properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Laptop Laptop { get; set; }
        //Custom property
        public int PowerLevel
        {
            get { return _powerLevel;  }
            set
            {
                //if a damn liar
                if (value > 9000)
                {
                    _powerLevel = 9000;
                }
                //if not a liar
                if (value < 9000)
                {
                    _powerLevel = value;
                }
            }
        }

        //Methods
        public void Thinking()
        {
            --PowerLevel;
            Console.WriteLine("Ouch - I thought too hard. :(");
        }

        public void Sleeping()
        {
            PowerLevel++;
            Console.WriteLine("ZZZZZZZZZZzzzzzzzzzzzzzzZZZZZZZZZZ");
        }

        public int getAgeInAYear()
        {
            return Age + 1;
        }

        //Constructors
        public Person()
        {

        }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, int age, string gender, int powerlevel)
        {
            Name = name;
            Age = age;
            Gender = gender;
            PowerLevel = powerlevel;
        }
    }

    public class Laptop
    {

        public string OperatingSystem { get; set; }
        public string ModelName { get; set; }
        public int BatteryLife { get; set; }

        public string TypeAlotOfCode()
        {
            return "TYPE TYPE TYPE CODE CODE TYPE TYPE TYPE";
        }

        public Laptop(string os, string modelName, int batteryLife)
        {
            OperatingSystem = os;
            ModelName = modelName;
            BatteryLife = batteryLife;
        }
    }
}
