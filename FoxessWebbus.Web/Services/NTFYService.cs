using FoxessWebbus.Web.Shared;
using ntfy;
using ntfy.Actions;
using ntfy.Requests;

public class NTFYService{

    public async Task SendNotification(string messageText){
        
        


         var client = new Client(SettingsHelper.ReadAppSetting<string>("NTFYServer"));
                
                // Publish a message to the "test" topic
                var message = new SendingMessage
                        {
                            Title = "Daily Daily Upload",
                            Message = messageText,
                            Actions = new ntfy.Actions.Action[]
                            {
                                new View("View Daily", new Uri("https://solar.connerpanaro.com/daily"))
                                {
                                }
                            }
                        };

                await client.Publish("solar", message);

    }

}