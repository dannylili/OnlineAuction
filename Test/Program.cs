using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Test
{
    public class Program
    {
        // TestMethod dd=new 
        public static void Main(string[] args)
        {
            // TestMethod.DateTimeTest();

            // TestMethod.TestNullIntValue();

            // TestMethod.FormatStringTest();

            // TestMethod.DateTimeTest();

            /// 赋值测试
            //var boolvalue = 1 == 2 || 1 == 3;
            //var test = boolvalue;

            /// null比较测试
            /// OperatorEquals();

            //NameVerifying(firstName:"Wang");
            //NameVerifying(lastName:"Yonggui");
            // TestContainsFun();

            // StringEqauls();

            //Message message = new Message();
            //if (message.IsValid)
            //{
            //    Console.Write("so far so good if anyone can help me.");
            //}

            // StringArryToIntArry();

            int[] intArry = { };
            intArry[0] = 12;

        }

        private static void StringArryToIntArry()
        {
            var strContainQuote = "1,2,3,4,5,6";
            var ids = strContainQuote.Split(',').Select(t => int.Parse(t)).ToArray();
        }


        private static void OperatorEquals()
        {
            decimal? a = null;
            decimal b = 123.0M;
            if ((a ?? 0) <= b)
            {
                return;
            }
        }

        private static void TestContainsFun()
        {
            string str = "Void,Gook,Error";
            if (str.Contains("Gook"))
            {
                Console.Write(" str is not containt A");
                Console.ReadLine();
            }

        }

        private static void StringEqauls()
        {
            string strNorWihtespace = "testString";
            string strNorWithWihtespace = "test String";

            string strWhiteSpace = "";
            if (string.IsNullOrEmpty(strNorWihtespace) || string.IsNullOrEmpty(strNorWithWihtespace))
            {
                Console.Write("IsNullOrEmpty");
            }

            if (string.IsNullOrWhiteSpace(strNorWithWihtespace))
            {
                Console.Write("IsNullOrWhiteSpace");
            }
            if (string.IsNullOrWhiteSpace(strWhiteSpace))
            {
                Console.Write("IsNullOrWhiteSpace");
            }

        }

        private static string NameVerifying(string firstName = null, string lastName = null)
        {
            if (firstName != null)
            {
                return ("you first name is" + firstName);
            }
            if (lastName != null)
            {
                return ("you last name is" + lastName);
            }
            return string.Empty;
        }

    }


    public static class TestMethod
    {
        /// <summary>
        ///  null int set value test
        /// </summary>
        internal static void TestNullIntValue()
        {
            int? initialValue = null;
            Nullable<int> b = initialValue ?? null;
            Console.WriteLine(initialValue);
            Console.ReadLine();
        }

        internal static void FormatStringTest()
        {
            string initialValueStr = "If you know my name \"{0}\"";
            if (1 == 1)
            {
                initialValueStr = string.Format(initialValueStr, "Yonggui Wang");
            }

            Console.WriteLine(initialValueStr);
            Console.ReadKey();

            // List<string> list=new List<string>(); 
            // list.Add("a"); 
            // list.Add("b"); 
            // list.Add("c"); 

            //Console.WriteLine(string.Join(",",list)); 
            //Console.ReadKey(); 
        }

        /// <summary>
        /// C# innert operator string method
        /// </summary>
        public static void StringInnerMethodTest()
        {
            decimal name = 10.0000m;
            var precision = name.ToString().Split('.');
            if (precision.Length > 1 && Convert.ToInt32(precision[1]) == 0)
            {
                decimal testValue = 2;
                string[] testStr = testValue.ToString().Split('.');
                Console.ReadKey();
                Console.ReadLine();
            }
        }

        /// <summary>
        /// public,internal对同意程序集下的成员公开
        /// </summary>
        internal static void DateTimeTest()
        {
            var publicData = DateTime.UtcNow;
            var localData = DateTime.UtcNow.Date;

            var ticks = (new Random().Next((int)DateTime.UtcNow.Ticks));
            int random = ticks;
        }

        /// <summary>
        /// ?? use
        /// when 哦bject is null 
        /// </summary>
        public static void NullJudge()
        {
            string a = string.Empty; // null;
            string b = a ?? "string";
            Console.WriteLine(b);
            Console.ReadLine();
        }

        /// <summary>
        ///  static类不能包含protected类型的成员
        /// </summary>
        //protected static void FunForLinq()
        //{
        //    //LinkedList<string> name = new LinkedList<string>();
        //    //var title = "abc";
        //    //var click = 0;
        //    //Expression<Func<name, bool>> exp = null;
        //    //exp = n => n.CateID == 17;
        //    //if (title != "")
        //    //{
        //    //    exp = n => n.Title.Contains(title);
        //    //}
        //    //if (click > 0)
        //    //{
        //    //    exp = n => n.NewClick > click;
        //    //}
        //}

    }


    public class Message
    {
        public List<string> Notice
        {
            get
            {
                if (Notice == null)
                {
                    return Notice = new List<string>();
                }
                else
                {
                    return Notice;
                }
            }
            set
            {
                Notice = value;
            }
        }

        public bool IsValid
        {
            get
            {
                return Notice.Count > 1;
            }
            set
            {
                IsValid = value;
            }
        }

    }
    //public class TestMothodSub : TestMethod
    //{
    //    // var dd=TestMethod.test
    //}
}
