# Unity 通用游戏框架
适用于中小型项目demo的轻量级 Unity 框架

## 项目介绍
基于模块化设计的 Unity 通用开发框架，包含企业级常用核心模块，可快速搭建 2D/3D 游戏 Demo。

## 项目结构
```text
Unity-Game-Framework/
├── Assets/
│   ├── GameFramework/              # 框架核心代码（求职亮点）
│   │   ├── Core/                   # 核心基类
│   │   │   ├── Singleton.cs        # 单例基类（普通/Mono）
│   │   ├── Manager/                # 全局管理器
│   │   │   ├── SceneManager.cs     # 场景管理
│   │   ├── Event/                  # 事件系统
│   │   │   ├── EventManager.cs     # 全局事件中心
│   │   ├── UI/                     # UI框架
│   │   │   ├── UIManager.cs        # UI管理/缓存/加载
│   │   ├── Audio/                  # 音频管理
│   │   │   ├── AudioManager.cs     # BGM/音效播放
│   │   ├── Resource/               # 资源加载（扩展预留）
│   │   ├── Config/                 # 配置表系统
│   │   ├── Utils/                  # 通用工具类
│   │   │   ├── ObjectPool.cs       # 对象池
|   |   |   ├── DebugTool/
│   │   │   |   ├── LogTool.cs      # 分级日志工具
│   │   │   |   ├── DebugManager.cs # 全局调试工具
│   │   ├── FSM/                    # 有限状态机
│   │   │   ├── StateBase.cs        # 状态基类
│   │   │   ├── FsmBase.cs          # 状态机基类
│   │   │   ├── FsmManager.cs       # 全局状态机管理器
│   │   └── GameRoot.cs             # 框架唯一入口
│   ├── Game/                       # 游戏业务逻辑
│   │   ├── Test/                   # 框架功能测试脚本
│   ├── Resources/                  # 游戏资源目录
│   │   ├── UI/                     # UI预制体
│   │   ├── Audio/                  # 音频文件
│   │   │   ├── BGM/
│   │   │   └── Sound/
│   │   ├── Config/                 # 生成的Json配置表
│   │   └── Effect/                 # 特效/对象池预制体
│   ├── Scenes/                     # 游戏场景
│   │   └── Main.unity              # 启动场景
│   └── Plugins/                    # 第三方库
├── Packages/                       # Unity包管理配置
├── ProjectSettings/                # 项目设置
├── .gitignore                      # Git忽略文件
└── README.md                       # 项目说明文档
```

## 框架模块
✅ 单例基类（普通单例 / Mono单例）  
✅ 事件中心系统（解耦模块通信）  
✅ UI 管理系统（打开/关闭/缓存）  
✅ 音频管理系统（BGM / 音效）  
✅ 场景管理系统（同步/异步加载）  
✅ 对象池系统（减少GC，优化性能）  
✅ FSM 有限状态机（角色/AI逻辑）  
✅ 日志工具 + 调试工具（编辑器显示，打包关闭）

## 适用场景
- 快速开发游戏 Demo  
- 独立游戏基础架构  
- 学习 Unity 框架设计

## 使用方式
1. 克隆项目到本地  
2. 使用 Unity 2021 LTS 及以上版本打开  
3. 打开 Scenes/GameScene 运行测试  
4. 框架入口：GameRoot.cs

## 技术亮点
- 低耦合、高可扩展  
- 企业规范代码结构  
- 全模块注释清晰  
