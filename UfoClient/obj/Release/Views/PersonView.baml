   M S B A M L   `   `   `  ���� ?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=null/clr-namespace:UFO.ConvertersUFO.Converters      UFO.PersonView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -convclr-namespace:UFO.Converters     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$T  NУФО - Вероятная замена установочных данных��$	��600��$	��900��$	��600��$	��850�� � Icon$ /Icons/UFO.ico��   	TextColor#���     VS2012WindowStyle4#��[  � 	Resources #   UFO.Converters.TextComparison  textComparison&    UFO.Converters.DistanceConverter 	 LConv��%   &	       &	          .��]� .+��� $��Bottom=�$��Stretch=�$��Bottom=�$��24��.@��� $��3,0,0,0q��� $�Готово!���� $��Right=�.���  � Orientation$ 
Horizontal=�.+��� $��0,0,20,0q��� $-�'© Отряд Домодедово 2019����  J� Opacity$
 0.75Q��  � ShowGridLines .   � RowDefinitions �� -    ��Name$ Cell00��$��0.45* ��� $	��265 ��� $��0.25* � � ColumnDefinitions �� �� $��30 ��� �� $��30 ��� .+���   
PanelBrush#���    NormalBorderBrush#���  $��2,2,2,0q�	 �� CornerRadius$	 3,3,0,0��$��10,0,0,0q�._�]� .+��� $	��Top=�$��Stretch=�$��13(�$<��6ДАННЫЕ ЛИЦА, ПЕРЕСЕКАЮЩЕГО ГГ��
 �� TextAlignment$
 Center=�#���   �� $��5,5,5,0q�$	��Top=�$��Center=�$��2,2,2,2q�$	 4,4,4,4��  PhotoBorderBrush#���  ._�� (  "Xceed.Wpf.Toolkit.MagnifierManager   	Magnifier !  Xceed.Wpf.Toolkit.Magnifier     Radius$	 100Q�   
ZoomFactor$ .4Q�
�������$��1q�.+��� -   $��imgCurrentPhotoBack��$��/Icons/alien.png���� -   $��imgCurrentPhoto���� $��1��$��2��#���  #���  $��2,0,2,0q�$��10,0,0,0q�._��� -    ��Name$ spCurrentPerson��.+���  �� Orientation$ Vertical=�$��5,2,5,0q�.+��� $��0,0,3,0q�$��14(�#���   	ФИО:�� -    ��Name$ tbCurrentFIOLat��$��25��$��14(�$��SemiBold"� �� 
IsReadOnly .    TextBoxFont#���  ����  �� Path$ PassengerFio��� $��25��$��0,4,0,0q�$��14(�$��SemiBold"� . #���  �� $ Vertical=�$��5,2,5,0q�.+��� $��0,0,3,0q�$��14(�#���   Дата рождения:�� -   $ tbCurrentBirthDate��$��25��$��14(�$��SemiBold"� . #���  ���� *PassengerDateOfBirth+ �� StringFormat$ {0:dd.MM.yyyy}���� $ Vertical=�$��5,2,5,0q�.+��� $��0,0,3,0q�$��14(�#���   20Страна, выдавшая документ:�� -   $ tbCurrentCitizenship��$��25��$��14(�$��SemiBold"� . #���  ���� *PassengerCitizenship+�� $ Vertical=�$��5,2,5,0q�.+��� $��0,0,3,0q�$��14(�#���   /-Срок действия документа:�� -   $ tbCurrentDocValidity��$��25��$��14(�$��SemiBold"� . #���  ���� *PassengerDocValidity+$ {0:dd.MM.yyyy}���� $ Vertical=�$��5,2,5,0q�.+��� $��0,0,3,0q�$��14(�#���   &$Персональный номер:�� -	   $ tbCurrentPID��$��25��$��14(�$��SemiBold"� . #���  ���� *PassengerPersonalNumber+�� $��2��#���  #���  $��2,0,2,2q�$	 0,0,3,3��$��10,0,0,0q�._��� .+��� $��2��$	��Top=�$��Stretch=�$��5��$��5,1,5,2q�#���   �� RadiusX$ 3�� �� RadiusY$ 3��� $��1�� �� �� $��30 ��� .+��� $��Stretch=�#���  $ 3��$ 3��$��
13,25,13,3q��� -
   $��1��$��3q�  RadiusButton#���   � ToolTip$4 .Детальное сравнение фото�� J� BitmapEffect F�  F� Softness$ 1Q� F� ShadowDepth$ 3Q� F� Opacity$	 0.5Q�.���� $&�� /Icons/Camera_Identification.png���� $��2��$��Stretch=�#���  $ 3��$ 3��$��	13,3,13,0q��� $��2��#���  #���  $��2,2,2,0q�$	 3,3,0,0��._�]� .+��� $	��Top=�$��Stretch=�$��13(�$8��2ЛИЦО, РАНЕЕ ПЕРЕСЕКАВШЕЕ ГГ��$
 Center=�#���   �� $��5,5,5,0q�$	��Top=�$��Center=�$��2,2,2,2q�$	 4,4,4,4��#���  ._��    $	 100Q�$ .4Q�
�������$��1q�.+��� -   $��imgBasePhotoBack��$��/Icons/alien.png���� -   $��imgBasePhoto���� $��2��$��1��#���  #���  $��2,0,2,0q�._��� -   $ spBasePerson��.+��� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�	ФИО:�� -   $ tbBaseFIOLat��$��25��$��14(�$��SemiBold"� . #���  ���� *RessemblanceFioLat+�� -   $ tbCurrentFIORus��$��25��$��0,4,0,0q�$��14(�$��SemiBold"� . #���  ���� *RessemblanceFioRus+�� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�Дата рождения:�� -   $ tbBaseBirthDate��$��25��$��14(�$��SemiBold"� . #���  ���� *RessenblanceDateOfBirth+$ {0:dd.MM.yyyy}���� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�Гражданство:�� -   $ tbBaseCitizenship��$��25��$��14(�$��SemiBold"� . #���  ���� *RessemblanceNationalityCode+�� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�/-Срок действия документа:�� -   $ tbBaseDocValidity��$��25��$��14(�$��SemiBold"� . #���  ���� *RessenblanceDocValidity+$ {0:dd.MM.yyyy}���� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�&$Персональный номер:�� -   $ 	tbBasePID��$��25��$��14(�$��SemiBold"� . #���  ���� *RessemblancePersonalNumber+�� -   $ tbDateShort��$y�Hidden=�$��14(�$��SemiBold"� . #���  ���� *RessenblanceDateOfBirth+$ 
{0:ddMMyy}���� $��2��$��2��#���  #���  $��2,0,2,2q�$	 0,0,3,3��._��  �� $	��64* ��� $
��167* ��� $	��39* � �� $
��auto ��� $
��auto ��� .+��� $��0��$	��Top=�$��Stretch=�$��5��$��5,1,5,0q�#���  $ 3��$ 3��$��3���� $��1��$��5,0,3,0q�$��14(�#���   $��3��<:Сходства с архивом пересечений:&   System.Windows.Controls.DataGrid  -     Name$ dgBasePersons��$��2��$��5,5,5,0q�$	��Top=�   AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=� 	 DataGridLinesBrush   HorizontalGridLinesBrush# [	    CanUserResizeRows .      
IsReadOnly  . !   HeadersVisibility$
! None=�"   SelectionMode$" Single=�#   SelectionUnit$# FullRow=�#���  ���	#FF3E3E42$��3��$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   Header$% ФИО��1  +System.Windows.Controls.DataGridBoundColumn&   Binding& �� *RessemblanceFioRus+�� $��3��#���  $ 3��$ 3��$��
13,25,13,0q��� $��4��#���  #���  $��2,2,2,0q�$	 3,3,0,0��$��0,0,10,0q�._�]� .+��� $	��Top=�$��Stretch=�$��13(�$��ДАННЫЕ ИЗ ОУ��$
 Center=�#���   �� $��5,5,5,0q�$	��Top=�$��Center=�$��2,2,2,2q�$	 4,4,4,4��#���  ._��    $	 100Q�$ .4Q�
�������$��1q�.+��� $��/Icons/alien.png���� -   $��
imgOUPhoto���� $��4��$��1��#���  #���  $��2,0,2,0q�$��0,0,10,0q�._��� -   $ 
spOUPerson��.+��� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�	ФИО:�� $��14(�$��SemiBold"� . #���  �� -   $ 
tbOUFIORus��$��25��$��0,4,0,0q�$��14(�$��SemiBold"� . #���  ���� *FIO+�� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�Дата рождения:�� -   $ tbOUBirthDate��$��25��$��14(�$��SemiBold"� . #���  ���� *OU_BirthDate+$ {0:dd.MM.yyyy}���� $ Vertical=�$��5,2,5,0q�.+��� $y�Hidden=�$��0,0,3,0q�$��14(�$��
ExtraBlack"�Гражданство:�� -   $ tbOUCitizenShip��$��25��$��14(�$��SemiBold"� . #���  ���� *OU_NationalityCode+�� $ Vertical=�$��5,2,5,0q�.+��� $��0,0,3,0q�$��14(�#���   Спец. отметка:�� $��25��$��14(�$��SemiBold"� . #���  ���� *SpecialMark+�� -   $ tbLDist��$y�Hidden=�$��14(�$��SemiBold"� . #���  ���� *LevensteinDistance+�� $��2��$��4��#���  #���  $��2,0,2,2q�$	 0,0,3,3��$��0,0,10,0q�._��  �� $
��auto ��� $
��auto ��� .+��� $��0��$	��Top=�$��Stretch=�$��5��$��5,1,5,2q�#���  $ 3��$ 3���� $��1��$��5,0,3,0q�$��14(�#���    Сходства с БД ОУ:  -   $ dgOUPersons��$��2��$��5,5,5,0q�$	��Top=�$	��Top=� .  $ 
Horizontal=�# [	  .    . $
! None=�$" Single=�$# FullRow=�#���  ���	#FF3E3E42$   $% ФИО��& �� $	 FIO��� $��1��$��1��.+��� $��0,35,0,0q�$��30����`� ' `� 	Converter#' [ ( `� UpdateSourceTrigger$( PropertyChanged=�.1��� $
 Text�) �� ElementName$) tbCurrentFIOLat���� $
 Text�$) tbBaseFIOLat���� $��0,26,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbCurrentBirthDate���� $
 Text�$) tbBaseBirthDate���� $��0,16,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbCurrentCitizenship���� $
 Text�$) tbBaseCitizenship���� $��0,16,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbCurrentDocValidity���� $
 Text�$) tbBaseDocValidity���� $��0,16,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbCurrentPID���� $
 Text�$) 	tbBasePID���� $��3��$��1��.+��� $��0,35,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbLDist���� $��0,26,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbDateShort���� $
 Text�$) tbOUBirthDate���� $��0,16,0,0q�$��30����`� #' [ $( PropertyChanged=�.1��� $
 Text�$) tbBaseCitizenship���� $
 Text�$) tbOUCitizenShip��