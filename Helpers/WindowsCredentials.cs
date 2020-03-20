using Cook_Book_Client_Desktop_Library.Models;
using Meziantou.Framework.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cook_Book_Client_Desktop_Library.Helpers
{
    public static class WindowsCredentials
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void SaveLoginPassword(string UserName, string Password)
        {
            try
            {
                CredentialManager.WriteCredential(
                    applicationName: "Cook Book",
                    userName: UserName,
                    secret: Password,
                    persistence: CredentialPersistence.LocalMachine);
            }
            catch (Exception ex)
            {
                _logger.Error("Got exception", ex);
            }           
        }

        public static void DeleteLoginPassword()
        {
            try
            {
                CredentialManager.DeleteCredential(applicationName: "Cook Book");
            }
            catch (Exception ex)
            {
                _logger.Error("Got exception", ex);
            }          
        }

        public static WindowsCredentialsModel LoadLoginPassword()
        {
            WindowsCredentialsModel credModel = new WindowsCredentialsModel();
            try
            {
                var cred = CredentialManager.ReadCredential(applicationName: "Cook Book");

                credModel.UserName = cred.UserName;
                credModel.Password = cred.Password;
            }
        
            catch (Exception ex)
            {
                _logger.Error("Got exception", ex);
            }
           
            return credModel;
        }
    }
}
