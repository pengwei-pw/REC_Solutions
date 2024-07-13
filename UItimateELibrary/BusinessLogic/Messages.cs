using Microsoft.Extensions.Logging;
using System.Text.Json;
using UItimateELibrary.Models;

namespace UItimateELibrary.BusinessLogic
{
    public class Messages : IMessages
    {
        private readonly ILogger<Messages> logger;

        public Messages(ILogger<Messages> logger)
        {
            this.logger = logger;
        }

        public string Greeting(string languaage)
        {
            string output = LookUpCustomText("Greeting", languaage);
            return output;
        }

        private string LookUpCustomText(string key, string language)
        {

            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

            try
            {
                List<CustomText>? messageSets = JsonSerializer
                .Deserialize<List<CustomText>>
                (
                    File.ReadAllText("CustomText.json"), options
                );
                CustomText? messages = messageSets?.Where(x => x.Language == language).First();
                if (messages == null)
                {
                    throw new NullReferenceException("The specified language was not found in the json");
                }
                return messages.Translations[key];
            }
            catch (Exception ex)
            {
                logger.LogError("Erro looking up the custom text", ex);
                throw;
            }
        }
    }
}
