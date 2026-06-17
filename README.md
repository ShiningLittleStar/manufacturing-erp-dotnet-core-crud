# manufacturing-erp-dotnet-core-crud
# 制造业销售订单 API (Demo)

##  项目简介
这是一个基于 **.NET Core** 构建的 RESTful API 演示项目，主要用于展示在制造业 ERP 场景下，对销售订单模块的标准化 CRUD 操作。

## 核心功能
- 销售订单的增删改查 (CRUD)

## 本地运行
- **框架**: .NET Core 10.0 
- **ORM**: Entity Framework Core 
- **数据库**: SQL Server 2012+
1. 克隆仓库：`git clone [https://github.com/ShiningLittleStar/manufacturing-erp-dotnet-core-crud/]`
2. 修改 `appsettings.json` 中的数据库连接字符串
3. 执行数据库迁移：`dotnet ef database update`
4. 运行项目：`dotnet run`
5. 浏览器访问：`https://localhost:5001/openapi/v1.json` 查看接口

## 目录结构 (简略)
- `Controllers/` - 控制器层
- `Services/` - 服务层
- `Models/` - 实体与视图模型
- `TestContext/` - 数据库上下文
-'RequestLog' 日志中间件
