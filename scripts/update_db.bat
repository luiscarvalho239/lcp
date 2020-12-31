@echo off
setlocal ENABLEEXTENSIONS

chcp 65001
goto :main

:main
cls
echo Do you want to update your database? (y/n)
set /p "op= "
if "%op%"=="y" goto :do_operation
if "%op%"=="n" goto :exit_prog
goto :exit_prog

:do_operation
call :update_db
exit /b %ERRORLEVEL%

:update_db
cls
cd "C:\Users\%username%\Documents\angular\lcp\api\real\MyApiWeb"

dotnet tool install --global dotnet-ef
dotnet ef database drop
dotnet ef migrations remove --force
dotnet ef migrations add Initial
dotnet ef database update

if %ERRORLEVEL%==0 (
    echo.
    echo Successfully updated your db!
)

pause
exit

:exit_prog
cls
echo Bye!
pause
exit

endlocal