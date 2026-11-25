using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace LABA_5
{
    internal class FreelanceDatabase
    {
        private string _path;
        private List<Order> _orders;
        private List<Service> _services;
        private List<Performer> _performers;
        private bool _isChanged;

        public FreelanceDatabase(string path)
        {
            _path = path;
            _orders = new List<Order>();
            _services = new List<Service>();
            _performers = new List<Performer>();
            _isChanged = false;
        }

        public string Path
        {
            get { return _path; }
        }

        public List<Order> Orders
        {
            get { return _orders; }
        }

        public List<Service> Services
        {
            get { return _services; }
        }

        public List<Performer> Performers
        {
            get { return _performers; }
        }

        public bool IsChanged
        {
            get { return _isChanged; }
            set { _isChanged = value; }
        }

        public bool Load()
        {
            List<Order> orders;
            List<Service> services;
            List<Performer> performers;

            try
            {
                using (FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook(stream);
                    ISheet ordersSheet = workbook.GetSheet("Заказы");
                    ISheet servicesSheet = workbook.GetSheet("Услуги");
                    ISheet performersSheet = workbook.GetSheet("Исполнители");

                    orders = Enumerable.Range(1, ordersSheet.LastRowNum)
                        .Select(i => ReadOrder(ordersSheet.GetRow(i)))
                        .ToList();
                    services = Enumerable.Range(1, servicesSheet.LastRowNum)
                        .Select(i => ReadService(servicesSheet.GetRow(i)))
                        .ToList();
                    performers = Enumerable.Range(1, performersSheet.LastRowNum)
                        .Select(i => ReadPerformer(performersSheet.GetRow(i)))
                        .ToList();
                }
            }
            catch (FileNotFoundException)
            {
                ScreenUtils.PrintError("\tФайл " + _path + " не найден :(");
                return false;
            }
            catch (IOException)
            {
                ScreenUtils.PrintError("\tНе удалось открыть файл, возможно он открыт в Excel :(");
                return false;
            }
            catch (Exception exception)
            {
                ScreenUtils.PrintError("\tОшибка чтения файла: " + exception.Message + " :(");
                return false;
            }

            _orders = orders;
            _services = services;
            _performers = performers;
            _isChanged = false;

            return true;
        }

        public List<Order> GetOrders(int first, int last)
        {
            return _orders.Skip(first - 1).Take(last - first + 1).ToList();
        }

        public List<Service> GetServices(int first, int last)
        {
            return _services.Skip(first - 1).Take(last - first + 1).ToList();
        }

        public List<Performer> GetPerformers(int first, int last)
        {
            return _performers.Skip(first - 1).Take(last - first + 1).ToList();
        }

        public bool HasOrder(int id)
        {
            return _orders.Any(order => order.Id == id);
        }

        public bool HasService(int id)
        {
            return _services.Any(service => service.Id == id);
        }

        public bool HasPerformer(int id)
        {
            return _performers.Any(performer => performer.Id == id);
        }

        public int CountOrdersByService(int serviceId)
        {
            return _orders.Count(order => order.ServiceId == serviceId);
        }

        public int CountOrdersByPerformer(int performerId)
        {
            return _orders.Count(order => order.PerformerId == performerId);
        }

        public void RemoveOrder(int id)
        {
            _orders.RemoveAll(order => order.Id == id);
            _isChanged = true;
        }

        public void RemoveService(int id)
        {
            _orders.RemoveAll(order => order.ServiceId == id);
            _services.RemoveAll(service => service.Id == id);
            _isChanged = true;
        }

        public void RemovePerformer(int id)
        {
            _orders.RemoveAll(order => order.PerformerId == id);
            _performers.RemoveAll(performer => performer.Id == id);
            _isChanged = true;
        }

        public bool HasServiceName(string name)
        {
            return _services.Any(service => service.Name.ToLower() == name.ToLower());
        }

        public int AddPerformer(int age, string citizenship)
        {
            int id = _performers.Select(performer => performer.Id).DefaultIfEmpty(0).Max() + 1;

            _performers.Add(new Performer(id, age, citizenship));
            _isChanged = true;

            return id;
        }

        public int AddService(string name)
        {
            int id = _services.Select(service => service.Id).DefaultIfEmpty(0).Max() + 1;

            _services.Add(new Service(id, name));
            _isChanged = true;

            return id;
        }

        public int AddOrder(int serviceId, int performerId, int cost)
        {
            int id = _orders.Select(order => order.Id).DefaultIfEmpty(0).Max() + 1;

            _orders.Add(new Order(id, serviceId, performerId, cost));
            _isChanged = true;

            return id;
        }

        public string GetServiceName(int id)
        {
            return _services.First(service => service.Id == id).Name;
        }

        public List<Order> GetOrdersMoreThan(int cost)
        {
            return _orders
                .Where(order => order.Cost > cost)
                .OrderByDescending(order => order.Cost)
                .ToList();
        }

        public long GetServiceTotal(string serviceName)
        {
            long total = (from order in _orders
                          join service in _services on order.ServiceId equals service.Id
                          where service.Name == serviceName
                          select (long)order.Cost).Sum();

            return total;
        }

        public List<Performer> GetPerformersByCountryAndService(string country, string serviceName)
        {
            List<Performer> performers = (from order in _orders
                                          join service in _services on order.ServiceId equals service.Id
                                          join performer in _performers on order.PerformerId equals performer.Id
                                          where service.Name == serviceName
                                              && performer.Citizenship.ToLower() == country.ToLower()
                                          select performer).Distinct().OrderBy(performer => performer.Id).ToList();

            return performers;
        }

        public int GetBestPerformerId(string country, int minAge, string serviceName)
        {
            int id = (from order in _orders
                      join service in _services on order.ServiceId equals service.Id
                      join performer in _performers on order.PerformerId equals performer.Id
                      where service.Name == serviceName
                          && performer.Citizenship.ToLower() == country.ToLower()
                          && performer.Age > minAge
                      group order by performer.Id into performerOrders
                      orderby performerOrders.Sum(item => (long)item.Cost) descending
                      select performerOrders.Key).FirstOrDefault();

            return id;
        }

        public bool Save()
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();

                WriteOrders(workbook);
                WriteServices(workbook);
                WritePerformers(workbook);

                using (FileStream stream = new FileStream(_path, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                }
            }
            catch (IOException)
            {
                ScreenUtils.PrintError("\tНе удалось записать файл, возможно он открыт в Excel :(");
                return false;
            }
            catch (Exception exception)
            {
                ScreenUtils.PrintError("\tОшибка записи файла: " + exception.Message + " :(");
                return false;
            }

            _isChanged = false;

            return true;
        }

        private void WriteOrders(HSSFWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet("Заказы");
            IRow header = sheet.CreateRow(0);

            header.CreateCell(0).SetCellValue("Код");
            header.CreateCell(1).SetCellValue("Код услуги");
            header.CreateCell(2).SetCellValue("Код исполнителя");
            header.CreateCell(3).SetCellValue("Стоимость");

            Enumerable.Range(0, _orders.Count)
                .ToList()
                .ForEach(i => WriteOrderRow(sheet.CreateRow(i + 1), _orders[i]));
        }

        private void WriteServices(HSSFWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet("Услуги");
            IRow header = sheet.CreateRow(0);

            header.CreateCell(0).SetCellValue("Код");
            header.CreateCell(1).SetCellValue("Название");

            Enumerable.Range(0, _services.Count)
                .ToList()
                .ForEach(i => WriteServiceRow(sheet.CreateRow(i + 1), _services[i]));
        }

        private void WritePerformers(HSSFWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet("Исполнители");
            IRow header = sheet.CreateRow(0);

            header.CreateCell(0).SetCellValue("Код");
            header.CreateCell(1).SetCellValue("Возраст");
            header.CreateCell(2).SetCellValue("Гражданство");

            Enumerable.Range(0, _performers.Count)
                .ToList()
                .ForEach(i => WritePerformerRow(sheet.CreateRow(i + 1), _performers[i]));
        }

        private void WriteOrderRow(IRow row, Order order)
        {
            row.CreateCell(0).SetCellValue(order.Id);
            row.CreateCell(1).SetCellValue(order.ServiceId);
            row.CreateCell(2).SetCellValue(order.PerformerId);
            row.CreateCell(3).SetCellValue(order.Cost);
        }

        private void WriteServiceRow(IRow row, Service service)
        {
            row.CreateCell(0).SetCellValue(service.Id);
            row.CreateCell(1).SetCellValue(service.Name);
        }

        private void WritePerformerRow(IRow row, Performer performer)
        {
            row.CreateCell(0).SetCellValue(performer.Id);
            row.CreateCell(1).SetCellValue(performer.Age);
            row.CreateCell(2).SetCellValue(performer.Citizenship);
        }

        private Order ReadOrder(IRow row)
        {
            return new Order(
                (int)row.GetCell(0).NumericCellValue,
                (int)row.GetCell(1).NumericCellValue,
                (int)row.GetCell(2).NumericCellValue,
                (int)row.GetCell(3).NumericCellValue);
        }

        private Service ReadService(IRow row)
        {
            return new Service(
                (int)row.GetCell(0).NumericCellValue,
                row.GetCell(1).StringCellValue);
        }

        private Performer ReadPerformer(IRow row)
        {
            return new Performer(
                (int)row.GetCell(0).NumericCellValue,
                (int)row.GetCell(1).NumericCellValue,
                row.GetCell(2).StringCellValue);
        }
    }
}