   M S B A M L   `   `   `  ���� ?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=nullclr-namespace:UFOUFO  D @MolserLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ3clr-namespace:MolserLib.Controls;assembly=MolserLibMolserLib.Controls /clr-namespace:UFO.ConvertersUFO.Converters      UFO.PhotoFromDbView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:UFO     Fmolser3clr-namespace:MolserLib.Controls;assembly=MolserLib     -convclr-namespace:UFO.Converters     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$C  =Импорт фото из базы данных Каскад��$	��540��$	��432��   VS2012WindowStyle4#���    � 	Resources   boolToUIVisibilityConverter.   (UFO.Converters.NullToVisibilityConverter  nullToVisibilityConverter.   (UFO.Converters.ByteArrayToImageConverter  byteArrayToImageConverter*   $UFO.Converters.DateToStringConverter  dateToStringConverter��%<   &	       &	      &	 
     &	      ��       .��� $��15,10,15,10q� � RowDefinitions �� $
��auto ��� �� $��36 �.+��� .+��  � ColumnDefinitions �� �� .+�"  MolserLib.Controls.MsTextBox  $��0q�$��0��   	Watermark$ Фамилия...��$
��Left=� � ToolTip$ Фамилия������ *Family+ �� UpdateSourceTrigger$ PropertyChanged=�.��  $��10,0,0,0q�$��1��$  Имя Отчество...��$
��Left=�$ Имя Отчество������ *Name+$ PropertyChanged=�.���  �� $
��auto ��� $��* �.+��� $��0,10,0,0q� �� Orientation$ 
Horizontal=�.+��� $!��Дата рождения: ��&   Xceed.Wpf.Toolkit.DateTimePicker  -     Name$ BirthdayDatePicker��$��10,0,0,0q�$��98��$��26��	   AutoCloseCalendar	 . &   Xceed.Wpf.Toolkit.DateTimeUpDown
   Format$
 	ShortDate=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ClipValueToMinMax .     Kind$ Local=�   TimePickerVisibility$ 	Collapsed=�   ShowButtonSpinner .  $ Дата рождения��,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text ��  �� Mode$ TwoWay=� �� Path$ Birthday�$ 	LostFocus=� �� 	Converter# [ �� $ 
Horizontal=�$��0,10,0,0q�.+��� $ ��Дата операции ���� $ 
Horizontal=�.+��� $	��с:��  -   $" OperationDateStartDatePicker��$��5,0,0,0q�$	��130��$��26��	 . $
 Custom=�   FormatString$ dd.MM.yyyy HH:mm�� .  $, &Дата начала операции��   Value �� $ TwoWay=�$ OperationDateStart�$ PropertyChanged=��� $ 
Horizontal=�$��10,0,0,0q�.+��� $��по:��  -   $  OperationDateEndDatePicker��$��5,0,0,0q�$	��130��$��26��	 . $
 Custom=�$ dd.MM.yyyy HH:mm�� .  $2 ,Дата окончания операции�� �� $ TwoWay=�$ OperationDateEnd�$ PropertyChanged=��� $��0,10,0,0q�$��Right=�$��
Найти��$��26������ *GetPersonsCommand+�� -   $��personsListBox��$��1��$��0,10,0,0q����� *	Persons+ �� SelectedItem �� *SelectedPerson+y��� *	Persons+# [ ���� .R��� $��0q�
������  J� InputBindings d�  d� Gesture$ LeftDoubleClicka� �� Command �� *!DataContext.ConfirmationCommand+ �� RelativeSource ��  �� AncestorType" ��._��� $ 
Horizontal=�.+�� (	  "Xceed.Wpf.Toolkit.MagnifierManager 	  	Magnifier !
  Xceed.Wpf.Toolkit.Magnifier
   
  Radius$ 90Q� 
  
ZoomFactor$ .4Q�
�������$��1q�.+���  ��Name$ PersonPhoto��$��80��$
��Left=�$	��Top=����� *
ImageArray+# [ �� $ Vertical=�$��5,0,0,0q�.+��� ���� *
FullName+�� $ 
Horizontal=�.+��� ���� *DateOfBirth+ �� StringFormat$ {0:dd.MM.yyyy}���� $�� г.р.���� ���� *NationalityName+� $��2��$��0,10,0,0q� �� $
��auto ��� .+��� $ 
Horizontal=�$��0��y��� *	Persons+# [ .+��� $+��%Количество записей: ���� ����   �� ElementName$  personsListBox��$ Items.Count�$ OneWay=��� $ 
Horizontal=�$��1��$��Right=�.+��� $
��ОК��$��60������ *ConfirmationCommand+�� $��Отмена��$��10,0,0,0q�! �� IsCancel! . $��60��