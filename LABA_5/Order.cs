namespace LABA_5
{
    internal class Order
    {
        private int _id;
        private int _serviceId;
        private int _performerId;
        private int _cost;

        public Order()
        {
            _id = 0;
            _serviceId = 0;
            _performerId = 0;
            _cost = 0;
        }

        public Order(int id, int serviceId, int performerId, int cost)
        {
            _id = id;
            _serviceId = serviceId;
            _performerId = performerId;
            _cost = cost;
        }

        public Order(Order other)
        {
            _id = other._id;
            _serviceId = other._serviceId;
            _performerId = other._performerId;
            _cost = other._cost;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int ServiceId
        {
            get { return _serviceId; }
            set { _serviceId = value; }
        }

        public int PerformerId
        {
            get { return _performerId; }
            set { _performerId = value; }
        }

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        private string FormatGroup(int number)
        {
            string result = number.ToString();

            if (number < 10)
            {
                result = "00" + result;
            }
            else if (number < 100)
            {
                result = "0" + result;
            }

            return result;
        }

        private string FormatCost()
        {
            int _millions = _cost / 1000000;
            int _thousands = _cost / 1000 % 1000;
            int _units = _cost % 1000;
            string result;

            if (_millions > 0)
            {
                result = _millions + " " + FormatGroup(_thousands) + " " + FormatGroup(_units);
            }
            else if (_thousands > 0)
            {
                result = _thousands + " " + FormatGroup(_units);
            }
            else
            {
                result = _units.ToString();
            }

            return result;
        }

        public override string ToString()
        {
            return "Код: " + _id + ", услуга: " + _serviceId +
                ", исполнитель: " + _performerId + ", стоимость: " + FormatCost();
        }
    }
}