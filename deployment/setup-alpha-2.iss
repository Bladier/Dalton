; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Pawnshop"
#define MyAppVersion "a1.0.13.3"
#define MyAppPublisher "Perfecto Group of Companies"
#define MyAppExeName "pawnshop.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4B390003-3D69-47C6-BE18-492FCFB40184}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\cdt-S0ft\Pawnshop
DefaultGroupName=cdt-S0ft\Pawnshop
OutputDir=D:\cadeath\Documents\DevInstaller\Pawnshop
OutputBaseFilename=pawn-a1.0.13.3
SetupIconFile=D:\cadeath\Documents\GitHub\Dalton\RAW\pawnshop-installer.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\cadeath\Documents\GitHub\Dalton\Pawnshop\Pawnshop\bin\Debug\pawnshop.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\cadeath\Documents\GitHub\Dalton\Pawnshop\Pawnshop\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

