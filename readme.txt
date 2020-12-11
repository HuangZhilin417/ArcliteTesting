To run the tests in command line:

First open command line as admin
then cd to wherever the project folder you have downloaded
for me it is 
cd C:\Users\Josh\source\repos\ArcliteTesting

then we need to cd to the nunit3-console.exe
which we need to go in to packages -> NUnit.ConsoleRunner.3.11.1 -> tools
if you are in the ArcliteTesting directory then you can just copy the code below:


cd packages\NUnit.ConsoleRunner.3.11.1\tools


then we need to run the nunit3-console.exe


which we can just do:
nunit3-console.exe [VS test Project file location]**


so for me my command line looks like this 
C:\Users\Josh\source\repos\ArcliteTesting\packages\NUnit.ConsoleRunner.3.11.1\tools> nunit3-console.exe C:\Users\Josh\source\repos\ArcliteTesting\ArcliteTesting.sln

then press the enter key
and the test should run from there
after the test is complete, it should save the test results in the TestResult.xml file


**The VS test project file should be called ArcliteTesting.sln
Don't move the files around just leave it as is, because moving files to other locations might cause the the nunit3-console.exe to fail



Folders:
ArcliteInputs - Contain classes that is responsible for initialzing and placing specific inputs for specific ArcLite Web Elements during a test run
ArcliteInterfaces - Contains all interfaces
ArcliteWebElementActionsVisitor - A visitor that performs automatic testing actions based on certain ArcLite Web Elements, such as input a string for a field, select an option for a dropdown, and etc.
ArcliteWebElements - ArcLite Web Element, such as input fields, dropdown selections, calenders, buttons, and etc.
ArcliteWebPages - Contains web pages in ArcLite, such as login page, Order Tracking & Management, Scheduler, and etc. 
BaseClass - The base setting of running the selenium tests, such as url, timeout time, loading pereference and etc. 
Testing - the main testing folder that contains all of the test





