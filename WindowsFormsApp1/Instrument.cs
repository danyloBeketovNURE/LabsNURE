using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Instrument
    {
        Random rnd = new Random();
        public string id { get => _id; }
        private string _id;
        public InstrumentClass instrumentClass { get => _instrumentClass; }
        private InstrumentClass _instrumentClass;
        public int price { get => _price; }
        private int _price;
        public Instrument() { }
        public Instrument(InstrumentClass insClass)
        {
            _instrumentClass = insClass;
            _id = Guid.NewGuid().ToString();
            _price = rnd.Next(100,10000);
        }
        public Instrument(string id, InstrumentClass insClass, int price)
        {
            _id = id;
            _price = price;
            _instrumentClass = insClass;
            _id = Guid.NewGuid().ToString();
            _price = rnd.Next(100,10000);
        }
    }
}
