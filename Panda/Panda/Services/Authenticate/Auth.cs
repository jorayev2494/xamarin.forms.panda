using Newtonsoft.Json;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Panda.Services.Authenticate
{
    public class Auth
    {
        private const string AUTH_USER = "auth_user";
        private const string ACCESS_TOKEN = "access_token";

        #region AuthData
        public static bool HasAuthUser()
        {
            return Application.Current.Properties.ContainsKey(AUTH_USER);
        }

        public static User GetAuthUser()
        {
            if (HasAuthUser())
            {
                string objAuthUser = (string)Application.Current.Properties[AUTH_USER];
                return JsonConvert.DeserializeObject<User>(objAuthUser);
            }

            return default(User);
        }

        public static void SetAuthUser(User model)
        {
            string strUserData = JsonConvert.SerializeObject(model);

            if (HasAuthUser())
            {
                RemoveAuthUser();
            }

            Application.Current.Properties.Add(AUTH_USER, strUserData);
        }

        public static void RemoveAuthUser()
        {
            Application.Current.Properties.Remove(AUTH_USER);
        }
        #endregion

        #region AccessToken
        public static bool HasAccessToken()
        {
            return Application.Current.Properties.ContainsKey(ACCESS_TOKEN);
        }

        public static string GetAccessToken()
        {
            if (HasAccessToken())
            {
                object objAccessToken = Application.Current.Properties[ACCESS_TOKEN];
                return objAccessToken as string;
            }

            return string.Empty;
        }

        public static void SetAccessToken(string accessToken)
        {

            if (HasAccessToken())
            {
                RemoveAccessToken();
            }

            Application.Current.Properties.Add(ACCESS_TOKEN, accessToken);
        }

        public static void RemoveAccessToken()
        {
            Application.Current.Properties.Remove(ACCESS_TOKEN);
        }
        #endregion
    }
}
