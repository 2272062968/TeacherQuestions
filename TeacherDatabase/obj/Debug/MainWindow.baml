   M S B A M L   `   `   `  ����J  FTeacherDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TeacherDatabaseTeacherDatabase  5   	        TeacherDatabase.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   C ?Fluent, Version=6.1.0.326, Culture=neutral, PublicKeyToken=nullFluenturn:fluent-ribbon  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   )localclr-namespace:TeacherDatabase  5   	   -   5        ���#2b3643
�������  � Title$  教师题库管理系统��5   	   $	��700��6   $
��1200��6'    � WindowStartupLocation$ CenterScreen=�5   
    � 	Resources 5         DownArrowGeometry   ComboBoxReadonlyToggleButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels	 F�Name
 �� Triggers P� Property P� Value �� 
TargetName  CboCommomStyle �Name � ColumnDefinitions �Name � AllowsTransparency �� RelativeSource �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation d� 	IsChecked �� Mode �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat  J� IsHitTestVisible! ��Name��%�
  &	        &	 -     7   &	 �    7  '�� ?    �5   
   M 0 0 L 3.5 4 L 7 0 Z�6D   �� 5   
   " d�65   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� .  6*   �� 5       � |� .  6*   �� 5       �@��	ClickMode$ Press=�6*   �� 5       � �� 5       �� 5!      " d�6&   .R�5"      �� $ Chrome��6U   #��z��6!   #��z��6f   #��z��6�    . ._�5#      � $��Right=�6#   #��� r�6?   .+�5$   "   F� $	 Arrow��6'   8��  ���#808080$��Center=�6o   $��1,1,0,0q�6�   $��Center=�6�   5%      5&      
 5'      P� 5(       � {� .  . �5)   "   �� $ Arrow��69    � �� �#AFAFAF6L   5*      5,      5.      5/      �� 50   
   " ��6'   .�51      ��  � ��$ 0q�60   �� 52       � �� 53      �� 54      " ��6&   .R�55      � $ MainGrid��6    . $��1q�6L    56      �� 57   "   $��* �63   �� 58   "   #��� r�63   $��0 �6�   .+�5:      � $ 
PART_Popup��6$    . $��2��6R   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6f   �� *IsDropDownOpen+ �� *TemplatedParent+.��5;   "   �� $
 Shdw��6)   #��z 67   ��6g   �� *ActualWidth+$ MainGrid��._�5<   &   �� $ DropDownBorder��6-   #��� ��6E   $��1q�6�   #��� ��6�   ._�5=   *   �� $ DropDownScrollViewer��67   .��5>   .   � $ Enabled=�63   .+�5?   2   �� $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5@   6   �� $ 
OpaqueRect��6@   ��6T   �� *
Background+$ DropDownBorder����6�   �� *ActualHeight+$ DropDownBorder����6�   �� *ActualWidth+$ DropDownBorder��5A   3   �� 5B   2   $ ItemsPresenter��6A   $ 	Contained=�6Y   # z 6�   5C   /   5D   +   5E   '   5F   #   5G      d� 5H      #��z��6+   #��z��6W   $��2��6�   $��0��5I   '   8��  #��z��5J   �    6'   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+6�   �� 5K      $��0��6/   $��Center=�6?   $��Center=�6Z   #��z 6w   #��z��6�   #��z 6�   # z 6"    .  #��z��6�  # z 6�  5L      5M      5O      5P      �� 5R   
   " ��6   .�5S      ��  � �� 5T      �� 5U      " ��6&   .R�5V      � .+�5W      �� $��Border��6%   ���#3d4957
���   �$��0,0.5,0,0  q�6\   ._�5X   "   �� $! ContentSite��63   $��Center=�6H   $��Center=�6c   $��Header��6�   $��	12,2,12,2q�6�   5Y      5Z      
 5[      P� 5\       �@��
IsSelected . . �5]   "   �� $ Border��6)    � �� �#1caf9a6S   5^      P� 5_       �@��
IsSelected .  . �5`   "   �� $ Border��6)    � �� �#3641506S   5a      5c      5e      5f      5i      .��5j      � " � RowDefinitions" 5k   
   �� 5l      $��25 �6   6*   �� 5m      $	��10* �6   6+   .+�5�   
   � $��0��6   ���#2b3643 5�      �� 5�      $��3* �6#   60   �� 5�      $��* �6#   6/   .+�5�      �� # �� Orientation$# 
Horizontal=�6   .+�5�      �� -   5        $��labNtype��5�      $��20 0 0 0q�6(   $��Center=�6:   $��25��6W   
�������.��6v   试题类型6|   �� 5�      -   5        $ ��Name$$ Ntype��5�      
�������#��[ 6=   $��Center=�5�      $	��200��68   $��25��6D   .@�5�      �� % �� 
IsSelected% . $��全部类型��65   5�      �� 5�      -   5        $��	showShare��5�      $
 TrueY�6,   $��20 0 0 0q�6=   $��查看共享试题��6O   
�������$��Center=�6s   6�   5�      �� 5�      $	��Top=�6   $��1��61   $��Right=�6A   $# 
Horizontal=�6]   .+�5�      �� 
�������$��Right=�6+   $��Center=�6G   .��6c   当前登录用户:6l   �� 5�      -   5        $��account��5�   F   
�������$��Center=�6+   .��6U   XXXX6[   �� 5�      -   5        $��0 0 5  0q�5�      $��25��6+   
���������6]   Z� .��6s   退出登录6y   5�      5�      � 5�   
   $��2��6   ���#36415063   �� 5�   
   -   5        & ��Name$& 
tabControl��5�   ,   
����ح�' �� TabStripPlacement$
' Left=�6@   $��2��6Y   .@�5�      �� -   5        $��questionAdmin��5�   a   $y�Visible=�6   
����������#364150$��40��6U   .��5�      �� $
��Auto=�6   5�      ��5�      �� 5�      $# 
Horizontal=�6!   .+�5�      �� $��
ico\n1.ico��6    $��26��64   $��26��6?   {�.  6K   �� 5�      
�������$��1��67   $��Center=�6G   {�.  .��6t   试题管理6z   5�      5�      �� 5�      -	   5        $��questionEntry��5�   ?   
����������#364150$��40��6T   ��5�      �� 5�      $# 
Horizontal=�6!   .+�5�      �� $��
ico\n2.ico��6    $��26��64   $��26��6?   �� 5�      
�������$��1��63   $��Center=�6D   .��6_   试题录入6e   5�      5�      �� 5�      -
   5        $��questionExam��5�   5   
�������$��40��6)   ���#364150��5�      �� 5�      $# 
Horizontal=�6!   .+�5�      �� $��
ico\n3.ico��6!   $��26��65   $��26��6@   �� 5�      
�������$��1��63   $��Center=�6C   .��6^   生成试卷6d   5�      5�      �� 5�      -   5        $��questionAlter��5�   5   
�������$��40��6)   ���#364150��5�      �� 5�      $# 
Horizontal=�6!   .+�5�      �� $��
ico\n4.ico��6    $��26��64   $��26��6?   �� 5�      
�������$��1��63   $��Center=�6C   .��6^   控制中心6d   5�      5�      5�      5�      5�      