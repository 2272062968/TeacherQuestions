   M S B A M L   `   `   `  ����J  FTeacherDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TeacherDatabaseTeacherDatabase  5   	       TeacherDatabase.Alter   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TeacherDatabase     5   	   ���	#FFE4FFD7  � Title$  Alter��5	   	   $	��625��6   $
��1010��6$    � 	Resources 5
         DownArrowGeometry   ComboBoxReadonlyToggleButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels F�Name	 �� Triggers
 P� Property P� Value �� 
TargetName  CboCommomStyle �Name � ColumnDefinitions �Name � AllowsTransparency �� RelativeSource �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation d� 	IsChecked �� Mode �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat J� IsHitTestVisible��%e  &	        &	 -     7   &	 �    7  �5   
   M 0 0 L 3.5 4 L 7 0 Z�6D   �� 5   
   " d�65   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� .  6*   �� 5       � |� .  6*   �� 5       �@��	ClickMode$ Press=�6*   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $ Chrome��6U   #��z��6!   #��z��6f   #��z��6�    . ._�5      � $��Right=�6#   #��� r�6?   .+�5   "   F� $ Arrow��6'   8��  ���#808080$��Center=�6o   $��1,1,0,0q�6�   $��Center=�6�   5      5      	 5      P� 5      
 � {� .  . �5   "   �� $ Arrow��69    � �� �#AFAFAF6L   5      5      5       5!      �� 5"   
   " ��6'   .�5#      ��  � ��$ 0q�60   �� 5$       � �� 5%      �� 5&      " ��6&   .R�5'      � $ MainGrid��6    . $��1q�6L    5(      �� 5)   "   $��* �63   �� 5*   "   #��� r�63   $��0 �6�   .+�5,      � $ 
PART_Popup��6$    . $��2��6R   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6f   �� *IsDropDownOpen+ �� *TemplatedParent+.��5-   "   �� $
 Shdw��6)   #��z 67   ��6g   �� *ActualWidth+$ MainGrid��._�5.   &   �� $ DropDownBorder��6-   #��� ��6E   $��1q�6�   #��� ��6�   ._�5/   *   �� $ DropDownScrollViewer��67   .��50   .   � $ Enabled=�63   .+�51   2   �� $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�52   6   �� $ 
OpaqueRect��6@   ��6T   �� *
Background+$ DropDownBorder����6�   �� *ActualHeight+$ DropDownBorder����6�   �� *ActualWidth+$ DropDownBorder��53   3   �� 54   2   $ ItemsPresenter��6A   $ 	Contained=�6Y   # z 6�   55   /   56   +   57   '   58   #   59      d� 5:      #��z��6+   #��z��6W   $��2��6�   $��0��5;   '   8��  #��z��5<   �    6'   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+6�   �� 5=      $��0��6/   $��Center=�6?   $��Center=�6Z   #��z 6w   #��z��6�   #��z 6�   # z 6"   .  #��z��6�  # z 6�  5>      5?      5A      5B      5C      .��5D      � $��Stretch=�6   $��Stretch=�6)     � RowDefinitions  5F   
   �� 5G      $��50 �6   6*   �� 5H      $��50 �6   6*   �� 5I      $��50 �6   6*   �� 5J      6   �� 5K      6   �� 5L      6   �� 5M      6   �� 5N      $��80 �6   6*   .+�5Q   
   �� $��0��6   ! �� Orientation$! 
Horizontal=�6#   $
��Left=�6<   $	��792��6W   $��50��6c   $	��Top=�6o   .+�5R      �� $��科目*��6   $
��Auto��6#   $��40 0 0 0q�60   $��Center=�6B   �� 5S      -   5        $��Xtype��5S   F   $��40 0 0 0q�64   $	��350��6S   $��25��6_   $��Center=�6k   ��6   �� " �� Path$" subject�6�   5T      �� 5U   
   $��1��6   $! 
Horizontal=�6"   $
��Left=�6;   $	��792��6V   $��50��6b   $	��Top=�6n   .+�5V      �� $��题型*��6   $
��Auto��6#   $��40 0 0 0q�60   $��Center=�6B   �� 5W      -   5        $��selectXtype��5W      $	��300��6D   $��25��6P   $��40 0 0 0q�6\   ��6)   �� $
" type�6p   5X      �� 5Y   
   $��2��6   $! 
Horizontal=�6"   $��Center=�6;   .+�5Z      �� $��章节��6   $��30��6"   $��40 0 0 0q�6-   $��Center=�6?   �� 5[      -   5        $��
tbxChapter��5[      $��40 0 0 0q�6F   $	��350��6X   $��25��6d   $��Center=�6p   ��6(   �� $" chapter�6�   5\      �� 5]   
   $��3��6   $! 
Horizontal=�6"   .+�5^      �� $��题目*��6   $��30��6#   $��40 0 0 0q�6/   $	��Top=�6A   �� 5_      -   5        $��tbxQuestion��5_   "   $	��800��6   # �� TextWrapping$
# Wrap=�6P   $ �� AcceptsReturn$ . "% �� VerticalScrollBarVisibility$% Visible=�6y   $��40,0,0,5q�6�   ��65   �� $
" name�6�   5`      �� 5b   
   $��4��6   $! 
Horizontal=�6#   .+�5c      �� $��30��6   $��答案��6#   $��40 0 0 0q�6.   $	��Top=�6@   � 5d      6   �� 5e      -   5        $��	tbxAnswer��5e   �   $��40,0,0,0q�6   $
# Wrap=�6E   $ . $% Visible=�6n   $	��800��6�   ��6(   �� $" answer�6�   5f      �� 5g   
   $��5��6   $! 
Horizontal=�6"   .+�5h      �� $��难度��6   $��40 0 0 0q�6"   $
��Auto��64   $��Center=�6A   $��Center=�6^   �� 5i      $	��200��6   $��Center=�6B   $��40 0 0 0q�6]   $��26��6o   ��6"   �� $" 	diffculty�6}   5m      �� 5n   
   $��	0 -40 0 0q�6   $��6��6(   $! 
Horizontal=�65   .+�5o      �� $��	出题人��6   $
��Auto��6#   $��40 0 0 0q�60   $��Center=�6B   �� 5p      -   5        $��tbxIssueAnthor��5p   3   $��23��6I   $	��200��6U   $��30,0,0,0q�6b   ��6   �� $" anthor�6v   5q      � 5r   
   $��7��6    5s      �� 5t      6%   �� 5u      6%   .+�5x      �� -   5        $��isShare��5x   I   {�.  & J� Opacity$	& 0.5Q�6)   $ FalseY�67   $	��200��6X   $��30��6d   $��40 0 0 0q�6p   $
��Left=�6�   $	��Top=�6�   .��6�   共享题目6�   �� 5y      -   5        $	��del��5y      {�.  $��Right=�6G   $��0,20,150,35q�6c   $	��100��6x   $��1��6�   $��25��6�   ���	#FFF43333
�������.��6�   删除6�   �� 5z      -	   5        $
��save��5z   (   {�.  $��Right=�6E   $��
0,20,18,35q�6a   $	��100��6u   $��1��6�   $��25��6�   ���	#FF91F432
�������.��6�   保存6�   5{      5~      5      