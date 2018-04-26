## VueRoute使用history模式

### 开发模式
- 修改路由
```javascript
const router = new VueRouter({
  base: '/survey/', --多页面要配置这里，搞好几天才搞明白
  mode: 'history', 
  routes
})
```
- 使用 `connect-history-api-fallback`组件
- 配置rewrites
```javascript
let rewrites = Object.keys(utils.getEntries('./src/pages/**/app.js'))
    .map(function (entry) {
        return {
            from: new RegExp('/' + entry),
            to: '/' + entry + '/index.html'
        };
    });
console.log(rewrites)
var history = require('connect-history-api-fallback')
app.use(history({
  //index: '/survey/index.html',
  rewrites,
  verbose: true,
  disableDotRule: true,
  htmlAcceptHeaders: ['text/html', 'application/xhtml+xml'],
  logger: console.log.bind(console)
}))
```

### 生产环境IIS配置
- 安装`IIS URLRewriter` 插件
- 根目录下增加配置文件`web.config`,内容如下
```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.webServer>
    <rewrite>
      <rules>
        <rule name="survey" stopProcessing="true">
          <match url="(^survey/.*)" />
          <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
          </conditions>
          <action type="Rewrite" url="/index.html" />
        </rule>
        <rule name="answer" stopProcessing="true">
          <match url="(^answer/.*)" />
          <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
          </conditions>
          <action type="Rewrite" url="/answer/index.html" />
        </rule>
      </rules>
    </rewrite>
  </system.webServer>
</configuration>
```
