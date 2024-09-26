using MyC_50_tnayin.ClassPersons;
using MyC_50_tnayin.IRepasitori;
using MyC_50_tnayin.Repasitori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyC_50_tnayin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IRepasitori<Person> persons = new RepasitoriPerson();
            //Person person1 = new Person(1,"Ruben","Hovsepyan",24);
            //Person person2 = new Person(2,"Arsen","Mkitaryan",27);
            //Person person3 = new Person(3,"Edgar","Melikyan",23);
            //persons.Add(person1);
            //persons.Add(person2);
            //persons.Add(person3);
            //persons.FindAll();

            while(true) 
            {
                Console.WriteLine("1:Add Person || 2:Update Person || 3:Find Person || 4:All Person || 5:Delite Person || 0:Exit");
                Console.Write("Your Chuse: ");

                IRepasitori<Person> personRepasitori = new RepasitoriPerson();

               
                string str = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Error");
                    continue;
                }
                int point;
                if(!int.TryParse(str, out point) )
                {
                    Console.WriteLine("Error");
                    continue;
                }
                if (point == 0)
                {
                    Console.WriteLine("Exit");
                    break;
                }
                switch (point)
                {
                    case 1:
                        Console.WriteLine("Add person");
                        Console.Write("Person Id:");
                        Person person1 = new Person();
                        person1.Id = int.Parse(Console.ReadLine());
                        Console.Write("Name:");
                        person1.Name = Console.ReadLine();
                        Console.Write("Surname:");
                        person1.Surname = Console.ReadLine();
                        Console.Write("Age:");
                        person1.Age = int.Parse(Console.ReadLine());
                        personRepasitori.Add(person1);
                        break;
                    case 2:
                        Console.WriteLine("Update Person");
                        Console.WriteLine("Chous Id: ");
                        int personId = int.Parse(Console.ReadLine());
                        Person find = personRepasitori.Find(personId);
                        Console.WriteLine("Name: ");
                        find.Name = Console.ReadLine();
                        Console.WriteLine("Surname: ");
                        find.Surname = Console.ReadLine();
                        Console.WriteLine("Age: ");
                        find.Age = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Finde by Id");
                        Console.Write("Id:");
                        int personid = int.Parse(Console.ReadLine());
                        Person find1 = personRepasitori.Find(personid);
                        Console.WriteLine(find1.Id);
                        Console.WriteLine(find1.Name);
                        Console.WriteLine(find1.Surname);
                        Console.WriteLine(find1.Age);
                        break;
                    case 4:
                        Console.WriteLine("All person");
                        var Persons = personRepasitori.FindAll();
                        foreach (var persons in Persons)
                        {
                            Console.WriteLine("--------------");
                            Console.Write("Id: ");
                            Console.WriteLine(persons.Id);
                            Console.Write("Name: ");
                            Console.WriteLine(persons.Name);
                            Console.Write("Surname: ");
                            Console.WriteLine(persons.Surname);
                            Console.Write("Age: ");
                            Console.WriteLine(persons.Age);
                            Console.WriteLine("--------------");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Delete");
                        int personiddelit = int.Parse(Console.ReadLine());
                        personRepasitori.Delite(personiddelit);
                        Console.WriteLine("Good job");
                        break;

                }
            }
            
        }
    }
}
