session
1 nugut session
2 ��ConfigureServices�У�
	services.addSession();
3 ��Configure�У�
    app.UseSession();
4 ��controller�У�
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
json���ı��룬��startup��
public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) ;
                }
                );
        }
д��ҳ��
Response.ContentType = "text/plain;charset=utf-8";
===================================================
�ⲿ��̬�ļ�
public void Configure(IApplicationBuilder app)
{
     //��һ�������ṩwwwroot�ļ����еľ�̬�ļ���
���� app.UseStaticFiles(); 
���� //�ڶ�������ʹ��URL http://<server_address>/MyImages���wwwroot/images�ļ��е�Ŀ¼��
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
        RequestPath = "/MyImages"
    });
//��ʾĿ¼
    app.UseDirectoryBrowser(new DirectoryBrowserOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
        RequestPath = "/MyImages"
    });
}
-------------------------------------------------------------
Core�ṩ��UseFileServer����������󼯳���UseStaticFiles��UseDefaultFiles�� UseDirectoryBrowser�Ĺ��ܡ���������ͨ���������������ʹ�á�
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