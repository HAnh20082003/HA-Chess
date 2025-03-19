using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace HAChess_BetterAtChess
{
    public class SQL
    {
        //private static string strConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=db_QLCoVua;MultipleActiveResultSets=True;";
        private static string strConnection = @"Data Source=45.119.85.244;Initial Catalog=QLCoVua;Persist Security Info=True;User ID=QLCV;Password=QLCV@123;MultipleActiveResultSets=True;";
        private static SqlConnection sqlConnection;

        public static string StrConnection { get => strConnection; set => strConnection = value; }
        public static SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public static void CreateConnect()
        {
            if (SqlConnection == null)
                SqlConnection = new SqlConnection(StrConnection);
            if (SqlConnection.State == ConnectionState.Closed)
                SqlConnection.Open();
        }
        public static void CloseConnect()
        {
            SqlConnection.Close();
        }
        //Truy vấn trả về 1 giá trị
        public static object Excute_A_Value(string codeSQL, List<string> parameters = null, List<object> values = null)
        {
            CreateConnect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = codeSQL;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    sqlcmd.Parameters.AddWithValue(parameters[i], values[i]);
                }
            }
            sqlcmd.Connection = SqlConnection;
            return sqlcmd.ExecuteScalar(); ;
        }

        //Truy vấn trả về 1 hoặc nhiều dòng giá trị
        public static DataTable Excute_Values(string codeSQL, List<string> parameters = null, List<object> values = null)
        {
            CreateConnect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = codeSQL;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    sqlcmd.Parameters.AddWithValue(parameters[i], values[i]);
                }
            }
            sqlcmd.Connection = SqlConnection;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }

        //Truy vấn thêm, xoá, sửa,.... (không trả về giá trị)
        public static void Excute_Non_Value(string codeSQL, List<string> parameters, List<object> values, bool option = true)
        {
            CreateConnect();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            if (option)
            {
                codeSQL += " OPTION (OPTIMIZE FOR UNKNOWN)";
            }
            sqlcmd.CommandText = codeSQL;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    sqlcmd.Parameters.AddWithValue(parameters[i], values[i]);
                }
            }
            sqlcmd.Connection = SqlConnection;
            sqlcmd.ExecuteNonQuery();
        }
        //Chuyển hình ảnh sang mảng bytes
        public static byte[] ConvertImageToBytes(Image img, string tail)
        {
            MemoryStream ms = new MemoryStream();
            if (img != null)
            {
                if (tail == ".gif")
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                else if (tail == ".png")
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                else
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        //Chuyển mảng bytes về lại ảnh
        public static Image ConvertBytesToImage(byte[] img_byte)
        {
            MemoryStream ms = new MemoryStream(img_byte);
            try
            {
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }
        public static byte[] convertVideoToBytes(string path)
        {
            byte[] buffer = new byte[15000000];
            using (Stream video = File.OpenRead(path))
            {
                video.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
