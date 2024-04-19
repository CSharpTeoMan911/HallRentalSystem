using HallRentalSystem.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;

namespace HallRentalSystem
{

    internal class Program:Firebase_Database
    {
        public static bool Is_API_Testing_Mode;
        public static bool EnableSSL;
        private static void Main(string[] args)
        {
            // COMMAND LINE SWAGGER API TESTING MODE
            //
            //Enable_Or_Disable_Https_Certificate_Validation();


            // PROGRAMATICALLY SET SWAGGER API TESTING MODE ( "y" for yes; "n" for no; )
            //
            Enable_Or_Disable_Https_Certificate_Validation_Programatically("n");

            // INITIATE THE FIREBASE DATABASE CONNECTION
            InitiateFirebaseDatabase();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMvcCore().AddApiExplorer();
            builder.Services.AddControllers();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                // COMMAND LINE SWAGGER API TESTING MODE
                //
                //Enable_Or_Disable_Swagger(app);


                // PROGRAMATICALLY SET SWAGGER API TESTING MODE ( "y" for yes; "n" for no; )
                //
                Enable_Or_Disable_Swagger_Programatically(app, "n"); 
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        private static void Enable_Or_Disable_Swagger(WebApplication app)
        {
            Console.Write("\n\nEnable API testing mode ( [ y ] for yes; [ n ] for no; ): ");
            string? input = Console.ReadLine()?.ToLower();
            Console.Clear();

            switch (input)
            {
                case "y":
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    });
                    Is_API_Testing_Mode = true;
                    break;
                case "n":
                    return;
                default:
                    Enable_Or_Disable_Swagger(app);
                    break;
            }
        }


        private static void Enable_Or_Disable_Swagger_Programatically(WebApplication app, string input)
        {
            switch (input)
            {
                case "y":
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    });
                    Is_API_Testing_Mode = true;
                    break;
                case "n":
                    return;
                default:
                    return;
            }
        }

        private static void Enable_Or_Disable_Https_Certificate_Validation()
        {
            Console.Write("\n\nEnable SSL certificate security and validation ( [ y ] for yes; [ n ] for no; ): ");
            string? input = Console.ReadLine()?.ToLower();
            Console.Clear();

            switch (input)
            {
                case "y":
                    EnableSSL = true;
                    break;
                case "n":
                    return;
                default:
                    Enable_Or_Disable_Https_Certificate_Validation();
                    break;
            }
        }


        private static void Enable_Or_Disable_Https_Certificate_Validation_Programatically(string input)
        {
            switch (input)
            {
                case "y":
                    EnableSSL = true;
                    break;
                case "n":
                    return;
                default:
                    return;
            }
        }
    }
}