   M S B A M L   `   `   `  ����?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=null/clr-namespace:UFO.ConvertersUFO.Converters  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   /clr-namespace:UFO.PropertiesUFO.Properties  5   	       UFO.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -convclr-namespace:UFO.Converters     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   *pclr-namespace:UFO.Properties     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  УФО��5	   	   $	��600��6   $	��800��6"    � Icon$ /Icons/UFO.ico��5   	      	TextColor#���   5   	     VS2012WindowStyle4#��[ 5   	    � 	Resources 5      !   UFO.Converters.SexConverter 	 SConv%   UFO.Converters.ToUpperConverter 
 UpConv��%:   &	       &	        5   
   6     5   
   6    5      .��5      ]� .+�5   
   o� -   5         o�Name$
 menu��5      $
��Left=�6   $	��Top=�68   $	��Top=�6P     MenuTextColor#���  6f   .@�5      m� $��Файл��6    m� StaysOpenOnClick . .@�5      m� $��
Выход��6   5      m� 5      $��
Поиск��6    . .@�5      m� -   5        $��
Найти��5      6*   m� 5      -   5        $��Очистить поля��5      62   5      m� 5      $��Настройки��6    . .@�5      m� -   5        $$��Подключение к БД��5      65   m� 5      $��Темы��6   .@�5      m� -   5         m�Name$ WSLightButton��5   n   $��WS_Light��6    m� IsCheckable .  m� 	IsChecked . 6�   m� 5       -   5        $ WSDarkButton��5    [   $��WS_Dark��6    . 6[   5!      5"      m� 5#      $��Справка��6    . .@�5$      m� -   5        $��Вызов справки��5$      62   �� 5%      m� 5&      -   5        $��О программе��5&      60   5'      5(      c� 5*   
   $	��Top=�6   $��0,2,0,0q�6'   .@�5+      �� -	   5         � ToolTip$ 
Найти��5+      	 ^� ShowOnDisabled	 . 
 �� 	IsDefault
 . $��25��6\   $��80��6~   $��3,0,0,0q�6�   .��5,      ��  �� Orientation$ 
Horizontal=�6   .+�5-      �� $��/Icons/Search.png��6   �� 5.      $��5,0,0,0q�6    #���  61   
Найти6e   5/      50      �� 51      -
   5        $ Очистить��51      	 . 
 . $��25��6_   $��85��6�   $��3,0,0,0q�6�   .��52      �� $ 
Horizontal=�6   .+�53      �� $��/Icons/Broom.png��6   �� 54      $��5,0,0,0q�6    #���  62   Очистить6i   55      56      �� 57      -   5        $��ShowPhotoSearchView��58      $��3,0,0,0q�57      $ Поиск по фото��5:      $��25��5;      .��5<      �� $ 
Horizontal=�6   .+�5=      (� $��17��6   $��15��6)   .��5>      ��   
PersonPath#��[ 5?   !   
����·�$��15��5A   !   $��17��6,   5B      �� 5D      $��5,0,0,0q�6    $��Поиск по фото��61   5E      5G      5M      �� 5N   
   $	��Top=�6     MenuSeparatorBorderBrush#��[ 6&   $	��0.4q�6^   ._�5O      �  � Orientation$ 
Horizontal=�6   .+�5P      �� $��15,5,5,5q�6   .+�5Q      �� #���   6    С какой даты:6X   (  "System.Windows.Controls.DatePicker  5R      -   5          Name$ 
date_start��5R   !   $	��100��65   $��24��6A   6P   5S      �� 5U      $��15,5,5,5q�6   .+�5V      �� #���   6    По какую дату:6Y     5W      -   5        $ date_end��5W   !   $	��100��63   $��24��6?   6M   5X      �� 5Z      $��15,5,5,5q�6   .+�5[      �� #���   6    Направление:6X   �� 5\      -   5        $��cbNdb��5\   t   $	��130��6   $��24��6+     TextBoxFont#���  67    �� SelectedIndex$ 0��6b   .@�5]      �� .��6'   ВЪЕЗД\ВЫЕЗД64   �� 5^      .��6'   
ВЪЕЗД6.   �� 5_      .��6'   
ВЫЕЗД6.   5`      5a      �� 5c      $��15,5,5,5q�6   .+�5d      �� #���   6    Фамилия:6T   �� 5e      -   5         ��Name$ tbFamily��5e   6   $	��150��6   $��24��6*    �� CharacterCasing$ Upper=�6H   #���  6`     TextBoxCaret �� 
CaretBrush# �  6�   5f      �� 5h      $��15,5,5,5q�6   .+�5i      �� #���   6    	Имя:6O   �� 5j      -   5        $ tbName��5j   6   $	��150��6   $��24��6*   $ Upper=�6F   #���  6^   # �  6�   6�   5k      5l      5m      �� 5o   
   $��Bottom=�6   $��Stretch=�6,   $��Bottom=�6J   $��24��6e   .@�5p      �� $��3,0,0,0q�6   �� 5q      $+�%Количество записей: ��6    �� 5r      �6   �� *Items.Count+ �� ElementName$ vGrid�� �� Mode$ OneWay=�5s      �� 5u      $��Right=�6   .��5v      � $ 
Horizontal=�6   .+�5w      �� $��0,0,20,0q�6    �� 5x      $-�'© Отряд Домодедово 2019��6   6?   5y      �� 5z       J� Opacity$
 0.75Q�6!   5{      5|      5~      &   System.Windows.Controls.DataGrid  5�   
   -   5          Name$ vGrid��5�      $��1,5,1,0q�5�      $	��Top=�5�      $	��Top=�5�         AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�5�       	 DataGridLinesBrush   HorizontalGridLinesBrush# � 	 5�         CanUserResizeRows .     
IsReadOnly .    HeadersVisibility$	 All=�5�         SelectionMode$ Single=�5�         SelectionUnit$ FullRow=�5�      #���  5�      ���	#FF3E3E42 5�      )  #System.Windows.Controls.DataGridRow �� 
TargetType 
 StandardDataGridRow �� BasedOn��%N   '        7 
 �� 5�      "  6   8   .�5�      -   5        5�      5�          Columns  5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn!   Header$! Дата проверки��6%   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6<   �� # �� Path$# 
ChecklTime�$ �� StringFormat$$ {0:dd.MM.yy HH:mm:ss}��  5�      $! Направление��6%   " 6:   �� $# PassengerBorderRouting�  5�      $! ФИО��6%   " 62   �� $# PassengerFio�  5�      $! Дата рождения��6%   " 6<   �� $# PassengerDateOfBirth�$$ {0:dd.MM.yyyy}��  5�      $! Гражданство��6%   " 6:   �� *PassengerCitizenship+5�      5�      5�      