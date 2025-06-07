using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTutorials.Services
{
    public abstract class BaseService<T>
    {
        protected SqlConnection objSqlConnection;
        protected SqlCommand objSqlCommand;

        public BaseService()
        {
            objSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = objSqlConnection;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
        }
        public abstract List<T> GetAll();
        public abstract bool Add(T obj);
        public abstract bool Update(T obj);
        public abstract bool Delete(int id);
    }
}
