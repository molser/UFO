   M S B A M L   `   `   `  ����?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=nullclr-namespace:UFOUFO  5   	   D @MolserLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ3clr-namespace:MolserLib.Controls;assembly=MolserLibMolserLib.Controls 5   	   /clr-namespace:UFO.ConvertersUFO.Converters  5   	       UFO.PhotoFromDbView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:UFO     5   	   Fmolser3clr-namespace:MolserLib.Controls;assembly=MolserLib     5   	   -convclr-namespace:UFO.Converters     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	   	     � Title$C  =Импорт фото из базы данных Каскад��5   	   $	��540��5   	   $	��432��6      VS2012WindowStyle4#���   5   	    � 	Resources 5        boolToUIVisibilityConverter.   (UFO.Converters.NullToVisibilityConverter  nullToVisibilityConverter.   (UFO.Converters.ByteArrayToImageConverter  byteArrayToImageConverter*   $UFO.Converters.DateToStringConverter  dateToStringConverter��%t   &	       &	      &	 &     &	 9     �� 5   
   6'     5   
   6)     5   
   6)     5   
   6%   5      .��5      � $��15,10,15,10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $��36 �6   .+�5   
   �� .+�5      �  � ColumnDefinitions 5      �� 5      �� 5       .+�5"      "  MolserLib.Controls.MsTextBox  $��0q�5#      $��0��5$         	Watermark$ Фамилия...��5%      $
��Left=�5&       � ToolTip$ Фамилия��5(      ��5'      �� *Family+ �� UpdateSourceTrigger$ PropertyChanged=�.��5(   '   5)        5*      $��10,0,0,0q�5+      $��1��5,      $  Имя Отчество...��5-      $
��Left=�5.      $ Имя Отчество��50      ��5/      �� *Name+$ PropertyChanged=�.��50   ,   51      52      � 53       54      �� 55      $
��auto �6'   �� 56      $��* �6'   .+�5<      �� $��0,10,0,0q�5=       �� Orientation$ 
Horizontal=�5>      .+�5?      �� $!��Дата рождения: ��6    &   Xceed.Wpf.Toolkit.DateTimePicker  5@      -   5          Name$ BirthdayDatePicker��5A      $��10,0,0,0q�5B      $��98��5C      $��26��5D      	   AutoCloseCalendar	 . &   Xceed.Wpf.Toolkit.DateTimeUpDown
   Format$
 	ShortDate=�5F      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ClipValueToMinMax .     Kind$ Local=�5H         TimePickerVisibility$ 	Collapsed=�5I         ShowButtonSpinner .  $ Дата рождения��5M      ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 5K      ��  �� Mode$ TwoWay=� �� Path$ Birthday�$ 	LostFocus=� �� 	Converter# [ 5M      5o      5q      �� 5w      $ 
Horizontal=�6   $��0,10,0,0q�5x      .+�5y      �� $ ��Дата операции ��6   �� 5z      $ 
Horizontal=�5{      .+�5|      �� $	��с:��6$     5}      -   5        $" OperationDateStartDatePicker��5~      $��5,0,0,0q�5      $	��130��5�      $��26��5�      	 . $
 Custom=�5�         FormatString$ dd.MM.yyyy HH:mm��5�       .  $, &Дата начала операции��5�         Value 5�      �� $ TwoWay=�$ OperationDateStart�$ PropertyChanged=�5�      5�      �� 5�      $ 
Horizontal=�5�      $��10,0,0,0q�5�      .+�5�      �� $��по:��6$     5�      -   5        $  OperationDateEndDatePicker��5�      $��5,0,0,0q�5�      $	��130��5�      $��26��5�      	 . $
 Custom=�5�      $ dd.MM.yyyy HH:mm��5�       .  $2 ,Дата окончания операции��5�       5�      �� $ TwoWay=�$ OperationDateEnd�$ PropertyChanged=�5�      5�      5�      �� 5�      $��0,10,0,0q�5�      $��Right=�5�      $��
Найти��5�      $��26��5�      ��5�      �� *GetPersonsCommand+5�      5�      �� 5�   
   -   5        $��personsListBox��5�      $��1��5�      $��0,10,0,0q�5�      ��5�      �� *	Persons+ �� SelectedItem 5�      �� *SelectedPerson+y�5      �� *	Persons+# [ ��5     �� 5     .R�5     �� $��0q�5     
������  J� InputBindings 5     d� 5      d� Gesture$ LeftDoubleClicka�6+    �� Command 5  %   �� *!DataContext.ConfirmationCommand+ �� RelativeSource ��  �� AncestorType" ��._�5     �� $ 
Horizontal=�6%   .+�5     � (	  "Xceed.Wpf.Toolkit.MagnifierManager 	  	Magnifier 5  "   !
  Xceed.Wpf.Toolkit.Magnifier
  5  &    
  Radius$ 90Q�65    
  
ZoomFactor$ .4Q�6A   
�������$��1q�5  A   .+�5  "   ��  ��Name$ PersonPhoto��6(   $��80��5  !   $
��Left=�5  !   $	��Top=�5  !   ��5  !   �� *
ImageArray+# [ 5     �� 5     $ Vertical=�6)   $��5,0,0,0q�5  %   .+�5  "   �� ��6,   �� *
FullName+�� 5  "   $ 
Horizontal=�6-   .+�5  &   �� ��60   �� *DateOfBirth+ �� StringFormat$ {0:dd.MM.yyyy}���� 5  &   $�� г.р.��60   5  #   �� 5  "   ��6,   �� *NationalityName+5     5      5!     5"     5$     � 5%  
   $��2��6   $��0,10,0,0q�5&      5'     �� 5(     $
��auto �6#   �� 5)     .+�5+     �� $ 
Horizontal=�6   $��0��5,     y�5-     �� *	Persons+# [ .+�5.     �� $+��%Количество записей: ��6   �� 5/     ��6   ��   �� ElementName$  personsListBox��$ Items.Count�$ OneWay=�50     �� 51     $ 
Horizontal=�6   $��1��52     $��Right=�53     .+�54     �� $
��ОК��6   $��60��6N   ��6&   �� *ConfirmationCommand+6N   �� 55     $��Отмена��6   $��10,0,0,0q�6*   ! �� IsCancel! . $��60��6L   56     57     58     59     