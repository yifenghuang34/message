using Microsoft.Extensions.DependencyInjection;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Message2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection service = new ServiceCollection();

            service.AddSingleton<IEmail, Email>();

            var provider = service.BuildServiceProvider().GetRequiredService<IEmail>();

            var message = new MimeMessage
            {
                Subject = "我是郵件主題",
                Body = new BodyBuilder
                {
                    HtmlBody = $"測試測試，時間:{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
                }.ToMessageBody()
            };

            await provider.SendEmailAsync(message);
        }
    }
}