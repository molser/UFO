   M S B A M L   `   `   `  ���� ?  ;UFO, Version=1.1.0.16, Culture=neutral, PublicKeyToken=nullclr-namespace:UFOUFO  D @MolserLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ3clr-namespace:MolserLib.Controls;assembly=MolserLibMolserLib.Controls N5clr-namespace:MolserLib.Converters;assembly=MolserLibMolserLib.Converters     UFO.ListView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:UFO     Fmolser3clr-namespace:MolserLib.Controls;assembly=MolserLib     Fconv5clr-namespace:MolserLib.Converters;assembly=MolserLib     $
��1920��$
��1080��$	��640��$	��550��  � SizeToContent$  Manual=�   VS2012WindowStyle4#��[    TextBoxFont#���   � Title �� *Title+ � 	Resources   boolToUIVisibilityConverter=  7MolserLib.Converters.BoolToUIVisibilityInverseConverter & "boolToUIVisibilityInverseConverter4  .MolserLib.Converters.NullToVisibilityConverter  nullToVisibilityConverter5  /MolserLib.Converters.BoolToBoolInverseConverter  inverseBooleanConverter;  5MolserLib.Converters.BoolToUIVisibilityMultiConverter $  boolToUIVisibilityMultiConverter.  (MolserLib.Converters.NullToBoolConverter  nullToBoolConverter;  5MolserLib.Converters.BoolToHeadersVisibilityConverter $  boolToHeadersVisibilityConverter��%i   &	       &	      &	 
     &	      &	      &	      &	      ��             .��� $��0q�$	��Top=� � RowDefinitions �� $
��Auto ��� �� $
��auto � � ColumnDefinitions �� .+�c� $��0��.@�d� -    d�Name$ showOnlyCheckedButton��$��32��$��0,0,10,0q� d� 	IsChecked �� *IsOnlyCheckedShowed+y��� *IsSelectableMode+ �� 	Converter# [ .���� $��0q�
������  �� Padding$ 2q�._���  	 FilterOnlyCheckedViewbox#��[	 ���� 	 �� 
TargetType"	 d� 
 ToolBarButtonBaseStyle
 �� BasedOn#
 [
 .���  �� Property �@�ToolTip �� Value$8 2Показать только выделенные�� �� Triggers P�  P� Property �@d�	IsChecked P� Value$
 TrueY�. ���  �@�ToolTip$8 2Показаны только выделенные��� .+�"  MolserLib.Controls.MsTextBox  -     Name$ findTextBox��$��0,0,20,0q�$��0��$��0��$	��160��$��Stretch=�$��Center=� � ToolTip$ 
Найти�� �� TextWrapping$
 Wrap=�   	Watermark$ Найти...������ *FilterFindValue+ �� UpdateSourceTrigger$ PropertyChanged=�.���� $��10,0,0,0q� �� Orientation$ 
Horizontal=�y��� *IsFilterListEnable+ �� Mode$ OneWay=�# [ .+��� $��Отдел:��$��Center=�$��0,0,10,0q��� -    ��Name$ filterListComboBox��$��80��$��Stretch=� �� SelectedIndex$ 0��$��0,0,10,0q�$��Center=����� *Departments+ �� SelectedItem �� *FilterListValue+�� $��32��$. (Экспортировать в MS Excel�� ^� ShowOnDisabled .   MsExcelCanvas#��[ ���� *ExportToMSExcelCommand+y��� *IsExportEnable+# [ � $��1��$��	10,0,10,0q� ��  �� .+�� -   $��dummyElement��$y�	Collapsed=��� -    ��Name$ dummyCheckAllCheckBox��$y�	Collapsed=�&   System.Windows.Controls.DataGrid  -     Name$ itemsDataGrig��$��0��$��0,0,0,0q�$��Stretch=�$	��Top=�   AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�  DataGridLinesBrush   HorizontalGridLinesBrush# [     CanUserResizeRows  .  !   CanUserAddRows! .  "   SelectionMode$" Single=�$
��1920��$
��1080��#   EnableRowVirtualization# . !$   EnableColumnVirtualization$ . % �� IsTextSearchEnabled% . & w� TextPath$
& Name��'   
IsReadOnly' . ���� *Items+ �� *SelectedItem+y��� *Items+# [ (   HeadersVisibility( �� *IsStatisticsHidden+$ OneWay=�# [  ��%    )   Columns) 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn* 
  Header$*  ��+ 
  
IsReadOnly+ .  , 
  CanUserSort, . - 
  SortMemberPath$- 	IsChecked��. 
  
Visibility. �� *DataContext.IsSelectableMode+/ �� Source/ %  System.Windows.Markup.Reference  *dummyElement+# [ 0 
  HeaderTemplate0 �� .R�� $��0,0,0,0q�.+��� $ checkAllCheckBox��-   $
��Left=� �� *	IsChecked+1 �� ElementName$1 dummyCheckAllCheckBox������ "	 ��  StandardCheckBox#
 [ .���  �@�ToolTip$ Выбрать все�� P�  �@d�	IsChecked$
 TrueY�. ���  �@�ToolTip$1 +Снять выделение со всех��2 	  CellTemplate2 �� .R��  �� $
��auto �.+��� $��0��$��0,0,0,0q�$
��Left=�$��Center=� �� 3 �� Path$3 	IsChecked�4 �� IsAsync4 .  $ PropertyChanged=�0  *System.Windows.Controls.DataGridTextColumn  $* Название��+ . 1  +System.Windows.Controls.DataGridBoundColumn5   Binding5 �� $
3 Name�4 .  . �� *" DataContext.ItemProperties[Name]+/   *dummyElement+# [   $* ID��+ . 5 �� $3 Id�4 .  � $��2��$��0,5,0,0q� �� $
��auto ��� .+��� $��0��$��10,0,0,0q�$ 
Horizontal=�$	��Top=�y�`� 6 `� Mode$6 OneWay=�7 `� 	Converter#7 [ .1��� $ OneWay=�$3 IsSelectableMode��� $ OneWay=�$3 IsStatisticsHidden�# [ .+��� $��Выбрано: ���� ���� *SelectedItemsCount+�� -   $��rowsCountStackPanel��$��5,0,0,0q�$��1��$ 
Horizontal=�$	��Top=�y��� *IsStatisticsHidden+$ OneWay=�# [ .+��� $��Показано: ���� -	   $��rowsCountTextBox������ $3 Items.Count�$1 itemsDataGrig���� $��5,0,0,0q�$��Всего: ���� ���� *Items.Count+�� $��2��$��	0,5,15,10q�$ 
Horizontal=�$��Right=�$	��Top=�.+��� $��26��$��60��$
��Left=�$��OK��8 �� 	IsDefault8 . ���� *ConfirmCommand+�� -
   $
��Left=�9 �� IsCancel9 . $��Отмена��$��10,0,0,0q�$��26��$��60��