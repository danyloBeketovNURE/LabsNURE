using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Room
    {
        Random rnd = new Random();

        public string id { get => _id; }
        private string _id;
        public List<Instrument> _instrumentsIdList;
        public List<Worker> _workersIdList;
        //public int actualInstrumentCount { get => _actualInstrumentCount; }
        //private int _actualInstrumentCount;
        //public int actualWorkersCount { get => _actualWorkersCount; }
        //private int _actualWorkersCount;

        public const int _minInstrumentCount = 4;
        public const int _maxInstrumentCount = 10;
        public const int _minWorkersCount = 4;
        public const int _maxWorkersCount = 10;
        public const int _priceForTrack = 1000;

        public Room()
        {
            _instrumentsIdList = new List<Instrument>();
            _workersIdList = new List<Worker>();
        }
        public Room(string id)
        {
            _id = id;
            _instrumentsIdList = new List<Instrument>();
            _workersIdList = new List<Worker>();
        }
        public Room(IEnumerable<Instrument> instruments)
        {
            _instrumentsIdList = new List<Instrument>();
            foreach (Instrument instrument in instruments)
            {
                _instrumentsIdList.Add(instrument);
            }
            _workersIdList = new List<Worker>();
            _id = Guid.NewGuid().ToString();
            //_actualInstrumentCount = 0;
            //_actualWorkersCount = 0;
        }
    }
}
