using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class Bill
    {

        private int status;
        private DateTime? dateCheckIn; // ?: co the null
        private DateTime? dateCheckOut;
        private int iD;

        public Bill(int id, DateTime? dateCheckIn, DateTime? dateChekOut, int status) {
            this.iD = id;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
        }

        public Bill(DataRow row) {
            this.iD = (int)row["id"];

            var dateCheckInTemp = row["DayCheckIn"];
            if (dateCheckInTemp.ToString() != "")
            {
                this.dateCheckIn = (DateTime?)dateCheckInTemp;
            }
            var dateCheckOutTemp = row["DayCheckOut"];
            if(dateCheckOutTemp.ToString() != "") { 
                this.dateCheckOut = (DateTime?)dateCheckOutTemp;
            }
            this.status = (int)row["status"];
        }

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public int Status { get => status; set => status = value; }
    }
}
