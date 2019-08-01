using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConn;
using GCore;

namespace DataHandler
{
    interface IDataHandler
    {
        /// <summary>
        /// Получение списка программ по номеру страницы
        /// </summary>
        /// <param name="_page">Номер страницы</param>
        /// <returns>Возвращает список программ</returns>
        List<Program> GetProgramList(int _page);
        /// <summary>
        /// Получить список категорий
        /// </summary>
        /// <returns>Возвращает список категорий</returns>
        List<Category> GetCategoryList();
        /// <summary>
        /// Получение списка разработчиков по номеру страницы
        /// </summary>
        /// <param name="_page">Номер страницы</param>
        /// <returns>Возвращает список программ</returns>
        //List<Program> GetDeveloperyList(int _page);
    }

    public class Handler : IDataHandler
    {
        Logger Log = new Logger();

        /// <summary>
        /// Метод получения коллекции программ
        /// </summary>
        /// <returns>Лист программ</returns>
        public List<Program> GetProgramList(int _page)
        {
            MySQLHandler mysql = new MySQLHandler();
            List<Program> prList = new List<Program>();

            string sqltext = "Select Emp_Id, Emp_No, Emp_Name, Mng_Id from Employee";
            //mysql.CommanderMySql(sqltext, "programs");
            return prList;
        }


        /// <summary>
        /// Метод получения коллекции категорий
        /// </summary>
        /// <returns>Лист категорий</returns>
        public List<Category> GetCategoryList()
        {
            List<Category> catList = new List<Category>();
            try
            {
                MySQLHandler mysql = new MySQLHandler();

                foreach (string s in mysql.CommanderMySql("category"))
                {
                    string[] temp = s.Split('╩');
                    catList.Add(new Category(Int32.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5], Int32.Parse(temp[6])));
                }

            }
            catch (Exception e)
            {
                Log.addLineToLog(e.ToString());
            }
            return catList;
        }
    }
}
