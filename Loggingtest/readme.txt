https://www.cnblogs.com/FlyLolo/p/ASPNETCore2_12.html
https://blog.csdn.net/huanghuangtongxue/article/details/79083975
1、安装NLog，搜索 NLog.Web.AspNetCore，并将它安装在web项目中。
2、配置NLog，在StartUpzz启动类中的 Configure 方法中 配置NLog，见项目根目录；
3.在startup中配置
  Configure方法加入
  loggerFactory.ConfigureNLog("nlog.config");
   loggerFactory.AddNLog();
4.由低到高
    logger.LogTrace();
    logger.LogDebug();
    logger.LogInformation();
    logger.LogWarning();
    logger.LogError();
    logger.LogCritical();

某些情况
NLog.LogManager.GetCurrentClassLogger().Trace("-==-=-=-=-ILogger LogTrace from WeatherForecastController");
取代
logger.LogTrace("");