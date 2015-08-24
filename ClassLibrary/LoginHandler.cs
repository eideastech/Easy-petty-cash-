using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using DataProcess_PCMS;
using DataProcess_PCMS_Objects;

namespace ClassLibrary
{
    public class LoginHandler
    {
        public bool checkUserLogin(string username, string password)
        {
            bool validate = false;
            CookieHandler userCookie = new CookieHandler();
            core_user_access dbAccess = new core_user_access();
            //core_user_access dbAccess = new core_user_access();
            DataSet ds = dbAccess.SelectMethod(@"SELECT Id_User_Access,Username,Password FROM core_user_access WHERE Username='" + username + "'  AND Password='" + password + "' AND Is_Active=0;", "core_user_access");
            if (ds.Tables[0].Rows.Count > 0)
            {
                validate = true;
                string userId = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();

                //Create Cookie
                if (userCookie.readCookie("authentication") != null)
                {
                    userCookie.deleteCookie("authentication");
                }
                userCookie.writeCookie("authentication", userId);
                ////

            }
            else
            {
                userCookie.deleteCookie("authentication");
            }
            return validate;
        }

        //public bool isUserLogedIn()
        //{
        //    bool check = false;
        //    //Cookie Check
        //    CookieHandler userCookie = new CookieHandler();
        //    if (userCookie.readCookie("authentication") != null)
        //    {
        //        check = true;
        //    }
        //    ////

        //    //Session Check


        //    return check;
        //}

        //public bool logOut()
        //{
        //    CookieHandler userCookie = new CookieHandler();
        //    return userCookie.deleteCookie("authentication");
        //}

        //public int getLoggedUserId()
        //{
        //    CookieHandler userCookie = new CookieHandler();
        //    int userId = -1; int.TryParse(userCookie.readCookie("authentication"), out userId);
        //    return userId;
        //}

        //public int getLoggedEmployeeId()
        //{
        //    CookieHandler userCookie = new CookieHandler();
        //    string userId = userCookie.readCookie("authentication");
        //    CommonDbAccess dbAccess = new CommonDbAccess();
        //    DataSet dst = dbAccess.SelectMethod("SELECT user_details.Id_Hrm_Employee FROM user_details WHERE user_details.idUser_details='" + userId + "'", "checkLogin");
        //    if (dst.Tables[0].Rows.Count > 0)
        //    {
        //        string employeeId = dst.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        //        return int.Parse(employeeId);
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

        //public string[] getLoggedEmployeeName()
        //{
        //    CookieHandler userCookie = new CookieHandler();
        //    string userId = userCookie.readCookie("authentication");
        //    CommonDbAccess dbAccess = new CommonDbAccess();
        //    DataSet dst = dbAccess.SelectMethod("SELECT CONCAT(hrm_employee.first_name,' ', hrm_employee.Employee_Middle_Name,' ', hrm_employee.last_name),hrm_employee.Employee_Image_Path FROM user_details,hrm_employee WHERE user_details.idUser_details='" + userId + "' AND hrm_employee.Id_Hrm_Employee =user_details.Id_Hrm_Employee", "checkLogin");
        //    string[] ar = new string[2];
        //    if (dst.Tables[0].Rows.Count > 0)
        //    {
        //        string employeeName = dst.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
        //        string employeeImage = dst.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
        //        ar[0] = employeeName;
        //        ar[1] = employeeImage;
        //        return ar;
        //    }
        //    else
        //    {
        //        return ar;
        //    }

        //}

        
        //public string getLoggedEmail()
        //{
        //    string empEmail = "";
        //    CookieHandler userCookie = new CookieHandler();
        //    string userId = userCookie.readCookie("authentication");
        //    CommonDbAccess dbAccess = new CommonDbAccess();
        //    DataSet dst = dbAccess.SelectMethod("Select hrm_employee.hrm_employeecol From user_details Inner Join hrm_employee On user_details.Id_Hrm_Employee = hrm_employee.Id_Hrm_Employee  WHERE user_details.idUser_details='" + userId + "'", "checkLogin");
        //    if (dst.Tables[0].Rows.Count > 0)
        //    {
        //        empEmail = dst.Tables[0].Rows[0]["hrm_employeecol"].ToString();

        //    }

        //    return empEmail;
        //}

        
        //public string getLogingEmpName()
        //{
        //    string EmpName = "";
        //    CookieHandler userCookie = new CookieHandler();
        //    string userId = userCookie.readCookie("authentication");
        //    CommonDbAccess dbAccess = new CommonDbAccess();
        //    DataSet dst = dbAccess.SelectMethod("SELECT CONCAT(hrm_employee.first_name,' ', hrm_employee.Employee_Middle_Name,' ', hrm_employee.last_name) as empName FROM user_details,hrm_employee WHERE user_details.idUser_details='" + userId + "' AND hrm_employee.Id_Hrm_Employee =user_details.Id_Hrm_Employee", "checkLogin");
        //    if (dst.Tables[0].Rows.Count > 0)
        //    {
        //        EmpName = dst.Tables[0].Rows[0]["empName"].ToString();

        //    }

        //    return EmpName;
        //}

    }
}



