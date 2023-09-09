using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        { 
            get {
                if (instance == null) instance = new AccountDAO();
                return instance; 
            }  
            private set { 
                instance = value;
            } 
        }
        private AccountDAO() { }

        public bool Login(string userName, string password) 
        {
            string query = "USP_LOGIN @userName , @passWord";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {userName, password});


            return result.Rows.Count > 0;
        }
    }
}
