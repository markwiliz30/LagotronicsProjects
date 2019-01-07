using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using UserLib;

namespace FirebaseLib
{
    public class FirebaseClass
    {
        private static IFirebaseConfig config;
        private static IFirebaseClient client;
        private UserItem user;
        private List<UserItem> userList;

        public string RequireCredits(string authKey, string dbPath)
        {
            config = new FirebaseConfig
            {
                AuthSecret = authKey,
                BasePath = dbPath
            };

            client = new FireSharp.FirebaseClient(config);

            if (CheckForInternetConnection())
            {
                if (client != null)
                {
                    return "Connected";
                }
                return "Connection Fail";
            }
            else
            {
                return "Connection Fail";
            }
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://console.firebase.google.com/project/rfidtest-931fa/database/firestore/data~2Fusers"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public async void SaveUser(string rfId, string name, int load, int balance, string points, string sc_acc, string date_reg, string time_reg)
        {
            user = new UserItem();
            int holdBalance;

            user.RF_ID = rfId;
            user.Name = name;
            holdBalance = balance + load;
            user.Balance = holdBalance.ToString();
            user.Points = points;
            user.Sc_Account = sc_acc;
            user.Date_Inserted = date_reg;
            user.Time_Inserted = time_reg;

            SetResponse response = await client.SetTaskAsync("User/" + user.RF_ID, user);
            UserItem result = response.ResultAs<UserItem>();
        }
        public async Task<UserItem> CheckExisting(string rfId)
        {
            FirebaseResponse response = await client.GetTaskAsync("User/" + rfId);
            if (response.Body == "null")
            {
                return null;
            }
            UserItem obj = response.ResultAs<UserItem>();

            return obj;
        }
        public async Task<List<UserItem>> GetAllUsers()
        {
            FirebaseResponse response = await client.GetTaskAsync("User/");
            userList = new List<UserItem>();

            if (response.Body == "null")
            {
                return null;
            }
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            userList.Clear();
            foreach (var itemDynamic in data)
            {
                userList.Add(JsonConvert.DeserializeObject<UserItem>(((JProperty)itemDynamic).Value.ToString()));
            }
            return userList;
        }
        public async Task<string> DeleteUser(string id)
        {
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("User/" + id);
                if (response.Body == "null")
                {
                    return "User not existing";
                }

                response = await client.DeleteTaskAsync("User/" + id);
                return "Deleted Successfully";
            }
            catch
            {
                return "Deletion Fail";
            }
        }
        public async Task<string> DeleteAllUser()
        {
            try
            {
                FirebaseResponse response = await client.DeleteTaskAsync("User/");
                return "All Users are Deleted Successfully";
            }
            catch
            {
                return "Deletion of all users failed";
            }
        }
    }
}
