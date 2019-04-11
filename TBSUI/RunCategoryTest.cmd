 @echo off

if "%1"=="" goto ErrNoParam
if "%1"=="/?" goto Usage
if "%1"=="-?" goto Usage
if "%1"=="--help" goto Usage
goto Start

:Usage
@echo usage: RunCategoryTest.cmd Tag
@echo Runs an automated regression test associated with that tag
goto End


:Start
set Datetime=%date:~-4,4%%date:~-7,2%%date:~-10,2%%time:~-11,2%%time:~-8,2%%time:~-5,2%
set PROJECTDIR=%CD%
set SOLUTIONDIR=%CD%\TBSUITEST
set TESTFILE=%PROJECTDIR%\TBSUI\bin\Debug\TBSUI.dll
set MSTEST=%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\IDE\MSTEST.exe
set TrxerConsole=%PROJECTDIR%\TrxerConsole.exe
set RESULTSDIR=%PROJECTDIR%\TestResults
set Tag=%1

@echo Tag         : %Tag%
@echo TESTFILE    : %TESTFILE%
@echo RESULTSDIR  : %RESULTSDIR%
@echo MSTest      : %MSTEST%
if not exist "%TESTFILE%" goto ErrNoTestFile
if not exist "%MSTEST%" goto ErrNoMSTest


:: Create the results directory if it does not already exist
if exist "%RESULTSDIR%" goto Clean
@echo Creating results folder "%RESULTSDIR%"
mkdir "%RESULTSDIR%"
goto RunTest

:Clean
if not exist "%RESULTSDIR%\TestResult.trx" goto RunTest
@echo Cleaning test results "%RESULTSDIR%\TestResult.trx"
del "%RESULTSDIR%\TestResult.trx"

:RunTest
@echo Running MSTest...
cd "%SOLUTIONDIR%"
"%MSTEST%" /nologo /testcontainer:"%TESTFILE%" /category:"%Tag%" /testsettings:"%PROJECTDIR%\Local.testsettings" /resultsfile:"%RESULTSDIR%\%Datetime%_TestResult.trx" /detail:stdout

@echo Running TrxerConsole...
@echo with project "%ProjectDir%\%VSProjectName%.csproj"
"%TrxerConsole%" "%ResultsDir%\%Datetime%_TestResult.trx" "%ProjectDir%\TestResult.xsl" -o "%ResultsDir%\%Datetime%_TestResult.trx.html"
cd "%PROJECTDIR%"
if errorlevel 1 goto TrxerConsole

goto END

:ErrNoMSTest
@echo Error: MsTest was not found. %MSTEST%
exit /b 1

:TrxerConsole
@echo Error: msxsl was not found. %TrxerConsole%
exit /b 1
goto END

:ErrNoParam
@echo Error: Expected an ordered test file as a parameter. Try help /?
exit /b 1

:ErrNoTestFile
@echo Error: The test file was not found %TESTFILE%
exit /b 1


:END
set MSTEST=
