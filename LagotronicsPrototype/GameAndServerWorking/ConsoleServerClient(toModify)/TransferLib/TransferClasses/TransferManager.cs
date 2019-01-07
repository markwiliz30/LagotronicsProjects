using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLib.TransferClasses
{
    public class TransferManager
    {
        public void SaveData(TransferItem myItem)
        {
            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.spInsertData2";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TransData", myItem.TransData));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
