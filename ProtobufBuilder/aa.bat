@echo off
set SOURCE_FOLDER=.\protos
set CS_COMPILER_PATH=.\tools\protoc-21.9-win64\bin\protoc.exe
set CS_TARGET_PATH=.\net

set JAVA_COMPILER_PATH=.\tools\protoc-21.9-win64\bin\protoc.exe
set JAVA_TARGET_PATH=.\java\
del %CS_TARGET_PATH%\*.* /f /s /q
del %JAVA_TARGET_PATH%\*.* /f /s /q

for /f "delims=" %%i in ('dir /b "%SOURCE_FOLDER%\*.proto"') do (
	echo %CS_COMPILER_PATH% --csharp_out=%CS_TARGET_PATH% --csharp_opt=file_extension=.cs %SOURCE_FOLDER%\%%i
    %CS_COMPILER_PATH% --csharp_out=%CS_TARGET_PATH% --csharp_opt=file_extension=.cs %SOURCE_FOLDER%\%%i
	
)



pause