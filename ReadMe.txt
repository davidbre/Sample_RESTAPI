
COMPILE
=======
From VS Developer Command Prompt Run:
msbuild PMSummary.csproj

RUN
=======
Run PMsummary\bin\debug\pmsummary.exe as Administrator. 


TEST
=======
Open http://localhost:8080/summary in Web Browser.


CODE REVIEW
============
MainProcess() is found in PMsummary\interfaces\MockAPISummarySvc.cs
