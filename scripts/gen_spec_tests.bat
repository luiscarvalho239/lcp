@echo off
setlocal ENABLEEXTENSIONS

set "path=C:\Users\Luis\Documents\angular\lcp\src\app"

:main
cls
echo.
echo Do you want to generate spec component tests? (y/n)
set /p "ask= "
if "%ask%"=="y" goto :gen_spec_tests
if "%ask%"=="n" goto :exit_prog
goto :invalid_option

:gen_spec_tests
cls
echo Generating spec component tests...
start cmd /c "angular-spec-generator '%path%' --type=c --force"
pause
exit

:exit_prog
cls
echo Bye!
pause
exit

:invalid_option
cls
echo The option %ask% you've entered is not valid.
pause
exit

endlocal