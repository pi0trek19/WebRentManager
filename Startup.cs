﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebRentManager.Models;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace WebRentManager
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ITemplateService,TemplateService>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(_config.GetConnectionString("RentManagerConnection")));
            services.AddScoped<ICarsRepository, CarsRepository>();
            services.AddScoped<IServicesRepository, ServicesRepository>();
            services.AddScoped<ITyreInfosRepository, TyreInfosRepository>();
            services.AddScoped<ITyreShopsRepository, TyreShopsRepository>();
            services.AddScoped<IFinancialInfosRepository, FinancialInfosRepository>();
            services.AddScoped<IMilageRecordsRepository, MilageRecordsRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IRentsRepository, RentsRepository>();
            services.AddScoped<ICarExpensesRepository, CarExpensesRepository>();
            services.AddScoped<ICarDamagesRepository, CarDamagesRepository>();
            services.AddScoped<IHandoverDocumentsRepository,HandoverDocumentsRepository>();
            services.AddScoped<IMailMessagesRepository, MailMessagesRepository>();
            services.AddScoped<IInsurancePoliciesRepository, InsurancePoliciesRepository>();
            services.AddScoped<ICashDepositActionsRepository, CashDepositActionsRepository>();
            services.AddScoped<ICashDepositsRepository, CashDepositsRepository>();
            //pliki
            services.AddScoped<IFileDescriptionsRepository, FileDescriptionsRepository>();
            //tabele many to many
            services.AddScoped<ICarFilesRepository, CarFilesRepository>();
            services.AddScoped<IClientFilesRepository, ClientFilesRepository>();
            services.AddScoped<IRentFilesRepository, RentFilesRepository>();
            services.AddScoped<IHandoverDocumentFilesRepository, HandoverDocumentFilesRepository>();
            services.AddScoped<IInsuranceClaimFilesRepository, InsuranceClaimFilesRepository>();
            services.AddScoped<IServiceFilesRepository, ServiceFilesRepository>();
            services.AddScoped<ICarExpenseFilesRepository, CarExpenseFilesRepository>();
            services.AddScoped<ICarDamageFilesRepository, CarDamageFilesRepository>();
            services.AddScoped<IInsurancePolicyFilesRepository, InsurancePolicyFilesRepository>();
            services.AddScoped<IInvoicesRepository, InvoicesRepository>();
            services.AddScoped<IIncomesRepository, IncomesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
