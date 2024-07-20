@echo off
setlocal enabledelayedexpansion


adb version >nul 2>&1
if errorlevel 1(
	echo 请先安装adb
	exit /b 1
)

for /f "tokens=1" %%i in ('adb devices ^| findstr /v "List"') do (
	set device_id=%%i
)

if "%device_id%=="" (
	echo no devices
	exit /b 1
)

set target_path=/log/

for /f "tokens=*" %%i in ('adb -s %device_id% shell ls %target_path% do (
	echo %%i
)

endlocal
pause