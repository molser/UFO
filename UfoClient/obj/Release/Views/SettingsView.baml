   M S B A M L   `   `   `  ���� ?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=null/clr-namespace:UFO.ConvertersUFO.Converters  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms /clr-namespace:UFO.PropertiesUFO.Properties  9!clr-namespace:UFO.ValidationRulesUFO.ValidationRules      UFO.SettingsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -convclr-namespace:UFO.Converters     6sys&clr-namespace:System;assembly=mscorlib     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     *pclr-namespace:UFO.Properties     /v!clr-namespace:UFO.ValidationRules       � Icon$  /Icons/UFO.ico��   	TextColor#���     VS2012WindowStyle4#��[  � Title$@ :УФО - Настройки подключения к БД��$	��370��$	��500�� � 
ResizeMode$ NoResize=� � 	Resources /   )UFO.Converters.BoolToBoolInverseConverter  boolToBoolInverseConverter��%   &	         .���  � RowDefinitions �� $	��240 ��� $
��auto ��� $
��auto �.+��� -   .@��� -   $��MainTabItem��$,��&Основная база данных��.���� .+�]� $��
55,30,55,0q�.+��� $��14(�$
��Left=�$	��145��Сервер:�� -   $��tbSqlServer��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��База данных:�� -   $��tbDatabaseName��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��Логин:�� -   $��tbLogin��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��Пароль:G� -   $��
pbPassword��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��'%Не выводить индексы:�� -   $��tbIndex��$��20,0,0,0q�$��Stretch=�.������  �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 	 �� Path$	 Indexes�
 �� ValidationRules
 $   UFO.ValidationRules.IndexInput  .������  �� 
TargetType" ��  StandardTextBox �� BasedOn# [ .���  �� Property �@�ToolTip �� Value$* $Не выводить индексы�� �� Triggers P�  P� Property �@=�HasError P� Value . . ���  �@�ToolTip ��  �� Self �� RelativeSource# Z $)	 #(Validation.Errors)[0].ErrorContent�.���� -   $��KaskadTabItem��$*��$База данных 'Каскад'��.���� .+���  �� Orientation$ 
Horizontal=�$��
55,33,55,0q�.+��� -	   $��IsKaskadDbUsedCheckBox��$��0,0,0,0q�$��Stretch=��� $��10,0,0,0q�$��14(�$
��Left=�$	��320��@>Использовать базу данных 'Каскад':�� {���  �� ElementName$ IsKaskadDbUsedCheckBox��$	 	IsChecked�.+�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��Сервер:�� -
   $��KaskadSqlServerTextBox��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��База данных:�� -   $"��KaskadSqlDatabaseNameTextBox��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��Логин:�� -   $��KaskadSqlLoginTextBox��$��20,0,0,0q�$��Stretch=�]� $��
55,10,55,0q�.+��� $��14(�$
��Left=�$	��145��Пароль:G� -   $"��KaskadSqlPasswordPasswordBox��$��20,0,0,0q�$��Stretch=��� $��1��$ 
Horizontal=�$��	0,20,53,0q�$��Right=�.+��� -   $��btCheckConnection��$��0��$	��150��$/��)Проверить подключение���� -   $��0��$	��210��$C��=Загрузить настройки по умолчанию��$��20,0,0,0q��� $��2��$ 
Horizontal=�$��	0,15,53,0q�$��Right=�.+��� -   $��btSave��{�.  $��1��$��80��$��Сохранить��$��10,0,0,0q�$��22��$	��Top=��� -   $��2��$��80��$��Right=�$��Отмена��$��10,0,0,0q�