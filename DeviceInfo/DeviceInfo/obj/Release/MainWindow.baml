   M S B A M L   `   `   `  ���� E  ADeviceInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DeviceInfo
DeviceInfo      DeviceInfo.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:DeviceInfo       � Title$  
MainWindow��$	��450��$	��800��.���� $��Visible=�
��� ��.����  �� Orientation$ Vertical=�$��10q�
�������.+��� $ 
Horizontal=�
�������.+��� $��5q�.+��� -   $��	isUpdates��.��	Updates�� -   $��isAntivirus��.��	Antivirus�� $��5q�.+��� -   $��isLogicalDisk��.��Logical Disks�� -   $��isPhysicalMemory��.��Physical Memory�� $��5q�.+��� -   $��isProcessor��.��	Processor�� -   $��
isFireWall��.��
FireWall�� $��5q�.+��� -   $��isGeneralInfo��.��General PC Info�� -   $��isJson��.��JSON Format�� -	   $��showInfo��$��5q�$��5q�
�������.��	Show Info�� -
   $��antivirusText��$��5 10 5 3q�$
��Bold"�	Antivirus�� -   $��antivirusList�� �� View �� P��� $
��Name�� �� DisplayMemberBinding �� *Name+�� $��Antivirus State�� �� *State+�� -   $��firewallText��$��5 10 5 3q�$
��Bold"�
FireWall�� -   $��firewallInfo���� -   $��updatesText��$��5 10 5 3q�$
��Bold"�	Updates�� -   $��updatesNumberText��$��5 0 5 3q�Updates not found�� -   $��updatesList���� -   $��processorText��$��5 10 5 3q�$
��Bold"�	Processor�� -   $��processorsList�� �� P��� $
��Name�� �� *Name+�� $��Number Of Cores�� �� *NumberOfCores+�� $"��Number Of Logical Processors�� �� *NumberOfLogicalProcessors+�� $��Processor Type�� �� *ProcessorType+�� $��Max Clock Speed�� �� *MaxClockSpeed+�� -   $��logicalDiskText��$��5 10 5 3q�$
��Bold"�Logical Disk�� -   $��logicalDisksList�� �� P��� $
��Name�� �� *Name+�� $��
Drive Type�� �� *	DriveType+�� $��File System�� �� *
FileSystem+�� $
��Size�� �� *Size+�� $��
Free Space�� �� *	FreeSpace+�� -   $��physicalMemoryText��$��5 10 5 3q�$
��Bold"�Physical Memory�� -   $��physicalMemoryItem������ *PhysicalMemoryItem+���� .R��  � ColumnDefinitions �� $	��200 ���  � RowDefinitions �� �� �� �� �� �� �� �� �� �� .+��� $
��Name��$��0��$��0��$
��Bold"��� $��1��$��0������ *Name+�� $��Capacity��$��0��$��1��$
��Bold"��� $��1��$��1������ *
Capacity+�� $��Configured Clock Speed��$��0��$��2��$
��Bold"��� $��1��$��2������ *ConfiguredClockSpeed+�� $��
Data Width��$��0��$��3��$
��Bold"��� $��1��$��3������ *	DataWidth+�� $��Speed��$��0��$��4��$
��Bold"��� $��1��$��4������ *Speed+�� $��Serial Number��$��0��$��5��$
��Bold"��� $��1��$��5������ *SerialNumber+�� $��Memory Type��$��0��$��6��$
��Bold"��� $��1��$��6������ *SMBIOSMemoryType+�� $��Device Locator��$��0��$��7��$
��Bold"��� $��1��$��7������ *DeviceLocator+�� $��Manufacturer��$��0��$��8��$
��Bold"��� $��1��$��8������ *Manufacturer+�� $	��Tag��$��0��$��9��$
��Bold"��� $��1��$��9������ *Tag+�� -   $��hardwareText��$��5 10 5 3q�$
��Bold"�General Info� -   $��hardwareInfo�� �� $	��200 ���  �� �� �� �� .+��� $��Machine Name��$��0��$��0��$
��Bold"��� -   $��MachineNameText��$��1��$��0���� $��Username��$��0��$��1��$
��Bold"��� -   $��UserNameText��$��1��$��1���� $��OS Bit Version��$��0��$��2��$
��Bold"��� -   $��	BitOSText��$��1��$��2���� $��
OS Version��$��0��$��3��$
��Bold"��� -   $��OSVersionText��$��1��$��3���� -   $��jsonInfo�� �� 
IsReadOnly . $y�	Collapsed=�