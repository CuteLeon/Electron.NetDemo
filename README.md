# Electron.Net Demo

## 项目类型：

Asp.Net Core 3.0 MVC

## 初始化环境：

- 安装 [Node.js](https://nodejs.org/zh-cn/download/)

- 安装 Electron.CLI

  ​	程序包管理器控制台：

  ```
  dotnet tool install ElectronNET.CLI -g
  ```


## 初始化项目：

​	打开 cmd，cd 进入项目所在目录（*.csproj 文件所在目录）

```
electronize init
```

​	将会在项目下生成一个  electronnet.manifest.json  文件。

## 启动项目：

### 方案一：

​	打开 cmd，cd 进入项目所在目录 （*.csproj 文件所在目录）

```
electronize start
```

> 注意：如果start失败，并提示"Electron failed to install correctly, please delete node_modules/electron and try installing again"：则删除该项目下 obj/Host/node_modules/electron 目录，重新执行此命令即可；
>
> 或者手工去国内的 npm 源下载electron的包，并解压 dist 到上述目录内；

> 仅首次执行 start 可能会比较慢。

### 方案二：

​	Visual Studio 调试工具栏中，调试项目下拉框选择 "Electron.NET App"，而后直接启动调试即可；

​	如果继续使用 IIS 或 dotnet 宿主启动，项目则将在浏览器中以传统 MVC 形式运行；

## 调试项目：

​	上述两种方式启动项目并不是调试模式，也无法在断点处中断。

​	正确的调试姿势：

1. 按上述方案二启动项目；
2. 菜单栏：调试> 附加到进程，找到上一步中启动的进程并附加，即可正常命中断点并调试；

> 调试菜单栏含有“全部拆离”和“重新附加到进程”菜单项，便于灵活调试；

## 生成项目：

​	打开 cmd，cd 进入项目所在目录 （*.csproj 文件所在目录）

```
electronize build /target win
```

