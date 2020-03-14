using Cook_Book_Client_Desktop_Library.Models;
using Meziantou.Framework.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cook_Book_Client_Desktop_Library.Helpers
{
    public static class WindowsCredentials
    {
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

                //
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
                //
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

                //
            }
           
            return credModel;
        }
    }
}
