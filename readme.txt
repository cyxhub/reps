session
1 nugut session
2 在ConfigureServices中：
	services.addSession();
3 在Configure中：
    app.UseSession();
4 在controller中：
  HttpContext.Session.setSting("","");