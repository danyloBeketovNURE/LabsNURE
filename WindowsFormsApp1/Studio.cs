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
        public string studioName { get => _studioName;}
        private string _studioName;
        public int studioMoneyBalance { get => _studioMoneyBalance; }
        private int _studioMoneyBalance;
        public string studioAdress { get => _studioAdress; }
        private string _studioAdress;
        public int workersCount { get => _workersCount; set { _workersCount = value;}}
        private int _workersCount;
        public int cenaZaTraсk { get => _cenaZaTraсk; }
        private int _cenaZaTraсk;
        public int timeForTraсk { get => _timeForTraсk; }
        private int _timeForTraсk;
        public int emploeeMonthSalery { get => _emploeeMonthSalery; }
        private int _emploeeMonthSalery;
        public int allEmploeesMonthSalery { get => _allEmploeesMonthSalery; }
        private int _allEmploeesMonthSalery;
        public int musicalInstrumentCount { get => _musicalInstrumentCount; set { _musicalInstrumentCount = value; } }
        private int _musicalInstrumentCount;
        public int instrumentRoomCount { get => _instrumentRoomCount; set { _instrumentRoomCount = value; } }
        private int _instrumentRoomCount;

        public Studio(string studioName, string studioAdress, int cenaZaTraсk, int timeForTraсk, int emploeeMonthSalery)
        {
            _studioMoneyBalance = 100000;
            _studioName = studioName;
            _studioAdress = studioAdress;
            _workersCount = 3;
            _cenaZaTraсk = cenaZaTraсk;
            _timeForTraсk = timeForTraсk;
            _emploeeMonthSalery = emploeeMonthSalery;
            _allEmploeesMonthSalery = _emploeeMonthSalery*_workersCount;
            _musicalInstrumentCount = 3;
            _instrumentRoomCount = 1;
        }
        public Studio()
        {
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
            _workersCount++;
        }
        public void dismissEmployee()
        {
            _workersCount--;
            if (_workersCount == 0)
                MessageBox.Show("you have 0 workers now but " + _instrumentRoomCount + " rooms");
            if(_workersCount < _instrumentRoomCount*2)
                MessageBox.Show("now you have lack of workers for one of room");
        }
        public void buyNewInstrument()
        {
            musicalInstrumentCount++;
        }
        public void brokeInstrument()
        {
            musicalInstrumentCount--;
            if (musicalInstrumentCount == 0)
                MessageBox.Show("you have 0 instruments now but " + _instrumentRoomCount + " rooms");
            if(musicalInstrumentCount < _instrumentRoomCount*2)
                MessageBox.Show("now you have lack of instruments for one of room");
        }
        public void buyNewMusicalInstrument()
        {
            _musicalInstrumentCount++;
        }
        public void destroyInstrumentalRoom()
        {
            if (_instrumentRoomCount == 0)
            {
                MessageBox.Show("you have no rooms");
                return;
            }else
                _instrumentRoomCount--;
            if(_instrumentRoomCount == 0)
                MessageBox.Show("you have 0 rooms now but " + _workersCount + " workers");

        }
        public void buildNewInstrumentalRoom()
        {
            if (_instrumentRoomCount == 0)
            {
                _instrumentRoomCount++;
                _studioMoneyBalance-=10000;
                MessageBox.Show("Room builded !!congratulations!!");
                return;
            }
            if (_musicalInstrumentCount - _instrumentRoomCount*2 >1 && _workersCount - _instrumentRoomCount*2 > 1)
            {
                _instrumentRoomCount++;
                _studioMoneyBalance -= 10000;
                MessageBox.Show("Room builded !!congratulations!!");
                return;
            }
            else
            {
                if(_musicalInstrumentCount - _instrumentRoomCount * 2 <= 1)
                MessageBox.Show("there is no point in building a new room, buy more instruments");
                if (_workersCount - _instrumentRoomCount * 2 <= 1)
                MessageBox.Show("there is no point in building a new room, hire more workers");
            }
        }
        public static Studio operator ++(Studio studio)
        {
            if(studio._studioMoneyBalance < 20000)
                MessageBox.Show("Studio balance is too low, balance must bee more than 20000");
            studio._studioMoneyBalance -= 20000;
            studio.instrumentRoomCount++;
            studio.musicalInstrumentCount+=2;
            studio.workersCount+=2;
            MessageBox.Show("Room is added");
            return studio;
        }
        public static Studio operator --(Studio studio)
        {
            studio.instrumentRoomCount--;
            MessageBox.Show("Room is removed");
            return studio;
        }

        public void addBalance(int moneyAmount)
        {
            _studioMoneyBalance += moneyAmount;
        }

        public object Clone()
        {
            return new Studio(_studioName, _studioAdress, _cenaZaTraсk, _timeForTraсk, _emploeeMonthSalery);
        }
    }
}
