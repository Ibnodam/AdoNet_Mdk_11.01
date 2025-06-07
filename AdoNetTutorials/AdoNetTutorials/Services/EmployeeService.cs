using AdoNetTutorials.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTutorials.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        public override bool Add(Employee obj)
        {
            bool IsAdded = false;
            if (obj.Age < 18 || obj.Age > 70)
            {
                throw new ArgumentException("Illegal age given");
            }
            using (objSqlConnection)
            { 
                objSqlCommand.Parameters.Clear();
                objSqlCommand.CommandText = "udp_InsertEmployee";
                objSqlCommand.Parameters.AddWithValue("@NameEmp", obj.NameEmp);
                objSqlCommand.Parameters.AddWithValue("@Age", obj.Age);
                objSqlConnection.Open();
                int addRows = objSqlCommand.ExecuteNonQuery();
                IsAdded = addRows > 0;
            }
            return IsAdded;
        }

        public override bool Delete(int id)
        {
            bool IsDeleted = false;
            using (objSqlConnection)
            { 
                objSqlCommand.Parameters.Clear();
                objSqlCommand.CommandText = "udp_DeleteEmployee";
                objSqlCommand.Parameters.AddWithValue("@Id", id);
                objSqlConnection.Open();

                int delRows = objSqlCommand.ExecuteNonQuery();
                IsDeleted = delRows > 0;
            }
            return IsDeleted;
        }

        public override List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            using (objSqlConnection) 
            {
                objSqlCommand.Parameters.Clear();
                objSqlCommand.CommandText = "udp_SelectAllEmployee";
                objSqlConnection.Open();
                var ObjSqlDataReader = objSqlCommand.ExecuteReader();
                if (ObjSqlDataReader.HasRows)
                {
                    Employee objEmployee = null;
                    while (ObjSqlDataReader.Read())
                    { 
                        objEmployee = new Employee();
                        objEmployee.Id = ObjSqlDataReader.GetInt32(0);
                        objEmployee.NameEmp = ObjSqlDataReader.GetString(1);
                        objEmployee.Age = ObjSqlDataReader.GetInt32(2);
                        list.Add(objEmployee);  
                    }
                }
                return list;
            }
            
        }

        public override bool Update(Employee obj)
        {
            bool IsUpdated = false;
            using (objSqlConnection)
            {
                objSqlCommand.Parameters.Clear();
                objSqlCommand.CommandText = "udp_UpdateEmployee";
                objSqlCommand.Parameters.AddWithValue("@NameEmp", obj.NameEmp);
                objSqlCommand.Parameters.AddWithValue("@Age", obj.Age);
                objSqlConnection.Open();
                int updateRows = objSqlCommand.ExecuteNonQuery();
                IsUpdated = updateRows > 0;
            }
            return IsUpdated;
        }
    }
}
