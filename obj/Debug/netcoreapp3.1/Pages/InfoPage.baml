   M S B A M L   `   `   `  ����  
PokeBattle    PokeBattle.Pages.InfoPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  InfoPage��5   1    � Triggers 5      :� 5	   
    :� RoutedEvent$ Page.Loaded��6   [�5
      �� 5      .��5      ��  �� TargetProperty$ Opacity�6!   .��5      W�  g� 	BeginTime 00:00:006*    g� Duration$ 00:00:02D�6?    W� From 06S   	 W� To 16\   5      5      5      .��5      � ���	#FF181730.+�5   
   �� $
��Auto=�6   $��Disabled=�6:   .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��Icon Credits��6   $��60(�60   $��Center=�6>   $	��Top=�6[   
�������$��5q�6�   �� 5      -   5        	 ��Name$	 IconCreditsTemplate��5      ��5      �� 5      .R�5      �� $ Vertical=�6)   $��0, 15q�6@   .+�5   "   �� $��40(�6Q   
�������$��Center=�6w   ��6,   �� 
 �� Path$
 CreditReciever�6w   �� 5   "   $��32(�6L   
�������$��Center=�6r   ��6,   �� $
 	CreditFor�6r   �� 5   "   $��32(�6,   
�������$��Center=�6R   �� 5   "   -   5         �� TextDecorations$
 None{�5   t   ��6,   �� $
 
CreditLink�.�6�   .�5    &   �� 
��������6*   �� $
 
CreditLink�6K   5!   #   5"   #   5#      5$      5&      �� 5'      $��Design Credits��6   $��60(�62   $��Center=�6@   $	��Top=�6]   
�������$��5q�6�   �� 5(      -   5        $	 DesignCreditsTemplate��5(      ��5)      �� 5*      .R�5+      �� $ Vertical=�6)   $��0, 15q�6@   .+�5,   "   �� $��40(�6Q   
�������$��Center=�6w   ��6,   �� $
 CreditReciever�6w   �� 5-   "   $��32(�6L   
�������$��Center=�6r   ��6,   �� $
 	CreditFor�6r   �� 5.   "   $��32(�6,   
�������$��Center=�6R   �� 5/   "   -   5        $
 None{�5/   t   ��6,   �� $
 
CreditLink�.�6�   .�50   &   �� 
��������6*   �� $
 
CreditLink�6K   51   #   52   #   53      54      56      �� 57      $��Development Credits��6   $��60(�67   $��Center=�6E   $	��Top=�6b   
�������$��5q�6�   �� 58      -   5        $ 	 DevelopmentCreditsTemplate��58      ��59      �� 5:      .R�5;      �� $ Vertical=�6)   $��0, 15q�6@   .+�5<   "   �� $��40(�6Q   
�������$��Center=�6w   ��6,   �� $
 CreditReciever�6w   �� 5=   "   $��32(�6L   
�������$��Center=�6r   ��6,   �� $
 	CreditFor�6r   �� 5>   "   $��32(�6,   
�������$��Center=�6R   �� 5?   "   -   5        $
 None{�5?   t   ��6,   �� $
 
CreditLink�.�6�   .�5@   &   �� 
��������6*   �� $
 
CreditLink�6K   5A   #   5B   #   5C      5D      5F      �� 5G      -   5         ��Name$ 	Copyright��5G      $��24(�6/   $��Bottom=�6=   $��Center=�6X   
�������$��5, 25, 5, 5q�6�   5H      5I      5J      5K      