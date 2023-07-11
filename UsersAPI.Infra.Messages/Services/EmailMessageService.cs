using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using UsersAPI.Infra.Messages.Models;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Services
{
    public class EmailMessageService
    {
        private readonly EmailMessageSettings? emailMessageSettings;
        public EmailMessageService(IOptions<EmailMessageSettings?> emailMessageSettings)
        {
            this.emailMessageSettings = emailMessageSettings?.Value;
        }

        public async Task SendMessage(MessageRequestModel messageRequest)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var authResponse = await ExecuteAuth();

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.Token);

                    var messaRequestContent = new StringContent(JsonConvert.SerializeObject(messageRequest), Encoding.UTF8, "application/json");

                    await httpClient.PostAsync($@"{emailMessageSettings?.BaseUrl}/messages", messaRequestContent);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private async Task<AuthResponseModel> ExecuteAuth()
        {
            using (var httpClient = new HttpClient())
            {
                    var authRequest = new AuthRequestModel
                    {
                        Key = emailMessageSettings?.User,
                        Pass = emailMessageSettings?.Pass
                    };

                    var authRequestContent = new StringContent(JsonConvert.SerializeObject(authRequest),
                        Encoding.UTF8, "application/json");

                    var authResponse = await httpClient.PostAsync($@"{emailMessageSettings?.BaseUrl}/auth", authRequestContent);

                    return ReadResponse<AuthResponseModel>(authResponse);
            }
        }

        private T ReadResponse<T>(HttpResponseMessage response)
        {
            var builder = new StringBuilder();
            using (var item = response.Content)
            {
                var task = item.ReadAsStringAsync();
                builder.Append(task.Result);
            }

            return JsonConvert.DeserializeObject<T>(builder.ToString());
        }
    }
}
