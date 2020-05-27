session
1 nugut session
2 在ConfigureServices中：
	services.addSession();
3 在Configure中：
    app.UseSession();
4 在controller中：
  HttpContext.Session.setSting("","");

=========================================
"ConnectionStrings": {
    "productconnection": "server=(localdb)\\MSSQLLOCALDb;database=productsdb;Trusted_Connection=true"
  }

services.AddDbContextPool<TodoContext>(
                options=>
                {
                    options.UseSqlServer(_configuration.GetConnectionString("productconnection"));
                });
-----------------------------------------------------------
json中文编码，在startup中
public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) ;
                }
                );
        }
写入页面
Response.ContentType = "text/plain;charset=utf-8";
===================================================
外部静态文件
public void Configure(IApplicationBuilder app)
{
     //第一个调用提供wwwroot文件夹中的静态文件。
　　 app.UseStaticFiles(); 
　　 //第二个调用使用URL http://<server_address>/MyImages浏览wwwroot/images文件夹的目录。
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
        RequestPath = "/MyImages"
    });
//显示目录
    app.UseDirectoryBrowser(new DirectoryBrowserOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
        RequestPath = "/MyImages"
    });
}
-------------------------------------------------------------
Core提供了UseFileServer对象，这个对象集成了UseStaticFiles、UseDefaultFiles和 UseDirectoryBrowser的功能。下面我们通过代码来看看如何使用。
public void ConfigureServices(IServiceCollection services)
{
    services.AddDirectoryBrowser();
}
public void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles(); // For the wwwroot folder

    app.UseFileServer(new FileServerOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
        RequestPath = "/StaticFiles",
        EnableDirectoryBrowsing = true
    });
}