@echo off
setlocal ENABLEEXTENSIONS
chcp 65001
set "pathproject=C:\Users\Luis\Documents\angular\lcp"

:main
cls
echo.
echo LC Projeto
echo Criado por Luís Carvalho (luiscarvalho239@gmail.com)
echo Versão 1.0
echo Ano: 2020
echo.
echo.
echo 1 - LCP com Swagger
echo 2 - Só o Swagger
echo 3 - Testes unitários
echo 4 - Testes unitários com a cobertura do código
echo 5 - Gerar os novos dados para a base de dados
echo 6 - Atualizar o projeto
echo.
echo Escolha uma das opções: 
set /p mode=""
if "%mode%"=="1" goto :start_lcp_swagger
if "%mode%"=="2" goto :start_only_swagger
if "%mode%"=="3" goto :start_unit_tests
if "%mode%"=="4" goto :start_ut_code_coverage
if "%mode%"=="5" goto :start_gen_db
if "%mode%"=="6" goto :update_project
if "%mode%"=="" goto :opcao_invalida
goto :opcao_invalida
pause
exit

:start_lcp_swagger
cls
echo O projeto está sendo executado com o Swagger...
cd %pathproject% && npm run start_lcp_swagger
exit

:start_only_swagger
cls
echo Está ser executado o servidor real (swagger) do api...
start "" "https://localhost:5001/swagger"
cd %pathproject% && npm run real_api
exit

:start_unit_tests
cls
echo Está ser executado os testes unitários do projeto LCP...
cd %pathproject% && start cmd /c "npm run real_api" && start cmd /c "npm run test"
exit

:start_ut_code_coverage
cls
echo Está ser executado os testes unitários com a cobertura do código do projeto LCP...
start chrome "file:///C:\Users\Luis\Documents\angular\lcp\coverage\lcp\index.html"
cd %pathproject% && start cmd /c "npm run real_api" && start cmd /c "npm run test_code_coverage"
exit

:start_gen_db
cls
set "pth_db_script=C:\Users\Luis\Documents\angular\lcp\scripts\update_db.bat"
if exist "%pth_db_script%" (
    echo Está ser excutado o ficheiro de gerar os novos dados para base de dados...
    %pth_db_script%
) else (
    echo O ficheiro %pth_db_script% não existe!
)
exit

:update_project
cls
echo Queres atualizar este projeto? (y/n)
set /p mode=""
if "%mode%"=="y" (
  if exist "%pathproject%" (
    echo.
    echo Está atualizar o projeto, aguarde...    

    cd %pathproject% 

    if exist "%pathproject%\node_modules" (
      rmdir /s /q "%pathproject%\node_modules"
    )

    if exist "%pathproject%\package-lock.json" (
      del /f "%pathproject%\package-lock.json"
    )

    @REM npm uninstall -g @angular-cli
    @REM npm cache clean --force
    @REM npm cache verify
    @REM npm install -g @angular/cli@latest

    npm cache clean --force
    npm cache verify
    npm uninstall typescript
    npm uninstall --save-dev angular-cli
    npm install --save-dev @angular/cli@latest
    npm install -g npx
    npx npm-check-updates -u
    npm install --save-dev typescript
    npm install

    if %errorlevel% EQU 1 (
       echo Ocorreu o erro ao atualizar o projeto, tente novamente mais tarde!
    ) else (
       echo O projeto já está atualizado com sucesso!
    )

    pause
    exit
  ) else (
    echo O caminho do projeto %pathproject% não existe!!!
  )
)
if "%mode%"=="n" goto :exit_prog
if "%mode%"=="" goto :opcao_invalida
goto :opcao_invalida
exit

:opcao_invalida
cls
echo A opção %mode% não existe, por favor tente novamente.
pause
exit

:exit_prog
cls
echo Adeus!
pause
exit

endlocal