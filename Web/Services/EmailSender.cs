using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine("sender");
            await Execute(subject, htmlMessage, email);
        }

        private static async Task Execute(string subject, string message, string email)
        {
            Console.WriteLine("begin");
            var client = new MailjetClient("afd962e5cab08346e3ab9e9105b0cc4f", "e19c0a9da1a0a3f92464e9a60fbb6e4c")
            {
                Version = ApiVersion.V3_1
            };
            var request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.Messages, new JArray {
                new JObject {
                    {
                        "From",
                        new JObject {
                            {"Email", "boubacar-diarra@techm-studio.com"},
                            {"Name", "Boubacar from Hey-Eco"}
                        }
                    },
                    {
                        "To",
                        new JArray {
                            new JObject {
                                {
                                    "Email",
                                    email
                                },
                                {
                                    "Name",
                                    "Boubacar"
                                }
                            }
                        }
                    },
                    {
                        "Subject",
                        subject
                    },
                    {
                        "HTMLPart",
                        message
                    }
                }
            });
            var response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Total: {response.GetTotal()}, Count: {response.GetCount()}\n");
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine($"StatusCode: {response.StatusCode}\n");
                Console.WriteLine($"ErrorInfo: {response.GetErrorInfo()}\n");
                Console.WriteLine(response.GetData());
                Console.WriteLine($"ErrorMessage: {response.GetErrorMessage()}\n");
            }            
        }
    }
}
