INTRODUCTION
---------------------------

This is a console application based on the "Tame of Thrones" challenge provided in geektrust.in. Please go through this file to understand how to get the code working, and how to unit test it.



PLATFORM
---------------------------

This application is developed as a .NET Core console application, with C# as the programming language. The IDE used is Visual Studio 2019.



PROJECTS
---------------------------

The application consists of two projects; TameofThrones and TameofThronesUnitTests.

1. TameofThrones - This is the main project. It accepts the input file path as a command-line argument, and prints the output to the console.

2. TameofThronesUnitTests - This is the project which performs the unit tests.



DEPENDENCIES
---------------------------

TameofThrones is added as a reference project in TameofThronesUniTests .



HOW TO GET THE CODE WORKING
---------------------------

1. Open cmd and set the path to the solution's directory.
2. Type the following command and press enter to create a build of the application: dotnet build -o geektrust
3. After build is successfully created, type the following command and press enter: dotnet geektrust/geektrust.dll <input file's full path>
4. The output will be generated in the next line.



INPUT
---------------------------

The input is the full directory of a text file, where each line contains a kingdom name and the encrypted message to that kingdom as space-separated strings.



OUTPUT
---------------------------

If the conquest is successfull, the output is a single line consisting of the conquering kingdom and its allies as space-separated strings. Else, the output will be "NONE".



SAMPLE I/O
---------------------------

Case 1:

Input file content:

LAND FDIXXSOKKOFBBMU
ICE MOMAMVTMTMHTM
WATER SUMMER IS COMING
AIR OWLAOWLBOWLC
FIRE AJXGAMUTA

Output:

SPACE LAND ICE FIRE


Case 2:

Input file content:

AIR OWLAOWLBOWLC
LAND OFBBMUFDICCSO
ICE VTBTBHTBBBOBAB
WATER SUMMER IS COMING

Ouput:

NONE



EXECUTING UNIT TESTS
---------------------------

1. Open TameofThrones.sln in Visual Studio.
2. Click on 'Test' in the navigation bar.
3. Now, click on 'Run all Tests' in the dropdown menu that opened.
4. The Test Explorer will be opened, and the tests will start executing.
5. If all tests are executed successfully, green tick marks will be visible beside them. 
6. If a test fails, a red cross will be visible beside it.
7. To see the contents of a test, click on the corresponding name in the Test Explorer.
8. A file name UnitTests.cs will be opened. This is the unit test file. All individual tests are visible here. 