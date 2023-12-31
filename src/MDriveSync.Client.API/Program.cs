using MDriveSync.Core;
using Quartz.Logging;
using Serilog;
using Serilog.Debugging;
using Serilog.Settings.Configuration;

namespace MDriveSync.Client.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var env = builder.Environment;

            // ��������ļ�
            var configuration = builder.Configuration
                .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                // ���ȼ���Ĭ�ϵ�
                .AddJsonFile($"{ClientSettings.ClientSettingsPath}", optional: true, reloadOnChange: true)
                // �����ﻷ�������еĸ���Ĭ�ϵ�
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            //// ����Զ��������ļ�
            //builder.Configuration.AddJsonFile($"{ClientSettings.ClientSettingsPath}", optional: true, reloadOnChange: true);

            // �����Ϊ���� exe ����ʱ��ʹ�ô�����ʽ���� Serilog����������ȫ�����������ļ���
            // ����ܵ��� Serilog �ڳ����Զ����ֺͼ�������չ���򼯣��� Sinks��ʱ��������
            // ��ʽ���� Serilog���ڳ���� Main �����У�ʹ�ô�����ʽ���� Serilog����������ȫ�����������ļ���
            // ����Ҫô�ֶ��г� Sinks ����ͨ���������ַ�ʽ
            var logOptions = new ConfigurationReaderOptions(
                typeof(ConsoleLoggerConfigurationExtensions).Assembly);

            // ���� Serilog
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration, logOptions)

                // ���Ϊ���� exe �ļ����޷�д��־���������������д��
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);

            if (env.IsDevelopment())
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
                Log.Information($"Current: {Directory.GetCurrentDirectory()}");

                // ʹ�� Serilog
                builder.Host.UseSerilog();

                // ��ҵ�ͻ�������
                builder.Services.Configure<ClientOptions>(builder.Configuration.GetSection("Client"));

                builder.Services.AddControllers();

                // ��̨����
                //builder.Services.AddHostedService<TimedHostedService>();

                // ʹ�õ���ģʽ
                builder.Services.AddSingleton<TimedHostedService>();
                builder.Services.AddHostedService(provider => provider.GetRequiredService<TimedHostedService>());


                var app = builder.Build();

                //// ���� API �;�̬/�ͻ���·��
                //app.Use(async (context, next) =>
                //{
                //    if (context.Request.Path.StartsWithSegments("/api"))
                //    {
                //        // ����� API ���󣬼���ִ�к����м��
                //        await next();
                //    }
                //    //else
                //    //{
                //    //    app.MapFallbackToFile("index.html");

                //    //    //// �� API ���󣬳�����Ϊ��̬�ļ�����
                //    //    //await next();

                //    //    //// ���� API ������д���� index.html
                //    //    //if (!Path.HasExtension(context.Request.Path.Value))
                //    //    //{
                //    //    //    context.Request.Path = "/index.html";
                //    //    //    await next();
                //    //    //}
                //    //}
                //});

                app.UseStaticFiles();

                app.UseCors(builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
                });

                app.MapControllers();

                //app.MapGet("/", () =>
                //{
                //    return "ok";
                //});

                //app.UseEndpoints(endpoints =>
                //{
                //    //endpoints.MapControllers();

                //    // ���û���·��
                //    endpoints.MapFallbackToFile("index.html");
                //});

                // ���û���·��
                app.MapFallbackToFile("/", "index.html");

                //app.Use(async (context, next) =>
                //{
                //    await next();

                //    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                //    {
                //        context.Request.Path = "/index.html"; // �������ض�����ҳ
                //        await next();
                //    }
                //});

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