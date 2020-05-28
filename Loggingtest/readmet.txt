nlog的一些配置说明
$ {activityid} - 将一个System.Diagnostics跟踪关联ID放入日志中。
$ {all-event-properties} - 记录所有事件上下文数据。
$ {appdomain} - 当前的应用程序域。
$ {assembly-version} - 默认应用程序域中可执行文件的版本。
$ {basedir} - 当前应用程序域的基本目录。
$ {callsite} - 呼叫站点（类名称，方法名称和源信息）。
$ {callsite-linenumber} - 呼叫站点源行号。
$ {counter} - 一个计数器值（每个布局渲染都会增加）。
$ {currentdir} - 应用程序的当前工作目录。
$ {date} - 当前日期和时间。
$ {document-uri} - 托管当前Silverlight应用程序的HTML页面的URI。
$ {environment} - 环境变量。
$ {event-properties} - 记录事件属性数据 - 重命名$ {event-context}。
$ {exception} - 通过调用其中一个Logger * Exception（）方法提供的异常信息。
$ {file-contents} - 渲染指定文件的内容。
$ {gc} - 关于垃圾收集器的信息。
$ {gdc} - 全局诊断上下文项目。字典结构来保存每个应用程序实例值。
$ {guid} - 全局唯一标识符（GUID）。
$ {identity} - 线程标识信息（名称和认证信息）。
$ {install-context} - 安装参数（传递给InstallNLogConfig）。
$ {level} - 日志级别。
$ {literal} - 一个字符串文字。
$ {log4jxmlevent} - 与log4j，Chainsaw和NLogViewer兼容的XML事件描述。
$ {logger} - 记录器名称。
$ {longdate} - 日期和时间格式很长，可排序yyyy-MM-dd HH:mm:ss.ffff。
$ {machinename} - 进程正在运行的机器名称。
$ {mdc} - 映射的诊断上下文 - 一个线程局部结构。
$ {mdlc} - 异步映射的诊断上下文 - 一个线程局部结构。
$ {message} - 格式化的日志消息。
$ {ndc} - 嵌套的诊断上下文 - 一个线程局部结构。
$ {ndlc} - 异步嵌套诊断上下文 - 一个线程局部结构。
$ {newline} - 换行符。
$ {nlogdir} - NLog.dll所在的目录。
$ {performancecounter} - 性能计数器。
$ {processid} - 当前进程的标识符。
$ {processinfo} - 关于正在运行的进程的信息。
$ {processname} - 当前进程的名称。
$ {processtime} - 格式为HH：mm：ss.mmm的处理时间。
$ {qpc} - 高精度计时器，基于从QueryPerformanceCounter（）返回的值（可选地转换为秒）。
$ {registry} - 来自注册表的值。
$ {sequenceid} - 日志序列标识
$ {shortdate} - 可排序格式的短日期yyyy-MM-dd。
$ {sl-appinfo} - 有关Silverlight应用程序的信息。
$ {specialfolder} - 系统特殊文件夹路径（包括我的文档，我的音乐，程序文件，桌面等）。
$ {stacktrace} - 堆栈跟踪渲染器。
$ {tempdir} - 一个临时目录。
$ {threadid} - 当前线程的标识符。
$ {threadname} - 当前线程的名称。
$ {ticks} - 当前日期和时间的Ticks值。
$ {time} - 以24小时可排序格式HH：mm：ss.mmm的时间。
$ {var} - 渲染变量（4.1中新增）
$ {windows-identity} - 线程Windows身份信息（用户名）。
包装
$ {cached} - 将缓存应用于另一个布局输出。
$ {filesystem-normalize} - 通过用安全字符替换文件名中不允许的字符。
$ {json-encode} - 使用JSON规则转义另一个布局的输出。
$ {lowercase} - 将另一个布局输出的结果转换为小写。
$ {onexception} - 仅在为日志消息定义异常时才输出内部布局。
$ {pad} - 将填充应用于另一个布局输出。
$ {replace} - 用另一个字符串替换另一个布局输出中的字符串。
$ {replace-newlines} - 用另一个字符串替换换行符。
$ {rot13} - 用ROT-13解码“encrypted”文本。
$ {trim-whitespace} - 修剪另一个布局渲染器的结果中的空白。
$ {uppercase} - 将另一个布局输出的结果转换为大写。
$ {url-encode} - 编码另一个布局输出的结果以用于URL。
$ {when} - 只有在满足指定条件时才输出内部布局。
$ {whenEmpty} - 当内部布局产生空结果时输出替代布局。
$ {WrapLine} - 在指定的行长度处包装另一个布局输出的结果。
$ {xml-encode} - 将另一个布局输出的结果转换为XML兼容。
NLog.Extended软件包
$ {appsetting} - 应用程序配置设置。
NLog.Web包
$ {aspnet-MVC-Action} - ASP.NET MVC动作名称
$ {aspnet-MVC-Controller} - ASP.NET MVC控制器名称
$ {aspnet-Application} - ASP.NET应用程序变量。
$ {aspnet-Item} - ASP.NET HttpContext项目变量。
$ {aspnet-TraceIdentifier} - ASP.NET跟踪标识符
$ {aspnet-Request} - ASP.NET请求变量。
$ {aspnet-Request-Cookie} - ASP.NET请求cookie内容。
$ {aspnet-Request-Host} - ASP.NET请求主机。
$ {aspnet-Request-Method} - ASP.NET请求方法（GET，POST等）。
$ {aspnet-Request-IP} - 客户端IP。
$ {aspnet-Request-QueryString} - ASP.NET请求查询字符串。
$ {aspnet-Request-Referrer} - ASP.NET请求引用者。
$ {aspnet-Request-UserAgent} - ASP.NET请求useragent。
$ {aspnet-Request-Url} - ASP.NET请求URL。
$ {aspnet-Session} - ASP.NET Session变量。
$ {aspnet-SessionId} - ASP.NET会话ID变量。
$ {aspnet-User-isAuthenticated} - ASP.NET用户身份验证？
$ {aspnet-User-AuthType} - ASP.NET用户身份验证。
$ {aspnet-User-Identity} - ASP.NET用户变量。
$ {iis-site-name} - IIS站点名称。

https://blog.csdn.net/f335830104/java/article/details/96138327