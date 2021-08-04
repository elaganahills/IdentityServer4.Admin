;Include Modern UI
  !include "MUI2.nsh"
 
;--------------------------------
;Ã‰nclude MUI_EXTRAPAGES header
 ; !include "MUI_EXTRAPAGES.nsh"
 
;--------------------------------
;General
  ;Name and file
  Name "Hills IdentityServer"

 ; Name
!define PRODUCT_NAME "Hills.IdentityServer"
 ; Version
!define PRODUCT_VERSION "0.0.1"
 ; Installation icon path
;!define INSTALL_ICON "logo.ico"
 ; Uninstall icon path
;!define UNINSTALL_ICON "uninstall_logo.ico"
 ; File path to be packaged

 ; announcer 
!define PRODUCT_PUBLISHER "Hills"
 ; URL
!define PRODUCT_WEB_SITE "http://www.github.com"
 ; Text message in the lower left corner
!define BRANDING_TEXT "Super good software"
 ; Output installation package
!define OUT_FILE "${PRODUCT_NAME}_Setup_v${PRODUCT_VERSION}.exe"

# define name of installer
OutFile "${OUT_FILE}"
 
# define installation directory
InstallDir $PROGRAMFILES\HillsIdentityServer
 
# For removing Start Menu shortcut in Windows 7
RequestExecutionLevel admin
 
!define REGUNINSTKEY "HillsIdentityServer" ;Using a GUID here is not a bad idea
!define REGHKEY HKLM ;Assuming RequestExecutionLevel admin AKA all user/machine install
!define REGPATH_WINUNINST "Software\Microsoft\Windows\CurrentVersion\Uninstall"

  

  
;--------------------------------
;Interface Settings
  !define MUI_ABORTWARNING


!define MUI_WELCOMEFINISHPAGE_BITMAP "img01.png"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "img01.png"

!define MUI_HEADERIMAGE "logo01.bmp"
!define MUI_HEADERIMAGE_RIGHT "logo01.bmp"
!define MUI_HEADERIMAGE_BITMAP "logo01.bmp"
  
 ; !define MUI_FINISHPAGE_RUN
;!define MUI_FINISHPAGE_RUN_TEXT "Start a shortcut"
;!define MUI_FINISHPAGE_RUN_FUNCTION "LaunchApplication"

  
;!define MUI_TEXT_WELCOME_INFO_TITLE "Hills Inspector Module"
;!define MUI_TEXT_WELCOME_INFO_TEXT "Super good software to monitor Hills Product"
  
;Installer Pages
  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "License.txt"
    !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

!insertmacro MUI_LANGUAGE "English"



# start default section
Section

    # set the installation directory as the destination for the following actions
    SetOutPath "$INSTDIR"	
	File "*.bat"
 
    # set the installation directory as the destination for the following actions
    SetOutPath "$INSTDIR\Hills.IdentityServer4.Deployment"	
	File /r "..\deployment\bin\Release\net5.0-windows\publish\*"
	
	# set the installation directory as the destination for the following actions
    SetOutPath "$INSTDIR\Hills.IdentityServer4.Admin"	
	File /r "..\src\Skoruba.IdentityServer4.Admin\bin\Release\net5.0\publish\*"
 
 	# set the installation directory as the destination for the following actions
    SetOutPath "$INSTDIR\Hills.IdentityServer4"	
	File /r "..\src\Skoruba.IdentityServer4.STS.Identity\bin\Release\net5.0\publish\*"
	
    # create the uninstaller
    WriteUninstaller "$INSTDIR\uninstall.exe"
 
	WriteRegStr ${REGHKEY} "${REGPATH_WINUNINST}\${REGUNINSTKEY}" "DisplayName" "Hills Identity Server"
	WriteRegStr ${REGHKEY} "${REGPATH_WINUNINST}\${REGUNINSTKEY}" "UninstallString" '"$INSTDIR\uninstall.exe"'

    # create a shortcut named "new shortcut" in the start menu programs directory
	SetOutPath "$INSTDIR"
    CreateShortcut "$SMPROGRAMS\HillsIdentityServer.lnk" "$INSTDIR\open.bat"
	
	SetOutPath "$INSTDIR\Hills.IdentityServer4.Deployment"
	#Exec "$INSTDIR\install.bat"
	Exec "Hills.IdentityServer4.Deployment.exe"

SectionEnd

;Function LaunchApplication
;    Exec '"$INSTDIR\Hills.IdentityServer4.Deployment\Hills.IdentityServer4.Deployment.exe"'
;FunctionEnd
 
# uninstaller section start
Section "Uninstall"
 
	SetOutPath "$INSTDIR\Hills.IdentityServer4.Deployment"
	ExecWait "Hills.IdentityServer4.Deployment.exe --uninstall"
	#Exec "$INSTDIR\uninstall.bat"
 
	Sleep 2000
 
    # first, delete the uninstaller
    Delete "$INSTDIR\uninstall.exe"
 
    # second, remove the link from the start menu
    Delete "$SMPROGRAMS\HillsIdentityServer.lnk"
 
	DeleteRegKey ${REGHKEY} "${REGPATH_WINUNINST}\${REGUNINSTKEY}"
 
    RMDir /r "$INSTDIR"
# uninstaller section end
SectionEnd



