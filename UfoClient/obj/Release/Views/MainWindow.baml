   M S B A M L   `   `   `  ���� ?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=null/clr-namespace:UFO.ConvertersUFO.Converters  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms /clr-namespace:UFO.PropertiesUFO.Properties      UFO.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -convclr-namespace:UFO.Converters     6sys&clr-namespace:System;assembly=mscorlib     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     *pclr-namespace:UFO.Properties     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  УФО��$	��600��$	��800�� � Icon$ /Icons/UFO.ico��   	TextColor#���     VS2012WindowStyle4#��[  � 	Resources !   UFO.Converters.SexConverter 	 SConv%   UFO.Converters.ToUpperConverter 
 UpConv��%   &	       &	          .��]� .+�o� -    o�Name$
 menu��$
��Left=�$	��Top=�$	��Top=�  MenuTextColor#���  .@�m� $��Файл�� m� StaysOpenOnClick . .@�m� $��
Выход��m� $��
Поиск�� . .@�m� -   $��
Найти��m� -   $��Очистить поля��m� $��Настройки�� . .@�m� -   $$��Подключение к БД��m� $��Темы��.@�m� -    m�Name$ WSLightButton��$��WS_Light�� m� IsCheckable .  m� 	IsChecked . m� -   $ WSDarkButton��$��WS_Dark�� . m� $��Справка�� . .@�m� -   $��Вызов справки���� m� -   $��О программе��c� $	��Top=�$��0,2,0,0q�.@��� -	    � ToolTip$ 
Найти��	 ^� ShowOnDisabled	 . 
 �� 	IsDefault
 . $��25��$��80��$��3,0,0,0q�.����  �� Orientation$ 
Horizontal=�.+��� $��/Icons/Search.png���� $��5,0,0,0q�#���  
Найти�� -
   $ Очистить��	 . 
 . $��25��$��85��$��3,0,0,0q�.���� $ 
Horizontal=�.+��� $��/Icons/Broom.png���� $��5,0,0,0q�#���  Очистить�� -   $��ShowPhotoSearchView��$��3,0,0,0q�$ Поиск по фото��$��25��.���� $ 
Horizontal=�.+�(� $��17��$��15��.����   
PersonPath#��[ 
����·�$��15��$��17���� $��5,0,0,0q�$��Поиск по фото���� $	��Top=�  MenuSeparatorBorderBrush#��[ $	��0.4q�._��  � Orientation$ 
Horizontal=�.+��� $��15,5,5,5q�.+��� #���   С какой даты:(  "System.Windows.Controls.DatePicker  -     Name$ 
date_start��$	��100��$��24���� $��15,5,5,5q�.+��� #���   По какую дату:  -   $ date_end��$	��100��$��24���� $��15,5,5,5q�.+��� #���   Направление:�� -   $��cbNdb��$	��130��$��24��  TextBoxFont#���   �� SelectedIndex$ 0��.@��� .��ВЪЕЗД\ВЫЕЗД�� .��
ВЪЕЗД�� .��
ВЫЕЗД�� $��15,5,5,5q�.+��� #���   Фамилия:�� -    ��Name$ tbFamily��$	��150��$��24�� �� CharacterCasing$ Upper=�#���    TextBoxCaret �� 
CaretBrush# �  �� $��15,5,5,5q�.+��� #���   	Имя:�� -   $ tbName��$	��150��$��24��$ Upper=�#���  # �  �� $��Bottom=�$��Stretch=�$��Bottom=�$��24��.@��� $��3,0,0,0q��� $+�%Количество записей: �� �� ��� *Items.Count+ �� ElementName$ vGrid�� �� Mode$ OneWay=��� $��Right=�.��� $ 
Horizontal=�.+��� $��0,0,20,0q��� $-�'© Отряд Домодедово 2019����  J� Opacity$
 0.75Q�&   System.Windows.Controls.DataGrid  -     Name$ vGrid��$��1,5,1,0q�$	��Top=�$	��Top=�   AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=� 	 DataGridLinesBrush   HorizontalGridLinesBrush# � 	    CanUserResizeRows .     
IsReadOnly .    HeadersVisibility$	 All=�   SelectionMode$ Single=�   SelectionUnit$ FullRow=�#���  ���	#FF3E3E42 )  #System.Windows.Controls.DataGridRow �� 
TargetType 
 StandardDataGridRow �� BasedOn��%%   '        7 
 �� "  8   .�-       Columns  0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn!   Header$! Дата проверки��1  +System.Windows.Controls.DataGridBoundColumn"   Binding" �� # �� Path$# 
ChecklTime�$ �� StringFormat$$ {0:dd.MM.yy HH:mm:ss}��  $! Направление��" �� $# PassengerBorderRouting�  $! ФИО��" �� $# PassengerFio�  $! Дата рождения��" �� $# PassengerDateOfBirth�$$ {0:dd.MM.yyyy}��  $! Гражданство��" �� *PassengerCitizenship+