@echo off
SET SVC_NAME=MDriveSyncService
SET SVC_DISPLAY_NAME=MDrive Sync Client API Service
SET SVC_PATH=E:\gits\MDriveSync\src\MDriveSync.Client.API\bin\Release\net8.0\publish\MDriveSync.Client.API.exe

:menu
cls
echo.
echo ��ѡ�������
echo 1. ��װ��������
echo 2. ж�ط���
echo 3. �˳�
echo.
set /p choice=��ѡ��������:

if "%choice%"=="1" goto install
if "%choice%"=="2" goto uninstall
if "%choice%"=="3" goto end
goto menu

:install
echo ���ڰ�װ����...
sc create %SVC_NAME% binPath= "%SVC_PATH%" DisplayName= "%SVC_DISPLAY_NAME%" start= auto
echo ����װ�ɹ���������������...
net start %SVC_NAME%
echo ������������
goto end

:uninstall
echo ����ж�ط���...
sc delete %SVC_NAME%
echo ������ж�ء�
goto end

:end
echo.
echo ������ɣ���������˳���
pause >nul
