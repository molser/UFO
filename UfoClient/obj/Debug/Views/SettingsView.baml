   M S B A M L   `   `   `  ����?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=null/clr-namespace:UFO.ConvertersUFO.Converters  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   /clr-namespace:UFO.PropertiesUFO.Properties  5   	   9!clr-namespace:UFO.ValidationRulesUFO.ValidationRules  5   	       UFO.SettingsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -convclr-namespace:UFO.Converters     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   *pclr-namespace:UFO.Properties     5   	   /v!clr-namespace:UFO.ValidationRules     5   	     � Icon$  /Icons/UFO.ico��5	   	      	TextColor#���   5
   	     VS2012WindowStyle4#��[ 5   	    � Title$@ :УФО - Настройки подключения к БД��5   	   $	��370��62   $	��500��6?    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      /   )UFO.Converters.BoolToBoolInverseConverter  boolToBoolInverseConverter��%   &	         5   
   6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��240 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5        .@�5      �� -   5        $��MainTabItem��5      $,��&Основная база данных��5      .��5      �� .+�5      ]� $��
55,30,55,0q�6!   .+�5      �� $��14(�6%   $
��Left=�63   $	��145��6N   Сервер:6c   �� 5      -   5        $��tbSqlServer��5   R   $��20,0,0,0q�6"   $��Stretch=�64   6g   5      ]� 5       $��
55,10,55,0q�6!   .+�5!      �� $��14(�6%   $
��Left=�63   $	��145��6N   База данных:6h   �� 5"      -   5        $��tbDatabaseName��5"   R   $��20,0,0,0q�6"   $��Stretch=�64   6j   5#      ]� 5$      $��
55,10,55,0q�6!   .+�5%      �� $��14(�6%   $
��Left=�63   $	��145��6N   Логин:6c   �� 5&      -   5        $��tbLogin��5&   R   $��20,0,0,0q�6"   $��Stretch=�64   6d   5'      ]� 5(      $��
55,10,55,0q�6!   .+�5)      �� $��14(�6%   $
��Left=�63   $	��145��6N   Пароль:6c   G� 5*      -   5        $��
pbPassword��5*   V   $��20,0,0,0q�6&   $��Stretch=�68   6j   5+      ]� 5-      $��
55,10,55,0q�6!   .+�5.      �� $��14(�6%   $
��Left=�63   $	��145��6N   '%Не выводить индексы:6p   �� 5/      -   5        $��tbIndex��51      $��20,0,0,0q�5/   "   $��Stretch=�50      .��52   ;   ��53      �� 54   "    �� Mode$ TwoWay=�6*    �� UpdateSourceTrigger$ PropertyChanged=�55   "    �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 	 �� Path$	 Indexes�58   "   
 �� ValidationRules
 5:   &   $   UFO.ValidationRules.IndexInput  5;   *   5=   #   .��5>   ,   ��5?      �� 5@   "    �� 
TargetType" ��6)     StandardTextBox �� BasedOn# [ 6G   .�5R   &   ��  �� Property �@�ToolTip �� Value$* $Не выводить индексы��6@    �� Triggers 5S   &   P� 5T   *    P� Property �@=�HasError P� Value . . �5U   .   ��  �@�ToolTip 5V   -   ��  �� Self �� RelativeSource# Z $)	 #(Validation.Errors)[0].ErrorContent�5W   +   5Y   #   .��5Z   -   5[      5]      5^      5_      �� 5`      -   5        $��KaskadTabItem��5`      $*��$База данных 'Каскад'��5a      .��5b      �� .+�5c      ��  �� Orientation$ 
Horizontal=�6!   $��
55,33,55,0q�6:   .+�5d      �� -	   5        $��IsKaskadDbUsedCheckBox��5d   R   $��0,0,0,0q�6#   $��Stretch=�64   6r   �� 5e      $��10,0,0,0q�6$   $��14(�66   $
��Left=�6D   $	��320��6_   @>Использовать базу данных 'Каскад':6�   5f      �� 5g      {�6!   ��  �� ElementName$ IsKaskadDbUsedCheckBox��$	 	IsChecked�.+�5h      ]� $��
55,10,55,0q�6%   .+�5i      �� $��14(�6)   $
��Left=�67   $	��145��6R   Сервер:6g   �� 5j      -
   5        $��KaskadSqlServerTextBox��5j   V   $��20,0,0,0q�6&   $��Stretch=�68   6v   5k      ]� 5l      $��
55,10,55,0q�6%   .+�5m      �� $��14(�6)   $
��Left=�67   $	��145��6R   База данных:6l   �� 5n      -   5        $"��KaskadSqlDatabaseNameTextBox��5n   V   $��20,0,0,0q�6&   $��Stretch=�68   6|   5o      ]� 5p      $��
55,10,55,0q�6%   .+�5q      �� $��14(�6)   $
��Left=�67   $	��145��6R   Логин:6g   �� 5r      -   5        $��KaskadSqlLoginTextBox��5r   V   $��20,0,0,0q�6&   $��Stretch=�68   6v   5s      ]� 5t      $��
55,10,55,0q�6%   .+�5u      �� $��14(�6)   $
��Left=�67   $	��145��6R   Пароль:6g   G� 5v      -   5        $"��KaskadSqlPasswordPasswordBox��5v   Z   $��20,0,0,0q�6*   $��Stretch=�6<   6�   5w      5x      5y      5z      5{      �� 5|   
   $��1��6   $ 
Horizontal=�6"   $��	0,20,53,0q�6;   $��Right=�6N   .+�5}      �� -   5        $��btCheckConnection��5}      $��0��6.   $	��150��6>   $/��)Проверить подключение��6J   6�   �� 5~      -   5        $��0��5~      $	��210��6%   $C��=Загрузить настройки по умолчанию��61   $��20,0,0,0q�6y   6�   5      �� 5�   
   $��2��6   $ 
Horizontal=�6"   $��	0,15,53,0q�6;   $��Right=�6N   .+�5�      �� -   5        $��btSave��5�      {�.  $��1��65   $��80��6E   $��Сохранить��6P   $��10,0,0,0q�6d   $��22��6v   $	��Top=�6�   6�   �� 5�      -   5        $��2��5�      $��80��6%   $��Right=�60   $��Отмена��6G   $��10,0,0,0q�6X   6�   5�      5�      5�      