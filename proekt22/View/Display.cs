using proekt22.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt22.View
{
    public class Display
    {
        private int closeOperationId = 6;
        private ParcelLogic parLogic = new ParcelLogic();
        public Display()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            parLogic.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Parcel par = parLogic.Get(id);
            if (par != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + par.Id);
                Console.WriteLine("Name: " + par.Name);
                Console.WriteLine("Price: " + par.Price);
                Console.WriteLine("Number: " + par.Number);
                Console.WriteLine("Weight: " + par.Weight);
                Console.WriteLine("Type: " + par.ParcelTypes);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Parcel par = parLogic.Get(id);
            if (par != null)
            {
                Console.WriteLine("Enter name: ");
                par.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                par.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Type: ");
                par.ParcelTypeId = int.Parse(Console.ReadLine());
                parLogic.Updates(id,par);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Parcel par = new Parcel();
            Console.WriteLine("Enter name: ");
            par.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            par.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter availability: ");
            par.Number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Type: ");
            par.ParcelTypeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight: ");
            par.Weight = int.Parse(Console.ReadLine());


            parLogic.Create(par);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PARCELS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var par = parLogic.GetAll();
            foreach (var item in par)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Price, item.Number);
            }
        }
    }
}
