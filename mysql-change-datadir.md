# Mysql 修改默认数据 存储位置
> 如：将默认存储文件夹由"C:/programdata/mysql/data" 迁移至 "D:/Database/Mysql"

 1. 停止Mysql服务
 2. 将 `c:/programdata/mysql/data` 目录中的文件拷贝到`D:/Database/Mysql`
 3. 修改`my.ini`中的`datadir`
 4. 增加目录`D:/Database/Mysql`中`networkservice`用户权限
 5. 启动`mysql`服务
