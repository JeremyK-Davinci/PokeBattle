   M S B A M L   `   `   `  ����  
PokeBattle    PokeBattle.Index   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Index��5   	   $	��800��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U    � WindowStyle$
 None=�6k    � AllowsTransparency$
 True��6~   
������  � Icon$ Assets/Icon.ico��6�   .��5      � -   5         �Name$ IndexParentGrid��5   3   
������ .+�5	   
   �� 
���   �$��5q�6%    �� CornerRadius$	 400��69   ._�5
      �  � RowDefinitions 5      �� 5      $��1* �6$   �� 5      $��1* �6$   .+�5      �� $��0��6   
���   �$��
0, 0, 0, 5q�6:   $ 400, 400, 0, 0��6W   ��5      �� 5      	 �� RelativeTransform	 5      �� 5   "   
 �� Angle$	
 180Q�62    �� CenterX$	 0.5Q�6>    �� CenterY$	 0.5Q�6L   .��5      �  � Color$ 	#FF7C0000��6+    � Offset$ 0Q�6=   � 5      $ 	#FFAE0000��6+   $	 0.5Q�6=   � 5      $	 Red��6+   $ 1Q�67   5      5      �� 5      $��1��6   
���   �$��
0, 5, 0, 0q�6:   $ 0, 0, 400, 400��6W   ��5      �� 5      	 5      �� 5   "   $
 0Q�62   $	 0.5Q�6<   $	 0.5Q�6J   .��5!      � $ 
WhiteSmoke��6+   $ 0Q�6>   � 5"      $ 	#FFC1C1C1��6+   $	 0.5Q�6=   � 5#      $ 	#FF8B8B8B��6+   $ 1Q�6=   5$      5&      �� 5'      -   5         ��Name$ ButtonStart��5'   T      StartButtonStyle#��[  6   $��2��6C   $��Start��6i   
�������$��Center=�6�   $��Center=�6�   $	��100��6�   $	��100��6�   $��32(�6�   
���   �$��5q�6   � Triggers 5(      :� 5)       :� RoutedEvent$ Button.MouseEnter��6'   .[�5*      �� .��5+   "   �� -   5         ��Name$ StartButtonHover��5+   -   .��5,   &   �� 	 �� To 	#FF97979765    �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�6D    g� FillBehavior$ HoldEnd=�6�    g� Duration$ 0:0:0.75D�6�   5-   #   5.      5/      :� 50      $ Button.MouseLeave��6'   .[�51      �� .��52   "   �� -   5        $ StartButtonEndHover��52   -   .��53   &   ��  
WhiteSmoke65   $1 +(Button.Background).(SolidColorBrush.Color)�6E   $ HoldEnd=�6�   $ 0:0:0.75D�6�   54   #   55      56      58      59      5:      5;      5<      