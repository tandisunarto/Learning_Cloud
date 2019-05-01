using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orders.Schema;
using Orders.Services;

namespace LambdaGraphQLWebAPI
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public static IConfiguration Configuration { get; private set; }
        public static IHostingEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<CustomerType>();
            services.AddSingleton<OrderStatusesEnum>();
            services.AddSingleton<OrdersQuery>();
            services.AddSingleton<OrdersSchema>();
            services.AddSingleton<OrderCreateInputType>();
            services.AddSingleton<OrdersMutation>();
            services.AddSingleton<OrdersSubscription>();
            services.AddSingleton<OrderEventType>();
            services.AddSingleton<IOrderEventService, OrderEventService>();
            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            // services.AddGraphQLHttp();
            // services.AddGraphQLWebSocket<OrdersSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                // options.ExposeExceptions = Environment.IsDevelopment();
            })
            .AddWebSockets();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseWebSockets();
            app.UseGraphQL<OrdersSchema>("/graphql");
            // app.UseGraphQLWebSockets<OrdersSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                Path = "/ui/playground",
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql",
            });
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/ui/voyager"
            });

            app.UseMvc();
        }
    }
}