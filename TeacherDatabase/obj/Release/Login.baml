   M S B A M L   `   `   `  ���� J  FTeacherDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TeacherDatabaseTeacherDatabase  1clr-namespace:TeacherDatabaseTeacherDatabase      TeacherDatabase.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1WpfTestclr-namespace:TeacherDatabase     /localclr-namespace:TeacherDatabase     -     � Title$  LoginWindow��$	��700��$
��1200�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�����  �� ImageSource$ back.jpg��.���  � RowDefinitions �� $��30 ��� $	��120 ��� .+��� -   $��x��$��30��$��30��$��Right=�
������ 
������ 
��������� $��1��$��80��$	��500��$��78,10,614,30q�$��Login 登录��$��50(�
��������� $��1��$
��1100��$��2��
�������
�������$��45,108,47,10q��� $��Right=�$��
0,77,159,0q�$��2��.+�� .+��� -   $
��lab1��$��5,16,-5,-16q�.��请输入账号�� -   $��tbxUser��$	��350��$��40�� J� Opacity$	 0.5Q�$��Center=�$��0 10 0 0q�$��Center=�.��� .+��� -   $
��lab2��$��5,16,-5,-16q�.��请输入密码G� -   $	��pwd��$	 0.5Q�$��Center=�$��Center=�$��Center=�$	��350��$��40��$��0 10 0 0q�$��Italic$�� $��0 15 0 0q�$	��350�� � ColumnDefinitions �� �� .+���  �� Orientation$ 
Horizontal=�$	��350��$��2���� $��25��$��1��$��Center=�$��忘记密码?��$��Right=�
��������� -   $��login��$	 0.8Q�$	��350��$��40��$��0 25 0 0q�
������$��登录��$��20(��� -   $��register��$	 0.8Q�$	��350��$��40��$��0 25 0 0q�
��� ���$��注册��$��20(��� -	   $
��mess��$��25��$��0 5 0 0q�$	��200��