var builder = WebApplication.CreateBuilder();

builder.Services.AddMassTransit(x => 
{
	//find anything that implements the IConsumer interface in the assembly that contains the type of Program.cs
	x.AddConsumers(typeof(Program).Assembly);
	x.UsingInMemory((context, config) => 
	{
		config.ConfigureEndpoints(context);
	});
});

builder.Services.AddHostedService<PingPublisher>();

var app = builder.Build();

app.Run();
