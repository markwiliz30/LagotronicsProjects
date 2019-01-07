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
        public List<TransferItem> RetreiveAllData()
        {
            var itemCollection = new List<TransferItem>();
            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.GetData";
                var cmd = new SqlCommand(sql, db);
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    var item = new TransferItem();

                    item.TransData = (byte[])reader["TransData"];

                    itemCollection.Add(item);
                }

                db.Close();
                return itemCollection;
            }
        }
    }
}
