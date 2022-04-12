@echo off
echo Administrative permissions required. Detecting permissions...
    
net session >nul 2>&1
if %errorLevel% == 0 (
	  SC create ctwFiveMServer start=delayed-auto binpath="C:\FiveMServerAsAService\CloudTheWolf.FiveM.Service.exe" displayname="My Cool FiveM Server"
      SC failure ctwFiveMServer reset= 86400 actions= restart/1000/restart/1000     
      NET START ctwFiveMServer
      pause > nul      
      exit
    ) else (
      echo Failure: Current permissions inadequate.
      pause > nul
      exit
    )    