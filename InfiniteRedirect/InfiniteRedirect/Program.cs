using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapFallback(async c =>
{
    try
    {
        await Task.Delay(3000, c.RequestAborted);
    }catch (TaskCanceledException) { }
    c.Response.Redirect(c.Request.GetDisplayUrl());
});
app.Run();
