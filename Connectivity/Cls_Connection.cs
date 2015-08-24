                                                                                                                                                                                                                                    using MySql.Data.MySqlClient;


namespace Connectivity
{
    public class Cls_Connection
    {

        static MySqlConnection _conCls;

        public static MySqlConnection getConnection()
          {

              //_conCls = new MySqlConnection("server=166.62.17.224;Port=3307;User Id=root;password=;Persist Security Info=True;database=waterdispenser;");
              _conCls = new MySqlConnection("server=166.62.17.224;Port=3307;User Id=eideas;password=eideas@123;Persist Security Info=True;database=pettycash_ms_new;");
              //_conCls = new MySqlConnection("server=localhost;Port=3306;User Id=root;password=admin;Persist Security Info=True;database=pettycash_ms;");
              //_conCls = new MySqlConnection("server=localhost;Port=3306;User Id=root;password=admin;Persist Security Info=True;database=pcms;");
              //_conCls = new MySqlConnection("server=localhost;Port=3306;User Id=root;password=tstc123;Persist Security Info=True;database=eideas_msc_dup;");
              //_conCls = new MySqlConnection("server=118.139.178.22;Port=3307;User Id=eideas;password=eideas@123;Persist Security Info=True;database=eideas_msc;");
              //_conCls = new MySqlConnection("server=166.62.17.224;Port=3307;User Id=eideas;password=eideas@123;Persist Security Info=True;database=waterdispenser;");

            return _conCls;

        }








    }
}
