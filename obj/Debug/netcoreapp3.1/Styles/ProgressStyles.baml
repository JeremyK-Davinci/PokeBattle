   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ProgressBar.Progress  �� Color  ProgressBar.Background  ProgressBar.Border  	HealthBar �� 
TargetType �� Property �� Value �� 
TargetType �Name'    !System.Windows.VisualStateManager    VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard	 g� RepeatBehavior
 �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value �� CornerRadius ��Name �� RadiusX �� RadiusY J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle  ExperienceBar�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      6W   %�  &	        &	 #     &	 F     &	 i     7   7  7  &	 T    7   7  7  �� 5      $  	#FF06B025��63   �� 5      $  	#FFE6E6E6��65   �� 5      $  	#FFBCBCBC��61   �� 5      " �6   .�5   
   ��  � ��8   6'   �� 5   
    � ��8  6'   �� 5	   
    � ��8  6(   �� 5
   
    � ��$ 1q�6,   �� 5   
    � �� 5      �� 5      " �6"   .R�5      � $ TemplateRoot��6    5        5      CommonStates��. 5   "     Determinate��6.     5   "   Indeterminate��. 5   &   �� $	 Forever��61   .��5   *   U� $
 	Animation��6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6j   .\�5   .     $ 0��6C   $
 0.25Q�6O     5   .   $ 0:0:1��6C   $
 0.25Q�6S     5   .   $ 0:0:2��6C   $
 0.25Q�6S   5   +   *� 5   *   $
 	Animation��6G   $' !(UIElement.RenderTransformOrigin)�6i   .'�5   .     $ 0��6B   $ -0.5,0.5&�6N     5   .   $ 0:0:1��6B   $ 0.5,0.5&�6R     5   .   $ 0:0:2��6B   $ 1.5,0.5&�6R   5   +   5   '   5   #   5       .+�5"      �� #��z��6!   $ 10��6K   #��z��6]   #��z��6�   �� 5#      $ 
PART_Track��6$   � 5$      $ PART_Indicator��6   $
}�true��67   $
��Left=�6K   .+�5%      �� $ 	Indicator��6(   #��z��6;   $ 10��6_   $ 10��6l   �� 5&      $ 	Animation��6(   #��z��6;   $ 0.5,0.5&�6_   $ 10��6   $ 10��6�   z�5'   "   V� 5(   &   .~�5)   *   �� �� 5*   *   �� 5+   *   T� 5,   *   5-   '   5/      50      51       52      P� 53       �@�Orientation$ Vertical=�69   . �54      �� $ TemplateRoot��6@    �@�LayoutTransform 55   "   �� 56   &   $	 -90Q�66   58      59      P� 5:       �@�IsIndeterminate$
 true��6=   . �5;      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5<      5>      5@      5A      �� 5B      " �6"   .�5C   
   ��  � ��8   6'   �� 5D   
    � ��8  6'   �� 5E   
    � ��8  6(   �� 5F   
    � ��$ 1q�6,   �� 5G   
    � �� 5H      �� 5I      " �6"   .R�5J      � $ TemplateRoot��6    5K        5L      CommonStates��. 5M   "     Determinate��6.     5N   "   Indeterminate��. 5O   &   �� $	 Forever��61   .��5P   *   U� $
 	Animation��6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6j   .\�5Q   .     $ 0��6C   $
 0.25Q�6O     5R   .   $ 0:0:1��6C   $
 0.25Q�6S     5S   .   $ 0:0:2��6C   $
 0.25Q�6S   5T   +   *� 5U   *   $
 	Animation��6G   $' !(UIElement.RenderTransformOrigin)�6i   .'�5V   .     $ 0��6B   $ -0.5,0.5&�6N     5W   .   $ 0:0:1��6B   $ 0.5,0.5&�6R     5X   .   $ 0:0:2��6B   $ 1.5,0.5&�6R   5Y   +   5Z   '   5[   #   5\      .+�5^      �� #��z��6!   $ 2��6K   #��z��6\   #��z��6�   �� 5_      $ 
PART_Track��6$   � 5`      $ PART_Indicator��6   $
}�true��67   $
��Left=�6K   .+�5a      �� $ 	Indicator��6(   #��z��6;   $ 2��6_   $ 2��6k   �� 5b      $ 	Animation��6(   #��z��6;   $ 0.5,0.5&�6_   $ 2��6   $ 2��6�   z�5c   "   V� 5d   &   .~�5e   *   �� �� 5f   *   �� 5g   *   T� 5h   *   5i   '   5k      5l      5m       5n      P� 5o       �@�Orientation$ Vertical=�69   . �5p      �� $ TemplateRoot��6@    �@�LayoutTransform 5q   "   �� 5r   &   $	 -90Q�66   5t      5u      P� 5v       �@�IsIndeterminate$
 true��6=   . �5w      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5x      5z      5|      5}      5~      