   M S B A M L   `   `   `  ����?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=nullclr-namespace:UFOUFO  5   	   D @MolserLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ3clr-namespace:MolserLib.Controls;assembly=MolserLibMolserLib.Controls 5   	   N5clr-namespace:MolserLib.Converters;assembly=MolserLibMolserLib.Converters 5	   	       UFO.ListView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:UFO     5   	   Fmolser3clr-namespace:MolserLib.Controls;assembly=MolserLib     5   	   Fconv5clr-namespace:MolserLib.Converters;assembly=MolserLib     5	   	   $
��1920��5   	   $
��1080��5   	   $	��640��5   	   $	��550��5   	     � SizeToContent$  Manual=�5   	      VS2012WindowStyle4#��[  5   	     TextBoxFont#���  5   	    � Title 5
   	   �� *Title+ � 	Resources 5        boolToUIVisibilityConverter=  7MolserLib.Converters.BoolToUIVisibilityInverseConverter & "boolToUIVisibilityInverseConverter4  .MolserLib.Converters.NullToVisibilityConverter  nullToVisibilityConverter5  /MolserLib.Converters.BoolToBoolInverseConverter  inverseBooleanConverter;  5MolserLib.Converters.BoolToUIVisibilityMultiConverter $  boolToUIVisibilityMultiConverter.  (MolserLib.Converters.NullToBoolConverter  nullToBoolConverter;  5MolserLib.Converters.BoolToHeadersVisibilityConverter $  boolToHeadersVisibilityConverter��%�   &	       &	      &	 &     &	 9     &	 L     &	 _     &	 r     �� 5   
   6'     5   
   62     5   
   6)     5   
   6*     5   
   60     5   
   6#     5   
   60   5      .��5!      � $��0q�6   $	��Top=�6    � RowDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      �� 5%      $
��auto �6    � ColumnDefinitions 5'   
   �� 5(      .+�5*   
   c� $��0��6   .@�5+      d� -   5         d�Name$ showOnlyCheckedButton��5+      $��32��5,      $��0,0,10,0q�6&    d� 	IsChecked 5/      �� *IsOnlyCheckedShowed+y�50      �� *IsSelectableMode+ �� 	Converter# [ .��51      �� $��0q�6   
������  �� Padding$ 2q�6F   ._�52      ��  	 FilterOnlyCheckedViewbox#��[	 6%   53      ��54      �� 55      	 �� 
TargetType"	 d�6    
 ToolBarButtonBaseStyle
 �� BasedOn#
 [
 66   .�56      ��  �� Property �@�ToolTip �� Value$8 2Показать только выделенные��64    �� Triggers 57      P� 58       P� Property �@d�	IsChecked P� Value$
 TrueY�6;   . �59   "   ��  �@�ToolTip$8 2Показаны только выделенные��6<   5:      5<      5>      � 5?      .+�5@      "  MolserLib.Controls.MsTextBox  -   5          Name$ findTextBox��5@   #   $��0,0,20,0q�5A   !   $��0��5B   !   $��0��5C   !   $	��160��5D   !   $��Stretch=�5E   !   $��Center=�5F   !    � ToolTip$ 
Найти��5G   !    �� TextWrapping$
 Wrap=�5H   !      	Watermark$ Найти...��5N   !   ��5M   !   �� *FilterFindValue+ �� UpdateSourceTrigger$ PropertyChanged=�.��5O   "   5P      5Q      �� 5S      $��10,0,0,0q�6    �� Orientation$ 
Horizontal=�6+   y�5T      �� *IsFilterListEnable+ �� Mode$ OneWay=�# [ .+�5U      �� $��Отдел:��6   $��Center=�6*   $��0,0,10,0q�6E   �� 5V      -   5         ��Name$ filterListComboBox��5V      $��80��5W      $��Stretch=�5X       �� SelectedIndex$ 0��5Z      $��0,0,10,0q�5]      $��Center=�5^      ��5Y      �� *Departments+ �� SelectedItem 5[      �� *FilterListValue+5_      5`      �� 5a      $��32��6   $. (Экспортировать в MS Excel��5c       ^� ShowOnDisabled .   MsExcelCanvas#��[ 5e      ��5b      �� *ExportToMSExcelCommand+y�5d      �� *IsExportEnable+# [ 5f      5g      � 5h   
   $��1��6   $��	10,0,10,0q�6    5i      �� 5j       5l      �� 5m      .+�5o      � -   5        $��dummyElement��5o      $y�	Collapsed=�65   �� 5p      -   5         ��Name$ dummyCheckAllCheckBox��5p      $y�	Collapsed=�66   &   System.Windows.Controls.DataGrid  5q      -   5          Name$ itemsDataGrig��5q   $   $��0��6   $��0,0,0,0q�6;   $��Stretch=�5t      $	��Top=�5u         AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�5x        DataGridLinesBrush   HorizontalGridLinesBrush# [ 5y          CanUserResizeRows  .  !   CanUserAddRows! .  "   SelectionMode$" Single=�5}      $
��1920��5~      $
��1080��5      #   EnableRowVirtualization# . !$   EnableColumnVirtualization$ . % �� IsTextSearchEnabled% . & w� TextPath$
& Name��5�      '   
IsReadOnly' . ��5r      �� *Items+ 5s      �� *SelectedItem+y�5w      �� *Items+# [ (   HeadersVisibility( 5|      �� *IsStatisticsHidden+$ OneWay=�# [  5�      ��%    5�      )   Columns) 5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn* 
  Header$*  ��6-   + 
  
IsReadOnly+ .  , 
  CanUserSort, . - 
  SortMemberPath$- 	IsChecked��6]   . 
  
Visibility. 5�   -   �� *DataContext.IsSelectableMode+/ �� Source/ %  System.Windows.Markup.Reference  *dummyElement+# [ 0 
  HeaderTemplate0 5�      �� 5�      .R�5�   "   � $��0,0,0,0q�6'   .+�5�   &   �� $ checkAllCheckBox��6/   -   5        $
��Left=�5�   ,    5�   -   �� *	IsChecked+1 �� ElementName$1 dummyCheckAllCheckBox����5�   *   �� 5�   .   "	 ��64     StandardCheckBox#
 [ 6J   .�5�   2   ��  �@�ToolTip$ Выбрать все��6L    5�   2   P� 5�   6    �@d�	IsChecked$
 TrueY�6S   . �5�   :   ��  �@�ToolTip$1 +Снять выделение со всех��6T   5�   7   5�   /   5�   '   5�   #   5�      2 	  CellTemplate2 5�      �� 5�      .R�5�   "   �  5�   &   �� 5�   *   $
��auto �68   .+�5�   &   �� $��0��6/   $��0,0,0,0q�6=   $
��Left=�5�   /   $��Center=�6J    5�   /   �� 3 �� Path$3 	IsChecked�4 �� IsAsync4 .  $ PropertyChanged=�5�   #   5�      5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $* Название��6)   + . 1  +System.Windows.Controls.DataGridBoundColumn5   Binding5 6;   �� $
3 Name�4 .  . 5�   )   �� *" DataContext.ItemProperties[Name]+/   *dummyElement+# [ 5�        5�      $* ID��6)   + . 5 65   �� $3 Id�4 .  6`   5�      5�      � 5�   
   $��2��6   $��0,5,0,0q�6    5�      �� 5�      $
��auto �6#   �� 5�      .+�5�      �� $��0��6   $��10,0,0,0q�6)   $ 
Horizontal=�5�      $	��Top=�5�      y�5�      `� 5�      6 `� Mode$6 OneWay=�6#   7 `� 	Converter#7 [ 61   .1�5�      �� $ OneWay=�6"   $3 IsSelectableMode�60   �� 5�      $ OneWay=�6"   $3 IsStatisticsHidden�60   # [ 6J   5�      .+�5�      �� $��Выбрано: ��6   �� 5�      ��6   �� *SelectedItemsCount+5�      �� 5�      -   5        $��rowsCountStackPanel��5�      $��5,0,0,0q�5�      $��1��5�      $ 
Horizontal=�5�      $	��Top=�5�      y�5�      �� *IsStatisticsHidden+$ OneWay=�# [ .+�5�      �� $��Показано: ��6   �� 5�      -	   5        $��rowsCountTextBox��5�      ��64   �� $3 Items.Count�$1 itemsDataGrig���� 5�      $��5,0,0,0q�6   $��Всего: ��6-   �� 5�      ��6   �� *Items.Count+5�      5�      �� 5�   
   $��2��6   $��	0,5,15,10q�5�      $ 
Horizontal=�5�      $��Right=�5�      $	��Top=�5�      .+�5�      �� $��26��6   $��60��6!   $
��Left=�6-   $��OK��6H   8 �� 	IsDefault8 . ��6U   �� *ConfirmCommand+6x   �� 5�      -
   5        $
��Left=�5�      9 �� IsCancel9 . $��Отмена��6Z   $��10,0,0,0q�6k   $��26��6}   $��60��6�   5�      5�      5�      