   M S B A M L   `   `   `  ���� J  FTeacherDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TeacherDatabaseTeacherDatabase       TeacherDatabase.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     C ?Fluent, Version=6.1.0.326, Culture=neutral, PublicKeyToken=nullFluenturn:fluent-ribbon  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  )localclr-namespace:TeacherDatabase  -   ���#2b3643
�������  � Title$  教师题库管理系统��$	��700��$
��1200�� � WindowStartupLocation$ CenterScreen=� � 	Resources    DownArrowGeometry   ComboBoxReadonlyToggleButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels	 F�Name
 �� Triggers P� Property P� Value �� 
TargetName  CboCommomStyle �Name � ColumnDefinitions �Name � AllowsTransparency �� RelativeSource �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation d� 	IsChecked �� Mode �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat  J� IsHitTestVisible! ��Name��%�  &	        &	      7   &	 �    7  '��     �M 0 0 L 3.5 4 L 7 0 Z��� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ Chrome��#��z��#��z��#��z�� . ._�� $��Right=�#��� r�.+�F� $	 Arrow��8��  ���#808080$��Center=�$��1,1,0,0q�$��Center=�
 P�  � {� .  . ��� $ Arrow�� � �� �#AFAFAF�� " ��.���  � ��$ 0q���  � �� �� " ��.R�� $ MainGrid�� . $��1q� �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+ �� *TemplatedParent+.���� $
 Shdw��#��z ���� *ActualWidth+$ MainGrid��._��� $ DropDownBorder��#��� ��$��1q�#��� ��._��� $ DropDownScrollViewer��.��� $ Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $ 
OpaqueRect������ *
Background+$ DropDownBorder������ *ActualHeight+$ DropDownBorder������ *ActualWidth+$ DropDownBorder���� $ ItemsPresenter��$ 	Contained=�# z d� #��z��#��z��$��2��$��0��8��  #��z�� �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $��0��$��Center=�$��Center=�#��z #��z��#��z # z   .  #��z��# z �� " ��.���  � �� �� " ��.R�� .+��� $��Border�����#3d4957
���   �$��0,0.5,0,0  q�._��� $! ContentSite��$��Center=�$��Center=�$��Header��$��	12,2,12,2q�
 P�  �@��
IsSelected . . ��� $ Border�� � �� �#1caf9aP�  �@��
IsSelected .  . ��� $ Border�� � �� �#364150.��� " � RowDefinitions" �� $��25 ��� $	��10* �.+�� $��0�����#2b3643 �� $��3* ��� $��* �.+��� # �� Orientation$# 
Horizontal=�.+��� -   $��labNtype��$��20 0 0 0q�$��Center=�$��25��
�������.��试题类型�� -   $ ��Name$$ Ntype��
�������#��[ $��Center=�$	��200��$��25��.@��� % �� 
IsSelected% . $��全部类型���� -   $��	showShare��$
 TrueY�$��20 0 0 0q�$��查看共享试题��
�������$��Center=��� $	��Top=�$��1��$��Right=�$# 
Horizontal=�.+��� 
�������$��Right=�$��Center=�.��当前登录用户:�� -   $��account��
�������$��Center=�.��XXXX�� -   $��0 0 5  0q�$��25��
���������Z� .��退出登录� $��2�����#364150�� -   & ��Name$& 
tabControl��
����ح�' �� TabStripPlacement$
' Left=�$��2��.@��� -   $��questionAdmin��$y�Visible=�
����������#364150$��40��.���� $
��Auto=����� $# 
Horizontal=�.+��� $��
ico\n1.ico��$��26��$��26��{�.  �� 
�������$��1��$��Center=�{�.  .��试题管理�� -	   $��questionEntry��
����������#364150$��40������ $# 
Horizontal=�.+��� $��
ico\n2.ico��$��26��$��26���� 
�������$��1��$��Center=�.��试题录入�� -
   $��questionExam��
�������$��40�����#364150���� $# 
Horizontal=�.+��� $��
ico\n3.ico��$��26��$��26���� 
�������$��1��$��Center=�.��生成试卷�� -   $��questionAlter��
�������$��40�����#364150���� $# 
Horizontal=�.+��� $��
ico\n4.ico��$��26��$��26���� 
�������$��1��$��Center=�.��控制中心