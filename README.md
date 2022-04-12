# FiveM As A Service
This project is a Wrapper Service for Cfx.re 

# <img src="https://cdnjs.cloudflare.com/ajax/libs/emojione/2.2.6/assets/png/1f40c.png" width="32" height="32"> Cfx.re (FiveM/RedM) 

This repository contains the code that has been tested with the following servers:

* [FiveM](https://fivem.net/)

## Getting started
### For this guide we will assume the FiveM Server is installed in C:\FiveM\Server.
To Get started, copy the latest build to your server. and extract to your desired location (For this we will use C:\FiveM\Wrapper)

Next open appsettings.json and change the following 

 - exePath: Set the the path where FXServer.exe can be found
 - exeName: the name for FXServer.exe (If your the kind of person who renames stuff)
 - args: Add objects for any extra runtime arguments you need, with the Key being the first part of the argumannt and the value being the second. Eg to add the "+exec" argument you would add `"+exec": "server.cfg"`

Next open install.bat with Notepad and change find/replace the following:

  - C:\FiveM\Wrapper: Change to the path of the wrapper service. 
  - My Cool FiveM Server: Change this what ever you want the service name to be (Eg Pog RP)

Now run install.bat as Administrator and it will install the service.

Now the service will show in `Services.msc` with the name you selected.

## Uninstall

To uninstall the service, just run an elevated terminal (Command Prompt)  and run the following command

`sc delete ctwFiveMServer`

You will then see the following message to confirm it has been removed:

> [SC] DeleteService SUCCESS
