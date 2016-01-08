using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace Backend.Logic
{
    public class LdapLogic
    {
        private string _path;
        private string _filterAttribute;
        private string test = "LDAP://DC=itbscorp,DC=local";

        public LdapLogic(string path)
        {
            _path = "";
        }

        public bool IsAuthenticated(string domain, string username, string pwd)
        {
            
              
                DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.1.1", username, pwd);
                 entry.Path = test;
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
                //Update the new path to the user in the directory.
                _path = result.Path;
                _filterAttribute = (string)result.Properties["cn"][0];
                return true;
            
            

            
        }

    }
}