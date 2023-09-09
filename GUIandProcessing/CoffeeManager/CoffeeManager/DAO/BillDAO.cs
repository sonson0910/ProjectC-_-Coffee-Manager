using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance { 
            get { if (instance == null) instance = new BillDAO(); return instance; }
            set { instance = value; }
        }

        private BillDAO() { }


        /*
         * Thành công: BillID
         * Thất bại: -1
        */


        public int GetUnCheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM Bill WHERE idTable = " + id + " AND status = 0");

            if(data.Rows.Count > 0 )
            {
                Bill bill = new Bill(data.Rows[0]);
                
                return bill.ID;
            }
            
            return -1;
        }

    }
}
