   M S B A M L   `   `   `  ����   
PokeBattle    PokeBattle.Index   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Index��$	��800��$	��800�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � Icon$ Assets/Icon.ico��.��� -    �Name$ IndexParentGrid��
������ .+��� 
���   �$��5q� �� CornerRadius$	 400��._��  � RowDefinitions �� $��1* ��� $��1* �.+��� $��0��
���   �$��
0, 0, 0, 5q�$ 400, 400, 0, 0������ 	 �� RelativeTransform	 �� 
 �� Angle$	
 180Q� �� CenterX$	 0.5Q� �� CenterY$	 0.5Q�.���  � Color$ 	#FF7C0000�� � Offset$ 0Q�� $ 	#FFAE0000��$	 0.5Q�� $	 Red��$ 1Q��� $��1��
���   �$��
0, 5, 0, 0q�$ 0, 0, 400, 400������ 	 �� $
 0Q�$	 0.5Q�$	 0.5Q�.��� $ 
WhiteSmoke��$ 0Q�� $ 	#FFC1C1C1��$	 0.5Q�� $ 	#FF8B8B8B��$ 1Q��� -    ��Name$ ButtonStart��   StartButtonStyle#��[  $��2��$��Start��
�������$��Center=�$��Center=�$	��100��$	��100��$��32(�
���   �$��5q� � Triggers :�  :� RoutedEvent$ Button.MouseEnter��.[��� .���� -    ��Name$ StartButtonHover��.���� 	 �� To 	#FF979797 �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)� g� FillBehavior$ HoldEnd=� g� Duration$ 0:0:0.75D�:� $ Button.MouseLeave��.[��� .���� -   $ StartButtonEndHover��.����  
WhiteSmoke$1 +(Button.Background).(SolidColorBrush.Color)�$ HoldEnd=�$ 0:0:0.75D�