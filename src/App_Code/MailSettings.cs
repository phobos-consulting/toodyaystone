using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for MailSettings
/// </summary>
public class MailSettings
{
    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    public static string Username
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUsername"];
        }
    }

    public static string Password
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

    public static string SenderEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["SenderEmail"];
        }
    }

    public static string ContactEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ContactEmail"];
        }
    }

    public static bool RequiresCredentials
    {
        get
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["MailServerRequiresCredentials"]);
        }
    }
}
