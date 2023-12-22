using MDriveSync.Core;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz.Logging;
using Serilog;
using Serilog.Debugging;

namespace MDriveSync.Server.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���� Serilog
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration);

            if (builder.Environment.IsDevelopment())
            {
                logger.MinimumLevel.Debug()
                      .Enrich.FromLogContext()
                      .WriteTo.Console();

                // ʹ�� Serilog.Debugging.SelfLog.Enable(Console.Error) ������ Serilog ��������ϣ��⽫��������������⡣
                SelfLog.Enable(Console.Error);
            }

            Log.Logger = logger.CreateLogger();

            // Quartz Log
            var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);
            LogProvider.SetLogProvider(loggerFactory);

            // ȷ����Ӧ�ó������ʱ�رղ�ˢ����־
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();

            try
            {
                // ʹ�� Serilog
                builder.Host.UseSerilog();

                // �������̷���������
                builder.Services.Configure<AliyunDriveProviderOptions>(builder.Configuration.GetSection("AliyunDriveProvider"));

                // �ٶ����̷���������
                builder.Services.Configure<BaiduNetDiskProviderOptions>(builder.Configuration.GetSection("BaiduNetDiskProvider"));

                builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                builder.Services.AddMemoryCache();

                builder.Services.AddControllers();

                var app = builder.Build();

                app.UseCors(builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
                });

                app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });

                app.MapControllers();

                app.MapGet("/", () =>
                {
                    return "ok";
                });

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ӧ������ʧ��");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}