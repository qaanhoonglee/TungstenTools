@echo off
goto check_Permissions
:check_Permissions
echo Administrative permissions required. Detecting permissions...
net session >nul 2>&1
if %errorLevel% == 0 (
echo Success: Administrative permissions confirmed.
%JAVA_HOME%\bin\java -jar ephesoft-generic-installer-1.0-SNAPSHOT.jar %DCMA_HOME% install
) else (
echo Failure:No Administrative permissions  .
)
@ECHO OFF
