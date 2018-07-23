;#DropDB COGOP_ManagerEasyTest

#Application COGOP_Manager.Win
#Application COGOP_Manager.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef COGOP_Manager.Win

*Action About...
 
*Action OK

#EndIf

#IfDef COGOP_Manager.Web
*Action Navigation(My Details)
#EndIf
