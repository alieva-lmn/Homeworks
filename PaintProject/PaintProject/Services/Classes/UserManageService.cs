using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using User = PaintProject.Model.User;


namespace PaintProject.Services.Classes
{
    public class UserManageService : IUserManageService
    {
        private readonly HttpClient _httpClient;

        public UserManageService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/");
        }

        public async Task<bool> CheckUserExistsAsync(string username)
        {
            try
            {
                string apiUrl = $"checkuserexists?username={username}";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return bool.Parse(result);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"{ex.Message}");
                return false;
            }
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            try
            {
                string apiUrl = $"getuser?username={username}&password={password}";
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    if (jsonResponse == "User not found")
                    {
                        return null;
                    }
                    else
                    {
                        User user = JsonConvert.DeserializeObject<User>(jsonResponse);
                        return user;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error sending the request: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                string userJson = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var content = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("adduser", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return bool.Parse(result);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"{ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                string userJson = JsonConvert.SerializeObject(user, settings);
                var content = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("updateuser", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return bool.Parse(result);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"{ex.Message}");
                return false;
            }
        }

    }
}
