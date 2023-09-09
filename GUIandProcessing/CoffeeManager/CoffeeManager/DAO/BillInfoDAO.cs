using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAO
{
    internal class BillInfoDAO
    {
        private static BillInfoDAO instance;

        internal static BillInfoDAO Instance {
            get { if (instance == null) instance = new BillInfoDAO(); return instance; }
            private set { instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            Console.WriteLine(id);
            List<BillInfo> listBillInfos = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM BillInfo where idBill = " + id);

            foreach(DataRow item in data.Rows) {
                BillInfo info = new BillInfo(item);
                listBillInfos.Add(info);
            }

            return listBillInfos;
        }

    }
}
