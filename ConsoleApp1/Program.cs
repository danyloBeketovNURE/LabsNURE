using System;
using System.Collections.Generic;

namespace ConsoleApp1{
    class Program
    {
        static Tarif inputTarifName()
        {
            Console.WriteLine("Please input one of next tarifs to take it:\n" + Tarif.BEZLIM + " " + Tarif.LETO + " " + Tarif.LETOPLUS + " " + Tarif.ONLAIN);
            string tarifToTake = Console.ReadLine();
            Tarif tarif;
            switch (tarifToTake.ToUpper())
            {
                case "BEZLIM":
                    tarif = Tarif.BEZLIM;
                    break;
                case "LETO":
                    tarif = Tarif.LETO;
                    break;
                case "LETOPLUS":
                    tarif = Tarif.LETOPLUS;
                    break;
                case "ONLAIN":
                    tarif = Tarif.ONLAIN;
                    break;
                default:
                    tarif = Tarif.NONE;
                    break;
            }
            return tarif;
        }
        static void Main(string[] args)
        {
            bool abonentCreated = false;
            int i = 0;
            ABONENT abonent = null;
            while (true)
            {
                Console.WriteLine("To clear CMD: input 0");
                Console.WriteLine("Create abonent: input 1");
                Console.WriteLine("To call somebody: input 2");
                Console.WriteLine("To add service: input 3");
                Console.WriteLine("To delete service: input 4");
                Console.WriteLine("To replenish the balance: input 5");
                Console.WriteLine("To show balance: input 6");
                Console.WriteLine("To show call history: input 7");
                Console.WriteLine("To change tarif: input 8");
                i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        abonent = new ABONENT();
                        abonentCreated = true;
                        break;
                    case 2:
                        if (abonentCreated)
                        {
                            Console.WriteLine("Input call length");
                            int minutes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Input number to call");
                            String number = Console.ReadLine();
                            Console.WriteLine("Your call cost:" + abonent.call(number, minutes));
                        }
                        else { Console.WriteLine("you can not call while abonent not created");
                        }
                        break;
                    case 3:
                        if (abonentCreated)
                        {
                            abonent.addOrDeletePosluga("ADD");
                        }
                        else
                        {
                            Console.WriteLine("you can not add service while abonent not created");
                        }
                        break;
                    case 4:
                        if (abonentCreated)
                        {
                            abonent.addOrDeletePosluga("DELETE");
                        }
                        else
                        {
                            Console.WriteLine("you can not delete service balance while abonent not created");
                        }
                        break;
                    case 5:
                        if (abonentCreated)
                        {
                            Console.WriteLine("Input replenishment amount");
                            int summ = int.Parse(Console.ReadLine());
                            abonent.balanceIncrease(summ);
                        }
                        else
                        {
                            Console.WriteLine("you can not replenish while abonent not created");
                        }
                        break;
                    case 6:
                        if (abonentCreated)
                        {
                            abonent.showBalance();
                        }
                        else
                        {
                            Console.WriteLine("you can not view balance while abonent not created");
                        }
                        break;
                    case 7:
                        if (abonentCreated)
                        {
                            abonent.showCallHistory();
                        }
                        else
                        {
                            Console.WriteLine("you can not view call history while abonent not created");
                        }
                        break;
                    case 8:
                        if (abonentCreated)
                        {
                            abonent.changeTarif(inputTarifName());
                        }
                        else
                        {
                            Console.WriteLine("you can not change tarif while abonent not created");
                        }
                        break;
                }
            }
        }
    }
}


