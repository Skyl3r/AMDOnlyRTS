# AMD only RTS
This is a highly moddable, cross platform and open source RTS game (That only runs on AMD).


## Index
- [Technology](#technology)
- [Build Guide](#build-guide)
  - [Linux](#linux)
  - [Windows](#windows)
- [Get involved!](#wanna-get-involved)
- [Credits](#credits)


## Technology
- .Net Core
- Lua
- SignalR
- Love2d


## Build Guide

### Linux

1. Install dotnet-sdk-3.0 via [Microsoft's repository](https://dotnet.microsoft.com/download/linux-package-manager/rhel7/sdk-3.0.100)
1. (Optional) Install [Visual Studio Code](https://code.visualstudio.com/download)
1. Clone repository: `git clone https://github.com/Skyl3r/AMDOnlyRTS`
1. Open the root folder in Visual Studio Code
1. Build from terminal to get all prerequisites: `dotnet build ./Core/AMDOnlyRts.Core.csproj`


### Windows

1. Install .NET Core SDK 3.0 from [Microsoft's website](https://dotnet.microsoft.com/download/dotnet-core/3.0#sdk-3.0.100)
1. (Optional) Install [Visual Studio Code](https://code.visualstudio.com/docs/setup/windows)
1. Clone this repository using `git clone https://github.com/Skyl3r/AMDOnlyRTS` or  your choice of git client.
   - If you would like to install git, an easy way to do so is via the [Chocolatey package manager](https://chocolatey.org/install). With Chocolatey installed, simply run `choco install git`
1. Open the root folder in Visual Studio Code
1. Build from commandline to get all prerequisites: `dotnet build Core/AmdOnlyRts.Core.csproj`



***


### Wanna get involved?
Contact us at our Freenode IRC channel: **#AMDOnlyRTS**

### Credits
Free art assets from user [Hyptosis](https://opengameart.org/users/hyptosis) at Open Game Art
