@echo off

set "CURRENT_DIR=%~dp0"

echo Current directory is: %CURRENT_DIR%

cd KeePass-2.58

KeePass.exe --plgx-create %CURRENT_DIR%KeePKCS11

echo KeePKCS11.plgx was created in %CURRENT_DIR%
pause