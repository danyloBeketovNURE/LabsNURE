using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class STUDIO
    {
        private string _studioName;
        private string _studioAdress;
        private int _workersCount;
        private int _cenaZaTraсk = 0;
        private int _timeForTraсk = 0;
        private int _emploeeMonthSalery = 0;
        private int _allEmploeesMonthSalery = 0;
        private int _musicalInstrumentCount = 0;
        private List<string> _poslugi = new List<string>();
        private List<string> _callHistory = new List<string>();

        public STUDIO(){
            _phoneNumber = inputPhoneNumber();
            _tarif = inputTarifName();
            _balance = 0;
            _cenaZaMinutu = (int)_tarif;
        }
        public void changeTarif(Tarif tarif){
            _tarif = tarif;
            _cenaZaMinutu = (int)tarif;
        }
        public int call(String phoneNumberToCall, int minutes){
            _callHistory.Add(phoneNumberToCall);
            return minutes * (int)_tarif;
        }
        public string inputPhoneNumber(){
            string number = "";
            while (number.Length != 10) {
                Console.WriteLine("Input phone number:");
                number = Console.ReadLine();
                if(number.Length != 10){
                    Console.WriteLine("Phone number must be 10 caracters, please rty again:");
                }
            }
            return number;
        }
        public void addOrDeletePosluga(String action){
            switch (action){
                case "ADD":
                    Console.WriteLine("available services:\n" + Posluga.DENPLUS + " " + Posluga.SOCMEREZHI + " " + Posluga.STOMINUT + " choose one");
                    Posluga posluga = inputPoslugaName();
                    if (!posluga.Equals("NONE")) {
                        _poslugi.Add(posluga.ToString());
                        _balance-=(int)posluga;
                    }
                    break;
                case "DELETE":
                    Console.WriteLine("your services:\n choose one to delete\n");
                    _poslugi.ForEach(Console.WriteLine);
                    string poslugaToDelete = Console.ReadLine();
                    _poslugi.Remove(poslugaToDelete.ToUpper());
                    break;
            }
        }
        private Posluga inputPoslugaName()
        {
            string poslugaToTake = Console.ReadLine();
            Posluga posluga = Posluga.NONE;
            switch (poslugaToTake.ToUpper())
            {
                case "DENPLUS":
                    posluga = Posluga.DENPLUS;
                    break;
                case "SOCMEREZHI":
                    posluga = Posluga.DENPLUS;
                    break;
                case "STOMINUT":
                    posluga = Posluga.DENPLUS;
                    break;
                default:
                    Console.WriteLine("such service is not available");
                    break;
            }
            return posluga;
        }
        public Tarif inputTarifName(){
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
        public void balanceIncrease(int summa){
            _balance += summa;
        }
        public void showBalance(){
            Console.WriteLine("Your balance:\n" + _balance + "\n");
        }
        public void showCallHistory(){
            Console.WriteLine("You reacently called next number:\n");
            _callHistory.ForEach(Console.WriteLine);
        }
    }
}
