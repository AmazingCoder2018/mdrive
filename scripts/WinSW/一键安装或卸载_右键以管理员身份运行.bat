@echo off
SET WIN_SW_PATH=%~dp0WinSW-x64.exe
SET CONFIG_PATH=%~dp0WinSW-x64.xml

:menu
cls
echo.
echo ��ѡ�������
echo 1. ��װ��������
echo 2. ж�ط���
echo 3. ��������
echo 4. ֹͣ����
echo 5. �˳�
echo.
set /p choice=��ѡ��������:

if "%choice%"=="1" goto install
if "%choice%"=="2" goto uninstall
if "%choice%"=="3" goto start
if "%choice%"=="4" goto stop
if "%choice%"=="5" goto end
goto menu

:install
echo ���ڰ�װ����...
"%WIN_SW_PATH%" install "%CONFIG_PATH%"
if %ERRORLEVEL% neq 0 (
    echo �޷���װ�����������Ƿ�ӵ���㹻��Ȩ�ޡ�
    goto end
)
echo ����װ�ɹ���������������...
"%WIN_SW_PATH%" start "%CONFIG_PATH%"
if %ERRORLEVEL% neq 0 (
    echo �޷����������������Ƿ�ӵ���㹻��Ȩ�ޡ�
    goto end
)
echo ������������
goto end

:uninstall
echo ����ֹͣ����...
"%WIN_SW_PATH%" stop "%CONFIG_PATH%"
if %ERRORLEVEL% neq 0 (
    echo �޷�ֹͣ�����������Ƿ�ӵ���㹻��Ȩ�ޡ�
    goto end
)
echo ����ж�ط���...
"%WIN_SW_PATH%" uninstall "%CONFIG_PATH%"
if %ERRORLEVEL% neq 0 (
    echo �޷�ж�ط����������Ƿ�ӵ���㹻��Ȩ�ޡ�
    goto end
)
echo ������ж�ء�
goto end

:start
echo ������������...
"%WIN_SW_PATH%" start "%CONFIG_PATH%"
goto end

:stop
echo ����ֹͣ����...
"%WIN_SW_PATH%" stop "%CONFIG_PATH%"
goto end

:end
echo.
echo ������ɣ���������˳���
pause >nul

