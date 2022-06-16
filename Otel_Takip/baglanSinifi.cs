using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
namespace Otel_Takip
{
    class baglanSinifi
    {
        public SqlConnection baglan = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = OTEL; Integrated Security = True;");
        public SqlCommand sorgu = new SqlCommand();
        public SqlDataReader dr;
        public OleDbConnection baglan2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=odalar.accdb");
        public OleDbCommand sorgu2 = new OleDbCommand();
        public OleDbDataReader dr2;
        public DataView goster = new DataView();
        public DataSet al = new DataSet();
     
    }
}
