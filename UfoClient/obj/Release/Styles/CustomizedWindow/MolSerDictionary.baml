   M S B A M L   `   `   `  ���� D  @MolserLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ3clr-namespace:MolserLib.Controls;assembly=MolserLibMolserLib.Controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   MsCrosshairButton �� 
TargetType �� Property �� Value  ButtonFocusVisual �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels	 �� Padding
 F�Name �� Stretch �� Triggers P� Property P� Value �� 
TargetName  	DarkBrush  ComboBoxTextBox ��Name  MsComboBoxToggleButton � ColumnDefinitions �� RelativeSource  
GlyphBrush  DisabledForegroundBrush  StandardMsTextBox"    MolserLib.Controls.MsTextBox-  'System.Windows.Input.KeyboardNavigation  	TextColor 	 TextBoxCaret 
 TextBoxBackgroundBrush  LightBorderBrush �Name ��Name J� IsHitTestVisible �� Padding J� Opacity �� Path ��Name � ToolTip  SolidBorderBrush �� BasedOn  StandardMsComboBox#   MolserLib.Controls.MsComboBox  TextBoxFont �� 	ClickMode d� 	IsChecked �� Mode �� SelectionBoxItem  �� SelectionBoxItemTemplate! ��Name" �� 
IsReadOnly# �� 
IsReadOnly$ �� IsDropDownOpen% � AllowsTransparency& � ActualWidth' �� MaxDropDownHeight  ComboxItemBackgroundBrush( K� IsItemsHost)   DirectionalNavigation* P� 
SourceName+ �� Triggers  StandardMsSlider!   MolserLib.Controls.MsSlider, � RowDefinitions- m�Name. m� Fill/ m� 	Placement0 ��Name1 ]�Name2 ]� DecreaseRepeatButton3 ]� IncreaseRepeatButton4 ]� Thumb5 n�Name6 T� X7 T� Y8 �� EndPoint9 �� 
StartPoint: � Color; � Offset< �� Angle  PressedBrush�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     >molser3clr-namespace:MolserLib.Controls;assembly=MolserLib    �� $ Shared.xaml?�%�)  &	        7  &	 M    &	 �    &	 �    7   '   �	    7  &	 �	    '  X    7  &	 g    7  7  7  7  '  o)    7  �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle8   ��  � �� �� " ��.R��� $ Border��$ 0��$��0q�
������ 
������  . $	 5,0,5,0q�._�F� $
 	Crosshair��$ Uniform=�
�������$��1��+����        � z  z �     z � z     	$��Center=�$��Center=� P�  �@J�IsKeyboardFocused . P�  �@��IsDefaulted . P�  �@J�IsMouseOver . . ��� $ Border��# �   � ��P�  � �� . . ��� $ 	Crosshair�� � ��
 ��Zj�P�  � {� .  �� " ��.R��� $ PART_ContentHost��
������ |�.  $��Hidden=�$��Hidden=��� " d�.R��  �� �� $��24 �.+��� $��2��$��0q����� *
Background+ �� *TemplatedParent+�� $ ArrowBorder��$��1��$��2q�$��0q����� *
Background+ �� *TemplatedParent+._�F� $
 Arrow��#���  $��Center=�$��Center=�"����        � 	=  	= � z     	 P�  �@J�IsMouseOver . . ��� $ ArrowBorder��# �   � ��P�  �@d�	IsChecked$
 trueY�. ��� $ ArrowBorder��# �   � ��P�  � {� .  . ��� # �   � ���� $ Arrow��# �   � ���� "   .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  � ��# �  ��  �@��
CaretBrush# � 	 ��  � ��$ 10����  � ��$ 10����  �@J�	AllowDrop . ��  � �� �� "   .R��� $ Border��$ 0��$	 2q�#��� 
 #���  $��1q�._�� $ 
LayoutGrid�� �� $��* ��� $
��auto �.+��� $ PART_ContentHost��$��0��$��0q��� $ 	Watermark��$��0��$y�	Collapsed=�#���   .  $
��Left=�$��Center=�$ 2,0,0,0q�$	 0.5Q�����  �� *TemplatedParent+$ 	Watermark��� $ PART_ClearButton��$��1��$ Очистить��8��   P�  �@J�IsKeyboardFocused . . ��� $ Border��# �   � ��P�  �@J�IsMouseOver . . ��� $ Border��# �   � ��P�  �@J�IsMouseOver .  . ��� $ PART_ClearButton�� � y�$ 	Collapsed=�P�  � ��$  ��. ��� $ PART_ClearButton�� � y�$ 	Collapsed=��� $ 	Watermark�� � y�$ Visible=�P�  �@��
IsReadOnly . . ��� $ PART_ClearButton�� � y�$ 	Collapsed=�P�  � {� .  . ��� # �   � ���� $ PART_ClearButton�� � y�$ 	Collapsed=��� "   8   �� "  .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��# �  ��  � ��$ 20����  � ��$ 20����  � �� �� "  .R��� $ Border��
�������#���  $��1q�._�� .+�d� $��ToggleButton��#���  |�.  #��� 
 $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite�� .  #��z #��z  #��z��$��5,0,29,0q�$��Center=�$��Stretch=�� $ EditableGrid��$��0,0,24,0q� �� $��* ��� $
��auto �.+��� $! PART_EditableTextBox��$��0��#���  $��Stretch=�$��Center=�|�. #���  #��� 
 $y�Hidden=�## z" ��Z� �� $ 	Watermark��$��0��$y�	Collapsed=�#���   .  $
��Left=�$��Center=�$ 2,0,0,0q�$	 0.3Q�����  �� *TemplatedParent+$ 	Watermark��� $ PART_ClearButton��$��1��$ Очистить��#���   � $��Popup��$��Bottom=�#��z$ % . |�.  $��Slide=�.��� $��DropDown�� . #��z& #��z' .+��� $ DropDownBorder��#���  $��1q�#���  �� $��4,6,4,6q� . .���� ( . $) 	Contained=� P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 95��P�  �@��
IsGrouping . . ���  � �� .  P� $* Popup�� �@�AllowsTransparency . . ��� $ DropDownBorder�� � ��$ 0,2,0,0q�P�  �@��
IsEditable . . ���  � �� .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=��� $ Border��# � 
  � ���� $ ToggleButton��# � 
  � ���� $ ToggleButton�� � ��$ 24���� $ ToggleButton�� � ��$ Right=�P�  �@��Text$  ��. ��� $ PART_ClearButton�� � y�$ 	Collapsed=��� $ 	Watermark�� � y�$ Visible=�P�  �@��
IsEditable .  . ��� $ PART_ClearButton�� � y�$ 	Collapsed=�P�  �@J�IsMouseOver . . ��� $ Border��# �   � ��P�  �@J�IsMouseOver .  . ��� $ PART_ClearButton�� � y�$ 	Collapsed=�P�  � {� .  . ��� # �   � ���� $ PART_EditableTextBox��# �   � ���� $ PART_ClearButton�� � y�$ 	Collapsed=�+ �� "  8   �� "  .���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� #��z��#��z��#��z�� . ._�� , �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $- TopTick��
. �����$��4��$	/ Top=�$��0��$y�	Collapsed=�m� $- 
BottomTick��
. �����$��4��$/ Bottom=�$��2��$y�	Collapsed=��� $ TrackBackground��$��1q�
�������$ 1��$��4��$	��5,0q�$��1��$��Center=�._��� $��-6,-1q�.+��� $0 PART_SelectionRange��#��� ��$��4��#��� ��$��1��$y�Hidden=�]� $1 
PART_Track��$��1��2 �� $��Slider.DecreaseLarge������ " ��.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ 3 �� $��Slider.IncreaseLarge������ " ��.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ 4 n� $5 Thumb������ " n�.���  � |� .  ��  �@�OverridesDefaultStyle . ��  � ��$ 22����  � ��$ 11����  � ��
 �������  � �� �� " n�.R���  . z�T� $	6 5.5Q�$7 11Q�.+�F� $
 
Background��_���������
o�� ���`�_��� 	= `�_��@KL �
o���@KL `�� � 	= �7� �� ����7� �����`�� �	���� $	8 0,1&�$	9 0,0&�.��� $: White��$; 0Q�� $: 	#FFF0EFEF��$	; 0.4Q�� $: 	#FFD6D5D5��$	; 0.8Q�F� $
 InnerBorder��+���� ����
o�� 	= �
o�� 	= `�� � ���`�� 	
�������F� $
 OuterBorder��_���������
o�� ���`�_��� 	= `�_��@KL �
o���@KL `�� � 	= �7� �� ����7� �����`�� �	���	#FF929292 P�  �@J�IsMouseOver . . ��� $ 
Background�� � �� �� $	8 0,1&�$	9 0,0&�.��� $: White��$; 0Q�� $: 	#FFB8E2F9��$	; 0.5Q�� $: 	#FFB0DFF8��$; 1Q��� $ OuterBorder�� � �� �	#FF3C7FB1P�  � ��
 ��  �. ��� $ 
Background�� � �� �� $	8 0,1&�$	9 0,0&�.��� $: White��$; 0Q�� $: 	#FFB8E2F9��$	; 0.5Q�� $: 	#FFB0DFF8��$; 1Q��� $ OuterBorder�� � �� �	#FF3C7FB1P�  �@n�
IsDragging . . ��� $ 
Background�� � �� �� $	8 0,1&�$	9 0,0&�.��� $: 	#FFB8E4FA��$
; 0.25Q�� $: 	#FF5EB4E3��$	; 0.5Q�� $: 	#FF4C8BB4��$; 1Q��� $ OuterBorder�� � �� �	#FF2C628BP�  � {� .  . ��� $ 
Background�� � �� �	#FFF4F4F4�� $ InnerBorder�� Z�  � ���� $ OuterBorder�� � ��+ ������`�_��@KL `�_��@KL �7� ������7� 	�� $ OuterBorder�� � �� �	#FFAEB1AF P�  �@��TickPlacement$ TopLeft=�. ��� $ TopTick�� � y�$ Visible=��� $ Thumb�� � �� �� " n�.���  � |� .  ��  �@�OverridesDefaultStyle . ��  � ��$ 18����  � ��$ 10����  � ��
 �������  � �� �� " n�.R���  . z�V� .~��� $	< 180Q�T� $6 5Q�$7 9Q�.+�F� $
 
Background��W���� �D  �����g5 �L~� � ����L~���U�� ��� ��U�� �D ��^�� �� � �  �� � �D  �D 	
�������F� $
 OuterBorder��W���� �D  �����g5 �L~� � ����L~���U�� ��� ��U�� �D ��^�� �� � �  �� � �D  �D 	
�������$��1�� P�  �@J�IsMouseOver . . ��� $ 
Background��8    � ���� $ OuterBorder��8   � ��P�  �@n�
IsDragging . . ��� $ 
Background��8   � ���� $ OuterBorder��8   � ��P�  � {� .  . ��� $ 
Background�� � �� �	#FFF4F4F4�� $ OuterBorder�� � ��+ ������`�_��@KL `�_��@KL �7� ������7� 	�� $ OuterBorder�� � �� �	#FFAEB1AF�� $ OuterBorder�� � ��= �� �D �L~���U���L~���U�� �D ��^�� �� � �  �� � �D  �D 	�� $ TrackBackground�� � ��$ 5,2,5,0q�P�  �@��TickPlacement$ BottomRight=�. ��� $ 
BottomTick�� � y�$ Visible=��� $ Thumb�� � �� �� " n�.���  � |� .  ��  �@�OverridesDefaultStyle . ��  � ��$ 18����  � ��$ 10����  � ��
 �������  � �� �� " n�.R���  . z�T� $6 5Q�$7 9Q�.+�F� $
 
Background��W���� �D  �����g5 �L~� � ����L~���U�� ��� ��U�� �D ��^�� �� � �  �� � �D  �D 	���� $	8 0,1&�$	9 0,0&�.��� $: White��$; 0Q�� $: 	#FFF0EFEF��$	; 0.4Q�� $: 	#FFD6D5D5��$	; 0.8Q�F� $
 InnerBorder��4�����g5  ���� ��� ���� ��� �D �     z ��g5  �D 	
�������$��1��F� $
 OuterBorder��W���� �D  �����g5 �L~� � ����L~���U�� ��� ��U�� �D ��^�� �� � �  �� � �D  �D 	���	#FF929292$��1�� P�  �@J�IsMouseOver . . ��� $ 
Background�� � �� �� $	8 0,1&�$	9 0,0&�.��� $: White��$; 0Q�� $: 	#FFB8E2F9��$	; 0.5Q�� $: 	#FFB0DFF8��$; 1Q��� $ OuterBorder�� � �� �	#FF3C7FB1P�  � ��
 ��  �. ��� $ 
Background�� � �� �� $	8 0,1&�$	9 0,0&�.��� $: White��$; 0Q�� $: 	#FFB8E2F9��$	; 0.5Q�� $: 	#FFB0DFF8��$; 1Q��� $ OuterBorder�� � �� �	#FF3C7FB1P�  �@n�
IsDragging . . ��� $ 
Background�� � �� �� $	8 0,1&�$	9 0,0&�.��� $: 	#FFB8E4FA��$
; 0.25Q�� $: 	#FF5EB4E3��$	; 0.5Q�� $: 	#FF4C8BB4��$; 1Q��� $ OuterBorder�� � �� �	#FF2C628BP�  � {� .  . ��� $ 
Background�� � �� �	#FFF4F4F4�� $ InnerBorder�� Z�  � ���� $ OuterBorder�� � ��+ ������`�_��@KL `�_��@KL �7� ������7� 	�� $ OuterBorder�� � �� �	#FFAEB1AF�� $ OuterBorder�� � ��= �� �D �L~���U���L~���U�� �D ��^�� �� � �  �� � �D  �D 	�� $ TrackBackground�� � ��$ 5,0,5,2q�P�  �@��TickPlacement$
 Both=�. ��� $ TopTick�� � y�$ Visible=��� $ 
BottomTick�� � y�$ Visible=�P�  �@��IsSelectionRangeEnabled . . ��� $ PART_SelectionRange�� � y�$ Visible=�P�  �@J�IsKeyboardFocused . . ��� $ Thumb�� � ��
 ��  ��� "  8   