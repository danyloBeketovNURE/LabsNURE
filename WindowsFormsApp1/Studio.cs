using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Studio : ICloneable
    {
        static Random _R = new Random();
        //public int countOfRooms { get { _countOfRooms = _roomList.Count(); return _countOfRooms; } }
        //private int _countOfRooms;
        public List<Room> _roomList = new List<Room>();
        //public int countOfInstruments { get { _countOfInstruments = _instrumentList.Count(); return _countOfInstruments; } }
        //private int _countOfInstruments;
        public List<Instrument> _instrumentList = new List<Instrument>();
        //public int countOfWorkers { get { _countOfWorkers = _workersMap.Count(); return _countOfWorkers; } }
        //private int _countOfWorkers;
        public Dictionary<string, Worker> _workersMap = new Dictionary<string, Worker>();
        public string studioName { get => _studioName;}
        private string _studioName;
        public int studioMoneyBalance { get => _studioMoneyBalance; }
        private int _studioMoneyBalance;
        public string studioAdress { get => _studioAdress; }
        private string _studioAdress;
        //public int workersCount { get => _workersCount; set { _workersCount = value;}}
        //private int _workersCount;
        public int cenaZaTraсk { get => _cenaZaTraсk; }
        private int _cenaZaTraсk;
        public int timeForTraсk { get => _timeForTraсk; }
        private int _timeForTraсk;
        public int emploeeMonthSalery { get => _emploeeMonthSalery; }
        private int _emploeeMonthSalery;
        public int allEmploeesMonthSalery { get => _allEmploeesMonthSalery; set { _allEmploeesMonthSalery = value; } }
        private int _allEmploeesMonthSalery;
        //public int musicalInstrumentCount { get => _musicalInstrumentCount; set { _musicalInstrumentCount = value; } }
        //private int _musicalInstrumentCount;
        //public int instrumentRoomCount { get => _instrumentRoomCount; set { _instrumentRoomCount = value; } }
        //private int _instrumentRoomCount;

        public Studio(string studioName, string studioAdress, int cenaZaTraсk, int timeForTraсk, int emploeeMonthSalery)
        {
            _studioMoneyBalance = 100000;
            _studioName = studioName;
            _studioAdress = studioAdress;
            //_workersCount = 3;
            _cenaZaTraсk = cenaZaTraсk;
            _timeForTraсk = timeForTraсk;
            _emploeeMonthSalery = emploeeMonthSalery;
            _allEmploeesMonthSalery = _emploeeMonthSalery*_workersMap.Count();
            //_musicalInstrumentCount = 3;
            //_instrumentRoomCount = 1;
        }
        public Studio()
        {
        }
        public Studio(string studioName, int studioMoneyBalance, string studioAdress, int cenaZaTraсk, int timeForTraсk, int emploeeMonthSalery, int allEmploeesMonthSalery, IEnumerable<Room> rooms, IEnumerable<Worker> workers, IEnumerable<Instrument> instruments)
        {
            _studioName = studioName;
            _studioMoneyBalance = studioMoneyBalance;
            _studioAdress = studioAdress;
            _cenaZaTraсk = cenaZaTraсk;
            _timeForTraсk = timeForTraсk;
            _emploeeMonthSalery = emploeeMonthSalery;
            _allEmploeesMonthSalery = allEmploeesMonthSalery;
            _roomList.AddRange(rooms);
            _instrumentList.AddRange(instruments);
            foreach (Worker w in workers)
            {
                if (!_workersMap.ContainsKey(w.id)) 
                _workersMap.Add(w.id, w);
            }
        }

        private InstrumentClass getRandomInstrumentaalClass() 
        {
            var v = InstrumentClass.GetValues(typeof(InstrumentClass));
            return (InstrumentClass)v.GetValue(_R.Next(v.Length));
        }

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return _emploeeMonthSalery;
                    case 1: return _studioMoneyBalance;
                    default: throw new ArgumentException("i");
                }
            }
        }
        public void hireEmployee()
        {
            Worker someWorker = new Worker("some worker");
            _workersMap.Add(someWorker.id, someWorker);
        }
        public void dismissEmployee(string id)
        {
            _workersMap.Remove(id);
            if (_workersMap.Count() == 0)
                MessageBox.Show("you have 0 workers now but " + _instrumentList.Count() + " rooms");
            if(_workersMap.Count() < _roomList.Count()*2)
                MessageBox.Show("now you have lack of workers for one of room");
        }
        public void buyNewInstrument()
        {
            Instrument someInstument = new Instrument(getRandomInstrumentaalClass());
            _instrumentList.Add(someInstument);
        }
        public void brokeInstrument()
        {
            if (_instrumentList.Count() == 0)
                return;
            _instrumentList.RemoveAt(0);
            if (_instrumentList.Count() == 0)
                MessageBox.Show("you have 0 instruments now but " + _roomList.Count() + " rooms");
            if(_instrumentList.Count() < _roomList.Count() * 2)
                MessageBox.Show("now you have lack of instruments for one of room");
        }
        public void destroyInstrumentalRoom(string idToRemove)
        {
            //bool a = false;
            if (_roomList.Count() == 0)
            {
                MessageBox.Show("you have no rooms");
                return;
            }
            else
                for (int i = 0; i <= _roomList.Count; i++) 
                {
                    if (_roomList.ElementAt(i).id.Equals(idToRemove)) 
                    {
                        _roomList.RemoveAt(i);
                        //a = true;
                    }
                }
            //if(a==false)
            //    MessageBox.Show("you have no room with this id");
            if (_roomList.Count() == 0)
                MessageBox.Show("you have 0 rooms now but " + _workersMap.Count() + " workers");
        }
        public void buildNewInstrumentalRoom(IEnumerable<Instrument> instruments)
        {
            if (_roomList.Count() == 0)
            {
                Room someRoom = new Room(instruments);
                _roomList.Add(someRoom);
                _studioMoneyBalance -=10000;
                MessageBox.Show("Room builded !!congratulations!!");
                return;
            }
            if (_instrumentList.Count() - _roomList.Count()*2 > 1 && _workersMap.Count() - _roomList.Count()* 2 > 1)
            {
                Room someRoom = new Room(instruments);
                _roomList.Add(someRoom);
                _studioMoneyBalance -= 10000;
                MessageBox.Show("Room builded !!congratulations!!");
                return;
            }
            else
            {
                if(_instrumentList.Count() - _roomList.Count() * 2 <= 1)
                MessageBox.Show("there is no point in building a new room, buy more instruments");
                if (_workersMap.Count() - _roomList.Count() * 2 <= 1)
                MessageBox.Show("there is no point in building a new room, hire more workers");
            }
        }
        //public static Studio operator ++(Studio studio)
        //{
        //    if(studio._studioMoneyBalance < 20000)
        //        MessageBox.Show("Studio balance is too low, balance must bee more than 20000");
        //    studio._studioMoneyBalance -= 20000;
        //    studio.instrumentRoomCount++;
        //    studio.musicalInstrumentCount+=2;
        //    studio.workersCount+=2;
        //    MessageBox.Show("Room is added");
        //    return studio;
        //}
        //public static Studio operator --(Studio studio)
        //{
        //    studio.instrumentRoomCount--;
        //    MessageBox.Show("Room is removed");
        //    return studio;
        //}

        public void addBalance(int moneyAmount)
        {
            _studioMoneyBalance += moneyAmount;
        }

        public Instrument findInstrumentByNumber(string number)
        {
            for (int i = 0; i <= _instrumentList.Count; i++)
            {
                if (_instrumentList.ElementAt(i).id.Equals(number))
                {
                    return _instrumentList.ElementAt(i);
                }
            }
            return null;
        }

        public Worker findWorkerDataByNumber(string number)
        {
            if (_workersMap.ContainsKey(number))
                return _workersMap[number];
            
            return null;
        }

        public object Clone()
        {
            return new Studio(_studioName, _studioAdress, _cenaZaTraсk, _timeForTraсk, _emploeeMonthSalery);
        }
    }
}
