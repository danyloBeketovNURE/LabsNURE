using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Worker
    {
        Random rnd = new Random();
        public string id { get => _id; }
        private string _id;
        public string initials { get => _initials; }
        private string _initials;
        public int salery { get => _salery; }
        private int _salery;
        public int traksCount { get => _traksCount; }
        private int _traksCount;
        public Worker() { }
        public Worker(string initials)
        {
            _id = generateIdNumber();
            _initials = initials;
            _salery = rnd.Next(100, 10000);
            _traksCount = 0;
        }
        public Worker(string initials, int salery, int tc, string id)
        {
            _id = id;
            _salery = salery;
            _traksCount = tc;
            _initials = initials;
        }
        private string generateIdNumber()
        {
            string[] elements = new string[12];
            Random rnd = new Random();
            for (int i=0;i<12;i++) 
            {
                elements[i] = rnd.Next(0, 9).ToString();
            }
            string number = String.Concat(elements[0], elements[1],
                                              elements[2], elements[3],
                                              elements[4], elements[5],
                                              elements[6], elements[7],
                                              elements[8], elements[9],
                                              elements[10], elements[11]);
            return number;
        }
    }
}
