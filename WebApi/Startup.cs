public class Startup
{
    public IConfiguration configRoot
    {
        get;
    }
    public Startup(IConfiguration configuration)
    {
        configRoot = configuration;
    }
    readonly string _specificOrigin = "specificOrigin";
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(o=>
        {
            o.AddPolicy("_specificOrigin",
                p=>p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        services.AddRazorPages();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseCors(_specificOrigin);
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}