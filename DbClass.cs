using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO.NET
{
    class DbClass
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;initial catalog=EMAGAZA;Integrated Security=True");

        public void UpdateTable(string sql, DataTable dt, params SqlParameter[] prms)
        {
            // komut oluşturup connection'a bağlanıyoruz.
            SqlCommand cmd = new SqlCommand(sql, cnn); // komut bir connection'a bağlı olmak zorunda.
                                                       // veri taşıma işlemlerini yapan bir adaptor oluşturuyoruz.

            if (prms != null) cmd.Parameters.AddRange(prms);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //INSERT, UPDATE ve DELETE commendlerini SELECT commandine bakarak oluşturur. 
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            //DataTable daki işlemleri veritabanına kaydediyor.
            da.InsertCommand = cmb.GetInsertCommand();
            da.UpdateCommand = cmb.GetUpdateCommand(); //insert, update, delete komutlarının oluşturulduğundan emin oluyor.
            da.DeleteCommand = cmb.GetDeleteCommand(); 

            da.Update(dt);
        }

        public DataTable TabloGetir(string sql, params SqlParameter[] prms)
        {
            // komut oluşturup connection'a bağlanıyoruz.
            SqlCommand cmd = new SqlCommand(sql, cnn); // komut bir connection'a bağlı olmak zorunda.
                                                       // veri taşıma işlemlerini yapan bir adaptor oluşturuyoruz.

            if (prms != null) cmd.Parameters.AddRange(prms);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable(); // dataadaptor komutu kullnaır, fill de dataadaptoru kullanır.
            da.Fill(dt); // sql cümlesini çalıştırıp, dt tablosuna doldurur.
            return dt;

        }
        public void SqlCalistir(string sql, params SqlParameter[] prms)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);

            if (prms != null) cmd.Parameters.AddRange(prms);

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
