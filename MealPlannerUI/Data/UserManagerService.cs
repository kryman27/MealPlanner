using ModelsLib.DTOs;
using ModelsLib.Model;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ConfigManager = MealPlannerUI.ConfigManagerNamespace.ConfigManager;

namespace MealPlannerUI.Data
{
    public class UserManagerService
    {
        private UserDataDTO userDataDTO;
        public bool loginFlag { get; set; }
        private ConfigManager ConfigMang { get => ConfigManager.GetInstance(); }



        public async Task<UserDataDTO> LoginUser(string userName, string userPassword)
        {
            var userNameHash = CreateHash(userName);
            var passwordHash = CreateHash(userPassword);

            using(HttpClient client = new HttpClient())
            {
                var requestUrl = $"{ConfigMang.apiUrl}/login";
                
                var temp = new UserData(0, userNameHash, passwordHash);
                var jsonContent = JsonSerializer.Serialize(temp);

                var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                //var requestContent = JsonContent.Create(jsonContent);
                request.Content = requestContent;

                var response = client.SendAsync(request);
                //var response = await client.PostAsJsonAsync(requestUrl, requestContent);
                var test = response.Result.Content.ReadAsStringAsync().Result;
                //var test = response.Content.ReadAsStreamAsync();

                var result = JsonSerializer.Deserialize<UserDataDTO>(test);

                if (result is UserDataDTO && result != null)
                {
                    this.userDataDTO = result;
                    this.loginFlag = true; 
                }

                return result;
            }
        }

        private static string CreateHash(string input)
        {
            StringBuilder sb = new();
            foreach (byte b in CreateHashBytes(input))
            {
                sb.Append(b.ToString("X2").ToLowerInvariant());
            }

            return sb.ToString();
        }

        private static byte[] CreateHashBytes(string input)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        }
    }
}
