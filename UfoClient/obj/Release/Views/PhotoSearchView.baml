   M S B A M L   `   `   `  ���� D  @MolserLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ3clr-namespace:MolserLib.Controls;assembly=MolserLibMolserLib.Controls  ? ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=null/clr-namespace:UFO.ConvertersUFO.Converters N5clr-namespace:MolserLib.Converters;assembly=MolserLibMolserLib.Converters  clr-namespace:UFOUFO    UFO.PhotoSearchView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Fmolser3clr-namespace:MolserLib.Controls;assembly=MolserLib     -convclr-namespace:UFO.Converters     NmsConverters5clr-namespace:MolserLib.Converters;assembly=MolserLib     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  localclr-namespace:UFO    � Title$'  !УФО - Поиск по фото��$	��900��$	��730��   VS2012WindowStyle4#��[   � Icon$ /Icons/UFO.ico��  TextBoxFont#���   � 	Resources   boolToUIVisibilityConverter5   /MolserLib.Converters.BoolToBoolInverseConverter  BoolToBoolInverseConverter=   7MolserLib.Converters.BoolToUIVisibilityInverseConverter & "boolToUIVisibilityInverseConverter��%-   &	       &	      &	 
     ��     .��]� .+�� $��	0,0,10,10q�$	��Top=� � RowDefinitions �� $��* � � ColumnDefinitions �� $	��280 ��� $
��auto ��� $��* �.+��� .���� $��0��
������  �� Padding$ 	10,0,10,0q�._�]� ��. .+��� $��Фото��$	��Top=�.���� .+��� ���� *PhotoFileName+� -   $	��Top=� J� 	AllowDrop . .+�(�  (� Stretch$ Uniform=�$	��Top=�.���� -   $��photoCanvas��$��75��$	��100��.+���   
PersonPath#��[   PersonPathBrush#��[  �� Bottom$ 0��$��75������ 	 �� 
TargetType"	 ��.��� 
 �� Property
 � y� �� Value$ Hidden=� �� Triggers ��  �� Binding �� *PersonPhoto+ �� Value Z� .a��� 
 � y�$ Visible=��� $
��Left=�$��Bottom=�$��75������ *PersonPhoto+�� -    ��Name$ LoadPhotoButton��$��0,5,0,0q�$	��Top=�$1��+Загрузить фото из файла��$��26��$	��Top=� � ToolTip$! Загрузить фото������ *LoadPhotoCommand+�� -   $ GetPersonsButton��$��0,5,0,0q�$	��Top=�$3��-Загрузить фото из Каскад��$��26��$	��Top=�$! Загрузить фото������ *GetPersonsFromDbCommand+y��� *IsLoadPhotoFromDbEnabled+ �� 	Converter# [ ]� $��0,0,0,0q�$	��Top=���.  .+��� $��Год рождения��$	��Top=�.����  �� Orientation$ 
Horizontal=�.+��� $ 
Horizontal=�.+��� $ 
Horizontal=�.+��� $��0,0,0,0q�$	��c: ���� -    ��Name$ YearStartComboBox��$
��Left=�$
��Left=�$��65��$��24�� �� SelectedItem �� *	YearStart+���� *Years+�� $ 
Horizontal=�.+��� $��5,0,0,0q�$��по: ���� -   $ YearEndComboBox��$��0,0,0,0q�$��Right=�$��65��$��24�� �� *	YearEnd+���� *Years+�� $	��Top=�$��Пол��.��]� $��0,0,0,0q�$	��Top=���. .+��� -   $ SexComboBox��$��Right=�$��0,0,0,0q� �� SelectedIndex$ 0�� �� DisplayMemberPath$
 Name��$��24�� �� *Sex+���� *Sexs+�� $	��Top=�$��Гражданство��.��]� $��0,0,0,0q�$	��Top=���.  .+��� $	��Top=�$��83��$
 Name������ *Nationalities+�� $��0,5,0,0q�$	��Top=�$+��%Выбрать гражданство��$��50��$��26��$; 5Выбрать граждаство из списка������ *ShowNationalitiesViewCommand+]� $��0,5,0,0q�$��Bottom=���.  .+��� $	��Top=�$��0q�
������ $��28��._�� -    �Name$ JobProgressBar��$	��Top=�$��0,0,0,0q� � IsIndeterminate . $��Stretch=�y��� *IsJobRunning+# [ � $	��Top=�.+��� -	   $ CancelGetResultButton��$��30��$��Отменить�� �� IsCancel . $! Прервать поиск������ *CancelJobCommand+y��� *IsJobRunning+# [ �� -
   $ GetResultButton��$��30��$��
Найти�� �� 	IsDefault . $# Запустить поиск������ *StartJobCommand+y��� *IsJobRunning+# [ �� -   $ SaveResultButton��$	��Top=�$��30��$��Сохранить��$+ %Сохранить результат������ *SavePhotoSearchResultCommand+�� $��0��$��1��$��3��$��3��$��Stretch=�$��Stretch=����� "	 ��.��� 
 � ��
 ����  P�  P� Property �@n�
IsDragging P� Value . . ��� 
 � ��
 ������ $��0,0,0,0q�$��0��$��2��.+�(  "System.Windows.Controls.WebBrowser  -     Name$ 
webBrowser��$��0,0,0,0q�