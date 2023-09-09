using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class BillInfo
    {
        public BillInfo(int iD, int billId, int idFood, int count) {
            this.ID = iD;
            this.BillID = billId;
            this.FoodID = idFood;
            this.count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.BillID = (int)row["idBill"];
            this.FoodID = (int)row["idFood"];
            this.count = (int)row["count"];
        }

        private int count;

        private int foodID;

        private int billID;

        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int Count { get => count; set => count = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int BillID { get => billID; set => billID = value; }
    }
}
