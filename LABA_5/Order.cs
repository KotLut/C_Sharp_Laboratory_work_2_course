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

        private static string FormatGroup(int number)
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

        public static string FormatMoney(long value)
        {
            string result;

            if (value < 1000)
            {
                result = value.ToString();
            }
            else
            {
                result = FormatMoney(value / 1000) + " " + FormatGroup((int)(value % 1000));
            }

            return result;
        }

        public override string ToString()
        {
            return "Код: " + _id + ", услуга: " + _serviceId +
                ", исполнитель: " + _performerId + ", стоимость: " + FormatMoney(_cost);
        }
    }
}