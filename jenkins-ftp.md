# jenkins 中使用ftp自动布署

## 安装 Publish Over FTP Plugin 插件
[Publish Over FTP Plugin](https://wiki.jenkins-ci.org/display/JENKINS/Publish+Over+FTP+Plugin)
### 配置
在系统设置中配置ftp服务器地址
 - 服务器地址 HOST
 - 用户名 UserName
 - 密码 Password
 - Remote Directory：远程根目录（建议设置为：/）
 - Use active data mode： （未选中）默认选项使用PASV（被动模式），选中使用PORT （主动模式）
 - Don't make nested dirs：不创建下级目录（具体的自己看帮助）
 
 ## 项目配置
 
 - 构建后操作→Add post-build action→Send build artifacts over FTP
 - 选择系统设置中添加的服务器
 - Transfer Set Source files：需要上传的文件（注意：相对于工作区的路径,可以是单个文件也可以是目录）
如 `dist\**` 为工作目录下dist下的子目录及文件
`dist\*` 为目录
 - Remove prefix：移除目录（只能指定Transfer Set Source files中的目录）
 - Remote directory：远程目录（根据你的需求填写吧，因为我这儿是测试,所以偷懒直接用/）如`/aa.com.cn`,ftp中的目录
 - Exclude files：排除的文件（在你传输目录的时候很有用，使用通配符，例如：**/*.log,**/*.tmp,.git/）
 - Pattern separator：分隔符（配置Exclude files和Source files的分隔符。如果你这儿更改了，上面的内容也需要更改）
 - No default excludes：禁止默认的排除规则（具体的自己看帮助）
 - Make empty dirs：此选项会更改插件的默认行为。默认行为是匹配该文件是否存在，如果存在则创建目录存放。选中此选项会直接创建一个目录存放文件，即使是空目录。（个人理解）
 - Flatten files：只在ftp上建立文件，不创建目录（除了远程目录）
 - Remote directory is a date format:远程目录建立带日期的文件夹（需要在Remote directory中配置日期格式），具体格式参考下表：
Remote directory Directories created `'qa-approved/'yyyyMMddHHmmss`  `qa-approved/20101107154555`  `'builds/'yyyy/MM/dd/'build-${BUILD_NUMBER}'``builds/2010/11/07/build-456` (if the build was number 456) `yyyy_MM/'build'-EEE-d-HHmmss`  `2010_11/build-Sun-7-154555`  `yyyy-MM-dd_HH-mm-ss`  `2010-11-07_15-45-55` 
 - Clean remote:上传前会删除远程目录中的所有的文件（血的教训啊，测试的时候用的是运营小组的ftp，然后一不小心就把他们的数据删除了，害的我去做数据恢复。）
 - ASCII mode：文件传输的方式，一般默认不选
