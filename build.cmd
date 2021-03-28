@echo off
setlocal

pushd %~dp0
set ROOT_PATH=%CD%

set EXIT_CODE=1
if NOT DEFINED VSCMD_ARG_HOST_ARCH set ERR_MSG=%0 must be run from a VS command prompt.& goto :Quit

set VCPKG_FILE=%LOCALAPPDATA%\vcpkg\vcpkg.path.txt
if NOT EXIST "%VCPKG_FILE%" set ERR_MSG=Could not find vcpkg.& goto :Quit
set /p VCPKG_PATH=<%VCPKG_FILE%

set CLEAN=0
set NO_CPP=0
set NO_CS=0
set NO_RS=0
set NO_TEST=0
set VERBOSE=0
set BUILD_TYPE=Debug
set ERR_MSG=Usage: %0 [--clean] [--no-cpp] [--no-cs] [--no-rs] [--no-test] [--verbose] [build_type]

:NextArg
set NEXT_ARG=%~1
shift
if NOT DEFINED NEXT_ARG goto :EndArg
if /i "%NEXT_ARG%" == "--clean" set CLEAN=1& goto :NextArg
if /i "%NEXT_ARG%" == "--no-cpp" set NO_CPP=1& goto :NextArg
if /i "%NEXT_ARG%" == "--no-cs" set NO_CS=1& goto :NextArg
if /i "%NEXT_ARG%" == "--no-rs" set NO_RS=1& goto :NextArg
if /i "%NEXT_ARG%" == "--no-test" set NO_TEST=1& goto :NextArg
if /i "%NEXT_ARG%" == "--verbose" set VERBOSE=1& goto :NextArg
if "%NEXT_ARG:~0,1%" == "-" goto :Quit
set BUILD_TYPE=%NEXT_ARG%
if /i "%BUILD_TYPE%" == "Debug" goto :NextArg
if /i "%BUILD_TYPE%" == "Release" goto :NextArg
goto :Quit
:EndArg

set BUILD_CONFIG=%VSCMD_ARG_HOST_ARCH%-%BUILD_TYPE%
echo == Build config '%BUILD_CONFIG%'

set BUILD_TYPE_CPP=%BUILD_TYPE%
if /i "%BUILD_TYPE_CPP%" == "Release" set BUILD_TYPE_CPP=RelWithDebInfo

set OUTPUT_PATH=%ROOT_PATH%\out
set BUILD_PATH=%OUTPUT_PATH%\build\%BUILD_CONFIG%

if "%CLEAN%" == "0" goto :MakeCpp
echo == Remove %BUILD_PATH%
if EXIST "%BUILD_PATH%" rd /s /q "%BUILD_PATH%"

:MakeCpp
if "%NO_CPP%" == "1" goto :MakeCS

if NOT EXIST "%BUILD_PATH%" md "%BUILD_PATH%"
cd "%BUILD_PATH%"

set CMAKE_ARGS=^
  -G Ninja ^
  -DCMAKE_BUILD_TYPE=%BUILD_TYPE_CPP% ^
  -DCMAKE_CXX_COMPILER:FILEPATH=cl.exe ^
  -DCMAKE_INSTALL_PREFIX:PATH="%OUTPUT_PATH%\install\%BUILD_CONFIG%" ^
  -DCMAKE_MAKE_PROGRAM=ninja.exe ^
  -DCMAKE_TOOLCHAIN_FILE="%VCPKG_PATH%/scripts/buildsystems/vcpkg.cmake" ^
  "%ROOT_PATH%"

if "%VERBOSE%" == "1" set CMAKE_ARGS=%CMAKE_ARGS% --log-level=VERBOSE

echo == cmake.exe %CMAKE_ARGS%
cmake.exe %CMAKE_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=cmake.exe failed.
if NOT "%EXIT_CODE%" == "0" goto :Quit

set NINJA_ARGS=

if "%VERBOSE%" == "1" set NINJA_ARGS=%NINJA_ARGS% -v

echo == ninja.exe %NINJA_ARGS%
ninja.exe %NINJA_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=ninja.exe failed.
if NOT "%EXIT_CODE%" == "0" goto :Quit

if "%NO_TEST%" == "1" goto :MakeCS

set CTEST_ARGS=

if "%VERBOSE%" == "1" set CTEST_ARGS=%CTEST_ARGS% -V

echo == ctest.exe %CTEST_ARGS%
ctest.exe %CTEST_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=ctest.exe failed.
if NOT "%EXIT_CODE%" == "0" goto :Quit

:MakeCS
if "%NO_CS%" == "1" goto :MakeRS

cd "%ROOT_PATH%"

set DOTNET_BUILD_ARGS=build -c %BUILD_TYPE%

if "%VERBOSE%" == "1" set DOTNET_BUILD_ARGS=%DOTNET_BUILD_ARGS% -v d

echo == dotnet.exe %DOTNET_BUILD_ARGS%
dotnet.exe %DOTNET_BUILD_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=dotnet build failed.
if NOT "%EXIT_CODE%" == "0" goto :Quit

if "%NO_TEST%" == "1" goto :MakeRS

set DOTNET_TEST_ARGS=test -c %BUILD_TYPE%

if "%VERBOSE%" == "1" set DOTNET_TEST_ARGS=%DOTNET_TEST_ARGS% -v d

echo == dotnet.exe %DOTNET_TEST_ARGS%
dotnet.exe %DOTNET_TEST_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=dotnet test failed.

:MakeRS
if "%NO_RS%" == "1" goto :Quit

cd "%ROOT_PATH%"

set BUILD_TYPE_RS=
if /i "%BUILD_TYPE%" == "Release" set BUILD_TYPE_RS=--release

set CARGO_BUILD_ARGS=build %BUILD_TYPE_RS%

if "%VERBOSE%" == "1" set CARGO_BUILD_ARGS=%CARGO_BUILD_ARGS% -v

echo == cargo.exe %CARGO_BUILD_ARGS%
cargo.exe %CARGO_BUILD_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=cargo build failed.
if NOT "%EXIT_CODE%" == "0" goto :Quit

if "%NO_TEST%" == "1" goto :Quit

set CARGO_TEST_ARGS=test %BUILD_TYPE_RS%

if "%VERBOSE%" == "1" set CARGO_TEST_ARGS=%CARGO_TEST_ARGS% -v

echo == cargo.exe %CARGO_TEST_ARGS%
cargo.exe %CARGO_TEST_ARGS%
set EXIT_CODE=%ERRORLEVEL%
set ERR_MSG=cargo test failed.

:Quit
popd
if NOT "%EXIT_CODE%" == "0" echo %ERR_MSG%
exit /b %EXIT_CODE%
