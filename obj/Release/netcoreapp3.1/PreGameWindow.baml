   M S B A M L   `   `   `  ����   
PokeBattle    PokeBattle.PreGameWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  PreGameWindow��$	��720��$
��1280�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������ 
������  � Icon$ Assets/Icon.ico�� � 	Resources    TextFontStyle �� 
TargetType �� Property	 �� Value  ToggleActive
 �� ImageSource  ToggleButtonStyle �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%r  &	        &	 m     &	 �     7  7  �� " ��.���  � ��$	 Center=���  � ��$
	 Left=���  � ��
	 �������  � ��$	 20(��� $
 Assets/Light/close.png���� " d�.���  � ��	 �� " d�.R��� $ border��#��z��#��z��$
 True�� P�  �@d�	IsChecked$
 TrueY�. ��� $ border��8	    � ���� $ border��8	   � ��.��� -    �Name$ IndexParentGrid��.+�� ���	#FF181730.+��  � ColumnDefinitions �� $��65 ��� $��* �.+�� -   $ OverlayObject�����	#66000000$��1��$y�Hidden=� K� ZIndex$ 1��� -   $ PageContainer��$��1��.+� � -     �Name$ 	PageFrame��  � NavigationUIVisibility$ Hidden=�� -   $ IndexNavPanel��$
��Left=�$��65�����	#FF232246.+��� -    ��Name$ IndexNavStack��.+�� $��90��.+��� $��0��$��73, -20, 0, 0q�$
��Menu��$��Medium&�
�������$��22(�
������ $
��Left=�$��Center=�#��[   J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 1Q�   	Direction$	 -90Q�   Color$ 
WhiteSmoke��d� -    d�Name$ IndexNavToggle��$��0��$��Center=�$
��Left=�$��18, -20, 0, 0q�$��30��$��30��$��0q�#��[ ���� $
 Assets/Light/menu.png�� j� Stretch$ Uniform=� � Triggers :�   :� RoutedEvent$  ToggleButton.Unchecked��.[��� .���� -   ! ��Name$! HideNavStack��.��W� " �� 
TargetName$" IndexNavPanel��# �� TargetProperty$# Width�$ g� 	BeginTime	$ 0:0:0% W� From% 250	& W� To& 65' g� Duration$' 0:0:0.2D�:� $  ToggleButton.Checked��.[��� .���� -	   $! ShowNavStack��.��W� $" IndexNavPanel��$# Width�	$ 0:0:0% 65& 250$' 0:0:0.2D��� -
   ( ��Name$( IndexNavList��
������ 
������ $��0q�$��Disabled=�.@��� -   $
��Left=�$��0,0,0,15q�.���� ) �� Orientation$) 
Horizontal=�$	��250��.+��� $��Assets/Light/play.png��$��12,0,0,0q�$��32���� $
��Play��$��25,0,0,0q�#��[  �� -   $
��Left=�$��0,0,0,15q�.���� $) 
Horizontal=�$	��250��.+��� $��Assets/Light/settings.png��$��12,0,0,0q�$��32���� $��Settings��$��25,0,0,0q�#��[  �� -   $
��Left=�$��
0,383,0,15q�.���� $) 
Horizontal=�$	��250��.+��� $��Assets/Light/info.png��$��13,0,0,0q�$��32���� $
��Info��$��25,0,0,0q�#��[  �� -   $
��Left=�$��0,0,0,15q�.���� $) 
Horizontal=�$	��250��.+��� $��Assets/Light/power.png��$��13,0,0,0q�$��32���� $��ShutDown��$��25,0,0,0q�#��[  ���� " ��.���  � ��	 �� " ��.R��� $ 	LVIBorder��$��50��#��z��#��z��#��z��$
 True��._��� #��z��# z #��z�� ]� * ]� 
Conditions* �� + �� Property+ �@J�IsMouseOver, �� Value$
, True��./��� $ 	LVIBorder�� � ��	 �	#FF181730�� $ 	LVIBorder�� � ��	 �	#FF181730�� $ 	LVIBorder�� � ��$	 2q�