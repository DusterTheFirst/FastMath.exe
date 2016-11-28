using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Fast_Math_exe {
    /// <summary>
    /// Main Class
    /// </summary>
    class Program : ConsoleApplication {
        static int problems = 25;
        /// <summary>
        /// Master Method
        /// </summary>
        /// <param name="args">Arguments</param>
        static void Main(string[] args) {
            //COMPARE(new Record(new List<decimal>(problems) { 100m, 2m, 3m, 4m, 5m, 6m, 7m, 800m, 090m, 10m, 11m, 12m, 13m, 140m, 15m, 1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 9m, 10m }, 200m, 5m, "Zach", DateTime.Now, 100.00m), new Record(new List<decimal>(problems) { 1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 90m, 10m, 11m, 12m, 13m, 14m, 105m, 1m, 2m, 3m, 4m, 5m, 6m, 7m, 80m, 90m, 10m }, 20m, .7m, "Zach", DateTime.UtcNow, 21.0m));
            //TODO MAKE SUDRE ALL DIVISION RETURN WHOLE NUMS
            //TODO DO.
            //TODO MAth Chec, 25 Probs Always, Save
            //Welcome
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, Welcome To Fast Math");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A Reboot Of Speed Math Written In Java By Dusterthefirst, By Dusterthefirst");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------------------------------------");
            WaitForEnter("continue");
            //Select Math Type
            Console.WriteLine("Type Addition, Subtraction, Multiplication, Division, Squaring, To Do The Maths Or None To Exit");
            //Take Input
            string typez = Console.ReadLine();
            //Parse String
            Types.MathTypes type = Types.ParseMathType(typez);
            //Check Type
            if (!type.Equals(Types.MathTypes.none)) {
                Console.WriteLine("You Chose {0}, You Will Be Asked {1} {0} Problems.", type.ToString(), problems);
            } else {
                Console.WriteLine("You Mystyped Or Typed None...");
                WaitForEnter("exit");
                return;
            }
            Record record = new Record(new List<decimal>(problems), 0.0m, 0.0m, "null", DateTime.Now, 0.0m);
            //Switches Math Questionererere
            switch (type) {
                case Types.MathTypes.addition:
                    break;
                case Types.MathTypes.subtraction:
                    break;
                case Types.MathTypes.multiplication:
                    break;
                case Types.MathTypes.division:
                    break;
                case Types.MathTypes.squaring:
                    break;
            }
            //Ask To Compare
            Console.WriteLine("Type L To Load Or Any Other Key To Exit");
            //get key
            string keyy = Console.ReadKey().Key.ToString();
            bool load = keyy == "s" || keyy == "S";
            Console.WriteLine("");
            //Check If U Want To Save
            if (load) {
                Console.WriteLine("Enter Absolute Path To The File");
                //Load A Record To Compare
                Record loaded = LOAD(Console.ReadLine(), Types.MathTypes.division);
                //Compares And Prints Out Records
                COMPARE(loaded, record);
            }
            //Ask To Save
            Console.WriteLine("Type S To Save Or Any Other Key To Exit");
            //Get Key
            string key = Console.ReadKey().Key.ToString();
            bool save = key == "s" || key == "S";
            Console.WriteLine("");
            //Check If U Want To Save
            if (save) {
                //Enter Name For Record
                Console.WriteLine("Please Enter The Name Of The Record Holder");
                string namerecord = Console.ReadLine();
                //File Opt
                Console.WriteLine("Enter Path To Directory For File");
                string path = Console.ReadLine();
                Console.WriteLine("Enter Name For File");
                string name = Console.ReadLine();
                //Save Your Record
                SAVE(path, name, Types.MathTypes.division, record);
            }
            //Wait For Enter
            WaitForEnter("exit");
        }

        /// <summary>
        /// Compares The Two Records And Returns A String List Of Info About Each Problem 
        /// </summary>
        /// <param name="loaded">The Loaded Record</param>
        /// <param name="current">The Current Record</param>
        static void COMPARE(Record loaded, Record current) {

            //Wait
            WaitForEnter("print out comparison");

            //Compiles Each Problem
            for (int i = 0; i < problems; i++) {
                ConsoleColor precolor = Console.ForegroundColor;
                decimal pre = loaded.problemTimes[i];
                decimal now = current.problemTimes[i];
                decimal dif = pre - now;
                ConsoleColor color = ConsoleColor.Red;
                if (dif > 0m) {
                    color = ConsoleColor.Green;
                }
                if (dif == 0m) {
                    color = ConsoleColor.Yellow;
                }
                Console.ForegroundColor = color;
                Console.WriteLine("{0}/{1}---------", i + 1, problems);
                Console.WriteLine("Previous Time: {0}", pre.ToString());
                Console.WriteLine("Current Time: {0}", now.ToString());
                Console.WriteLine("You Were {0} Seconds Faster", dif);
                Console.ForegroundColor = precolor;
            }
            //Compiles Other Info
            decimal preTime = loaded.totalTime;
            decimal preAvTime = loaded.averageTime;
            decimal nowTime = current.totalTime;
            decimal nowAvTime = current.averageTime;
            //Differences
            decimal timeDif = preTime - nowTime;
            decimal timeAvDif = preAvTime - nowAvTime;
            //Colorchage
            ConsoleColor precolorTime = Console.ForegroundColor;
            ConsoleColor colorTime = ConsoleColor.Red;
            if (timeDif > 0m) {
                colorTime = ConsoleColor.Green;
            }
            if (timeDif == 0m) {
                colorTime = ConsoleColor.Yellow;
            }
            //CW
            Console.ForegroundColor = colorTime;
            Console.WriteLine("--------------");
            Console.WriteLine("Previous Total Time: {0}", preTime);
            Console.WriteLine("Current Total Time: {0}", nowTime);
            Console.WriteLine("Your Total Time Was {0} Seconds Faster", timeDif);
            //Colorchange
            colorTime = ConsoleColor.Red;
            if (timeAvDif > 0m) {
                colorTime = ConsoleColor.Green;
            }
            if (timeAvDif == 0m) {
                colorTime = ConsoleColor.Yellow;
            }
            //CW
            Console.ForegroundColor = colorTime;
            Console.WriteLine("--------------");
            Console.WriteLine("Previous Average Time: {0}", preAvTime);
            Console.WriteLine("Current Average Time: {0}", timeAvDif);
            Console.WriteLine("Your Average Speed Was {0} Seconds Faster", nowAvTime);
            Console.ForegroundColor = precolorTime;
            //Holders
            string holder = loaded.holder.ToLower().Equals(current.holder.ToLower()) ? String.Format("Previous Holder: {0}, Current Holder: {1}", loaded.holder, current.holder) : String.Format("Holder For Both: {0}", current.holder);
            //Dates
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("--------------");
            string date = String.Format("Previous Date: {0}, Current Date {1}", loaded.date, current.date);
            Console.WriteLine(date);
            //Score
            ConsoleColor precolorScore = Console.ForegroundColor;
            decimal preScore = loaded.score;
            decimal nowScore = current.score;
            decimal difScore = nowScore - preScore;
            ConsoleColor colorScore = ConsoleColor.Red;
            if (difScore > 0m) {
                colorScore = ConsoleColor.Green;
            }
            if (difScore == 0m) {
                colorScore = ConsoleColor.Yellow;
            }
            Console.ForegroundColor = colorScore;
            Console.WriteLine("--------------");
            Console.WriteLine("Previous Score: {0}", preScore.ToString());
            Console.WriteLine("Current Score: {0}", nowScore.ToString());
            Console.WriteLine("You Were {0} Points Better", difScore);
            Console.ForegroundColor = precolorScore;
            Console.WriteLine("--------------");
        }

        /// <summary>
        /// Save Record File
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="name">Name</param>
        /// <param name="type">Type Of File</param>
        /// <param name="record">Record Variable</param>
        static void SAVE(string path, string name, Types.MathTypes type, Record record) {
            //Json Serialize
            string json = JsonConvert.SerializeObject(record);
            //Make Extention
            string ext = "";
            switch (type) {
                case Types.MathTypes.addition:
                    ext = "fmar";
                    break;
                case Types.MathTypes.subtraction:
                    ext = "fmsr";
                    break;
                case Types.MathTypes.multiplication:
                    ext = "fmmr";
                    break;
                case Types.MathTypes.division:
                    ext = "fmdr";
                    break;
                case Types.MathTypes.squaring:
                    ext = "fmqr";
                    break;
            }
            //Compiles File Dir, Name, And Ext.
            string abspath = path + name + "." + ext;
            if (File.Exists(abspath)) {
                //Create File If It Doesnt Exist
                File.Create(abspath).Close();
            }
            //Write JSON
            File.WriteAllText(abspath, json);
            //Tell Saved
            Console.WriteLine("{0} Was Created", abspath);
        }

        /// <summary>
        /// Load Record File
        /// </summary>
        /// <param name="s">Path</param>
        /// <param name="type">Type Of Math It Should Be</param>
        static Record LOAD(string s, Types.MathTypes type) {
            //Checks If File Exists
            if (!File.Exists(s)) {
                Console.WriteLine("{0} Does Not Exist", s);
                return null;
            }
            //Makes Sure It Is The Right Type Of Record
            Types.MathTypes intype = Types.MathTypes.none;
            switch (FileManager.GetExt(s)) {
                case "fmar":
                    intype = Types.MathTypes.addition;
                    break;
                case "fmsr":
                    intype = Types.MathTypes.subtraction;
                    break;
                case "fmmr":
                    intype = Types.MathTypes.multiplication;
                    break;
                case "fmdr":
                    intype = Types.MathTypes.division;
                    break;
                case "fmqr":
                    intype = Types.MathTypes.squaring;
                    break;
                default:
                    intype = Types.MathTypes.none;
                    break;
            }
            //Quits If Wrong Type
            if (!type.Equals(intype)) {
                Console.WriteLine("{0} Is A(n) {2} File And Not A(n) {1} File", FileManager.GetName(s), type.ToString(), intype.ToString());
                return null;
            }
            string json = File.ReadAllText(s);
            Record record = JsonConvert.DeserializeObject<Record>(json);
            return record;
        }

    }

    /// <summary>
    /// Holds All Math Checkers
    /// </summary>
    class Math {
        /// <summary>
        /// Checks If Two Numbers Devide Into A Whole Number
        /// </summary>
        /// <param name="divisor"></param>
        /// <param name="dividend"></param>
        /// <returns></returns>
        public static bool isDivInt(int divisor, int dividend) {
            return false;
        }
        public bool checkMath(int a, int b, int ans, Types.MathTypes type) {
            switch (type) {

            }
            return false;
        }
    }

    /// <summary>
    /// Holds Enums And Enum Parsers
    /// </summary>
    class Types {
        /// <summary>
        /// Parse String To MathType Enum Value
        /// </summary>
        /// <param name="s">Imput String</param>
        /// <returns>Parsed Output</returns>
        public static MathTypes ParseMathType(string s) {
            //Stores Enum Types And Equal String Values In Lists
            string[] types = { "addition", "subtraction", "multiplication", "division", "squaring", "none" };
            MathTypes[] mathtypes = { MathTypes.addition, MathTypes.subtraction, MathTypes.multiplication, MathTypes.division, MathTypes.squaring, MathTypes.none };
            //Counter
            int c = 0;
            //Checks If Input Equal To A String In The List
            foreach (string t in types) {
                if (s.ToLower().Equals(t)) {
                    break;
                }
                c++;
            }
            //Returns Enum Type
            if (!(c >= types.Length)) {
                return mathtypes[c];
            }
            return MathTypes.none;
        }
        /// <summary>
        /// Math Type Enum
        /// </summary>
        public enum MathTypes {
            addition, subtraction, multiplication, division, squaring, none
        }
    }

    /// <summary>
    /// File Manager Class
    /// </summary>
    class FileManager {
        //File Extention Diilimener
        static char[] fileextdil = { '.' };
        //File Devider Diilimener
        static char[] filedividerdil = { '\\', '/' };
        /// <summary>
        /// Gets File Extention Of A Giver File Path
        /// </summary>
        /// <param name="path">File Path And Name</param>
        /// <returns>File Extention</returns>
        public static string GetExt(string path) {
            string[] ext = path.Split(fileextdil);
            return ext[ext.Length - 1];
        }
        /// <summary>
        /// Gets Name Of Given File
        /// </summary>
        /// <param name="path">File Path</param>
        /// <returns>File Name</returns>
        public static string GetName(string path) {
            string[] ext = path.Split(filedividerdil);
            return ext[ext.Length - 1];
        }
    }

    /// <summary>
    /// Class With Utilties For All Console Applications
    /// </summary>
    abstract class ConsoleApplication {
        /// <summary>
        /// Pauses Thread Until Enter Key Pressed
        /// </summary>
        /// <param name="reason">Reason You Are Pausing</param>
        public static void WaitForEnter(string reason) {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(string.Format("Press enter to {0}...", reason));
            Console.ReadLine();
            Console.ForegroundColor = prev;
        }
    }
}
