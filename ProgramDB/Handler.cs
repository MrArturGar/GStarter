using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConn;

namespace DataHandler
{
    class Handler
    {
        private Program pr = new Program();
        private Category cat = new Category();
        private Developer dev = new Developer();

        /// <summary>
        /// Получение списка программ по номеру страницы
        /// </summary>
        /// <param name="_page">Номер страницы</param>
        /// <returns>Возврат списка программ</returns>
        public List<Program> GetProgramList(int _page)
        {
            MySQLHandler mysql = new MySQLHandler();
            List<Program> prList = new List<Program>();

            string sqltext = "Select Emp_Id, Emp_No, Emp_Name, Mng_Id from Employee";
            mysql.CommanderMySql(sqltext, "programs");
            return prList;
        }
    }
}
