   M S B A M L   `   `   `  ����   TeacherDatabase'    !TeacherDatabase.UserQuestionEntry   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    >d2http://schemas.microsoft.com/expression/blend/2008    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     
���   �  � 	Resources     DownArrowGeometry   ComboBoxReadonlyToggleButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels F�Name �� Triggers	 P� Property
 P� Value �� 
TargetName  CboCommomStyle �Name � ColumnDefinitions �Name � AllowsTransparency �� RelativeSource �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation d� 	IsChecked �� Mode �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat J� IsHitTestVisible��%B  &	        &	      7   &	 �    7  �M 0 0 L 3.5 4 L 7 0 Z��� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ Chrome��#��z��#��z��#��z�� . ._�� $��Right=�#��� r�.+�F� $ Arrow��8��  ���#808080$��Center=�$��1,1,0,0q�$��Center=� P� 	 � {�
 .  . ��� $ Arrow�� � �� �#AFAFAF�� " ��.���  � ��$ 0q���  � �� �� " ��.R�� $ MainGrid�� . $��1q� �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+ �� *TemplatedParent+.���� $
 Shdw��#��z ���� *ActualWidth+$ MainGrid��._��� $ DropDownBorder��#��� ��$��1q�#��� ��._��� $ DropDownScrollViewer��.��� $ Enabled=�.+��� $
��Left=�$��0��$	��Top=�$��0��.+��� $ 
OpaqueRect������ *
Background+$ DropDownBorder������ *ActualHeight+$ DropDownBorder������ *ActualWidth+$ DropDownBorder���� $ ItemsPresenter��$ 	Contained=�# z d� #��z��#��z��$��2��$��0��8��  #��z�� �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $��0��$��Center=�$��Center=�#��z #��z��#��z # z  .  #��z��# z .��� $��Stretch=�$��Stretch=� � RowDefinitions �� $��50 ��� $��50 ��� $��50 ��� �� �� $	��100 ��� $��80 �.+��� $��0��  �� Orientation$  
Horizontal=�$
��Left=�$	��792��$��50��$	��Top=�.+��� $��科目*��$
��Auto��$��40 0 0 0q�$��Center=��� -   $��addType��#��[ 
�������$
��40,0q�$	��150��$��25���� $��新建其他科目��$��Center=��� -   $��Xtype��$	��350��$��25��$��Center=��� $��1��$  
Horizontal=�$
��Left=�$	��792��$��50��$	��Top=�.+��� $��题型*��$
��Auto��$��40 0 0 0q�$��Center=�	� -   $��choice��$��40 0 0 0q�$��Center=�$��	选择题��! 	� 	GroupName$
! type��	� -   $��judge��$��20 0 0 0q�$��Center=�$��	判断题��$
! type��	� -   $��	fillBlank��$��20 0 0 0q�$��Center=�$��	填空题��$
! type��	� -   $��design��$��20 0 0 0q�$��Center=�$��	设计题��$
! type���� $��自定义其他题型��$��20��$��20 0 0 0q�$��Center=�$��Center=��� -   $��selectXtype��$	��300��$��25��$��20 0 0 0q��� $��2��$  
Horizontal=�$��Center=�.+��� $��章节��$��30��$��40 0 0 0q�$��Center=��� -   $��
tbxChapter��$��40 0 0 0q�$	��350��$��25��$��Center=��� $��3��$  
Horizontal=�.+��� $��题目*��$��30��$��40 0 0 0q�$	��Top=��� -	   $��tbxQuestion��$	��800��" �� TextWrapping$
" Wrap=�# �� AcceptsReturn# . "$ �� VerticalScrollBarVisibility$$ Visible=�$��40,0,0,5q��� $��4��$  
Horizontal=�.+��� $��30��$��答案��$��40 0 0 0q�$	��Top=�� �� -
   $��	tbxAnswer��$��40,0,0,0q�$
" Wrap=�# . $$ Visible=�$	��800���� $��5��$  
Horizontal=�.+��� $��难度��$��40 0 0 0q�$
��Auto��$��Center=�$��Center=�	� -   $��C��$��40 0 0 0q�$��Center=�$��简单��$! 
difficulty��	� -   $��B��$��20 0 0 0q�$��Center=�$��一般��$! 
difficulty��	� -   $��A��$��20 0 0 0q�$��Center=�$��较难��$! 
difficulty��� $��6�� �� �� .+��� $��	0 -40 0 0q�$��0��$  
Horizontal=�.+��� $��	出题人��$
��Auto��$��40 0 0 0q�$��Center=��� -   $��tbxIssueAnthor��$��23��$	��200��$�� ��$��30,0,0,0q��� -   $��isShare��$ FalseY�$��40 0 0 0q�$��Center=�.��共享题目�� -   $��Right=�$��0,20,150,35q�$	��100��$��1��$��25�����	#FFF43333
�������.��重置内容�� -   $��Right=�$��
0,20,18,35q�$	��100��$��1��$��25�����	#FF91F432
�������.��开始执行