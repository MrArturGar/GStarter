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
        List<Program> GetProgramList(int _page, int _categoryNum);
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
        public List<Program> GetProgramList(int _page, int _categoryNum)
        {
            List<Program> progList = new List<Program>();
            try
            {
                MySQLHandler mysql = new MySQLHandler();
                string sql = $"Select ID_Program, Orig_Name, Name, Short_Description, Description, Image, ID_Category, Weight, Link_Site, Link_Download, ID_Developer from programs where ID_Category={_categoryNum} LIMIT {10*(_page-1)}, 10";

                foreach (string s in mysql.CommanderMySql("programs", sql))
                {
                    string[] temp = s.Split('╩');
                    progList.Add(new Program(Int32.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], Int32.Parse(temp[7]), temp[8], temp[9], Int32.Parse(temp[10])));
                }
            }
            catch (Exception e)
            {
                Log.addLineToLog(e.ToString());
            }
            return progList;
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
                string sql = "Select ID_Category, RusName, Name, Short_Description, Description, Image, Parent from category";

                foreach (string s in mysql.CommanderMySql("category", sql))
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
