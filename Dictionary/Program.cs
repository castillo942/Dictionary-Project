using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Dictionary
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Dictionary<int, string> senior = new Dictionary<int, string>();
            senior.Add(60, "Jonas");
            senior.Add(72, "Theresa");
            senior.Add(89, "Dominga");
            senior.Add(100, "Meling");
            senior.Add(61, "Carlito");

            Dictionary<int, string> senior2 = new Dictionary<int, string>();
            senior2.Add(60, "Jose");
            senior2.Add(63, "Edgardo");
            senior2.Add(61, "Corazon");
            senior2.Add(100, "Kulas");
            senior2.Add(89, "Theresa");

            int close = 0;
           
            do
            {
                Console.Clear();
                Console.WriteLine("---- SENIOR CITIZEN DATA ----");
                Console.WriteLine("\nBarangay San Marcelino - " + senior.Count + " Members");
                var n = 1;
                foreach (KeyValuePair<int, string> old in senior)
                {
                    Console.WriteLine(n++ + ".) {0}, Age {1}", old.Value, old.Key);
                }
                

                Console.WriteLine($@"   
-----------------------------------------------------------------------------------------------
       [S] Add Member               [E] Exit
       [M] Remove Member with Age                        
       [C] Clear Dictionary         [T] Is this a Dictionary and Display Hashcode  
       [L] Find/Look                [G] Show other barangay
       [A] Check if Age exist       [P] Check if Name exist 
       [D] Equality Check                       
 ----------------------------------------------------------------------------------------------                
");
                Console.Write("\n     CHOOSE ONE: ");
                var choice = Convert.ToChar(Console.ReadLine());
                
                switch (choice) {
                    case 's':
                    case 'S':
                        Console.WriteLine("Add a member, Enter details.");
                        Console.Write("Name : ");
                        var name = Convert.ToString(Console.ReadLine());
                        Console.Write("Age : ");
                        var age = Convert.ToInt32(Console.ReadLine());
                        senior.Add(age, name);
                        close = 0;
                        break;
                    case 'F':
                    case 'f':
                        Console.WriteLine("Enter Age to find member");
                        string result;
                        Console.Write("Age : ");
                        age = Convert.ToInt32(Console.ReadLine());
                        if (senior.TryGetValue(age, out result))
                        {
                            Console.WriteLine("Name - "+result);
                        }
                        else
                        {
                            Console.WriteLine("Could not find the specified key.");
                        }
                        Console.ReadKey();
                       
                        close = 0;
                        break;
                    case 'M':
                    case 'm':
                        Console.WriteLine("Removing a member, Enter age:");
                        Console.Write("Age : ");
                        age = Convert.ToInt32(Console.ReadLine());
                        senior.Remove(age);
                        close = 0;
                        break;
                    case 'A':
                    case 'a':
                        Console.Write("\nDo we have this age? Enter age: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        
                        if (senior.ContainsKey(age))
                        Console.WriteLine(" - Yes, we do");
                        else
                        Console.WriteLine(" - Nope, we did not");
                        Console.ReadKey();
                        close = 0;
                        break;
                    case 'P':
                    case 'p':
                        Console.Write("\nDo we have this name? [CASE SENSITIVE] Enter name: ");
                        name = Convert.ToString(Console.ReadLine());

                        if (senior.ContainsValue(name))
                            Console.WriteLine(" - Yes, we do");
                        else
                            Console.WriteLine(" - Nope, we did not");
                        Console.ReadKey();
                        close = 0;
                        break;
                    case 'D':
                    case 'd':
                        Console.Write("\nEquality Check to other Barangay");
                        Console.WriteLine("\nPreview Only: Barangay Natividad Lopez - " + senior2.Count + " Members");
                        n = 1;
                        foreach (KeyValuePair<int, string> old in senior2)
                        {
                            Console.WriteLine(n++ + ".) {0}, Age {1}", old.Value, old.Key);
                        }

                        if (senior.Equals(senior2))
                            Console.WriteLine("\n - Yes, we do");
                        else
                            Console.WriteLine("\n - Nope, we do not");
                        Console.ReadKey();
                        close = 0;
                        break;
                    case 'G':
                    case 'g':
                        IDictionaryEnumerator myEnumerator = senior2.GetEnumerator();
                        while (myEnumerator.MoveNext())
                            Console.WriteLine(myEnumerator.Key + " --> "
                                              + myEnumerator.Value);
                        close = 0;
                        Console.ReadKey();
                        break;

                  
                    case 'c':
                    case 'C':
                        Console.WriteLine("Dictionary Cleared!");
                        senior.Clear();
                        Console.ReadKey();
                        close = 0;
                        break;

                    case 't':
                    case 'T':
                        Type t = senior.GetType();
                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                            Console.WriteLine("\nThe list of data is a Dictionary");
                        else
                        Console.WriteLine("\nThe list of data is not a Dictionary");
                        int hash = senior.GetHashCode();
                        Console.Write("Hashcode: " + hash);
                                                
                        close = 0;
                        Console.ReadKey(); 
                        
                        break;
                    case 'e':
                    case 'E':
                        Console.WriteLine("Thank you for using this Program, press any key to terminate");
                        Console.ReadKey();
                        close = 1;
                        break;
                }
            } while (close != 1);
            Console.ReadKey();
        }
    }
}
