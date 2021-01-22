::
::
echo off
echo........................................
echo Generate solution code from added Entity classes
echo........................................
echo off
:PROMPT
SET /P AREYOUSURE=Are you sure you want to delete generated files(Y/[N])?
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END

::Select the VS version
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\TextTransform.exe"
::SET tt="C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\TextTransform.exe"
SET tt="D:\Program Files (x86)\Visual Studio\Common7\IDE\TextTransform.exe"

echo off
echo Delete previously generated cs code files 
 DEL /F "1_t4EntityHelpersGenerate.cs"
 DEL /F "..\AgroExpCore.Domain\Domain\2_t4DomainViewModelsGenerate.cs"	
 DEL /F "..\AgroExpCore.Domain\Mapping\3_t4DomainMappingProfileGenerate.cs"	
 DEL /F "..\AgroExpCore.Domain\Service\4_t4DomainServicesGenerate.cs"	
 DEL /F "..\AgroExpCore.Api\Controllers\5_t4ApiControllerGenerate.cs"	
 DEL /F "..\AgroExpCore.Api\5_t4ApiStartupAdditionsGenerate.cs"	
 DEL /F "..\AgroExpCore.Test\6_t4IntegrationTestGenerate.cs"
echo .
echo Run all T4s...
echo -generate entity helpers
%tt% "1_t4EntityHelpersGenerate.tt" -out "1_t4EntityHelpersGenerate.cs"
echo -generate domain classes
%tt% "..\AgroExpCore.Domain\Domain\2_t4DomainViewModelsGenerate.tt" -out "..\AgroExpCore.Domain\Domain\2_t4DomainViewModelsGenerate.cs"
echo -generate mapper classes
%tt% "..\AgroExpCore.Domain\Mapping\3_t4DomainMappingProfileGenerate.tt" -out "..\AgroExpCore.Domain\Mapping\3_t4DomainMappingProfileGenerate.cs"	
echo -generate services classes
%tt% "..\AgroExpCore.Domain\Service\4_t4DomainServicesGenerate.tt" -out "..\AgroExpCore.Domain\Service\4_t4DomainServicesGenerate.cs"	
echo -generate controller classes
%tt% "..\AgroExpCore.Api\Controllers\5_t4ApiControllerGenerate.tt" -out "..\AgroExpCore.Api\Controllers\5_t4ApiControllerGenerate.cs"
echo -generate extended Startup code
%tt% "..\AgroExpCore.Api\5_t4ApiStartupAdditionsGenerate.tt" -out "..\AgroExpCore.Api\5_t4ApiStartupAdditionsGenerate.cs"
echo -generate Postman json tests
%tt% "..\AgroExpCore.Test\Postman\t4PostmanTestsGenerate.tt" -out "..\AgroExpCore.Test\Postman\RestApiN.Postman_tests_collection.json"		
echo -generate test classes
%tt% "..\AgroExpCore.Test\6_t4IntegrationTestGenerate.tt" -out "..\AgroExpCore.Test\6_t4IntegrationTestGenerate.cs"	
echo -add new db migration
%tt% "t4_AddMigration.tt" -out "t4_AddMigration.cs"
echo T4s completed.
pause
:END