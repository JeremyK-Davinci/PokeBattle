   M S B A M L   `   `   `  ���� E  APokeBattle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PokeBattle
PokeBattle      PokeBattle.Pages.GamePage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:PokeBattle       N� Title$  GamePage�� � Triggers :�  :� RoutedEvent$ Page.Loaded��[��� .����  �� TargetProperty$ Opacity�.��W�  g� 	BeginTime 00:00:00 g� Duration$ 00:00:02D� W� From 0	 W� To 1.���  � RowDefinitions �� $��1* ��� $	��200 �.+�� -   	 �Name$	 PreStartDialogWindow��$��2�����	#FF181730
 K� ZIndex$
 1�� �� $��1* ��� $	��200 �.+��� -    ��Name$ SelectPokemonTemplate��$��0��
������ ���� .R��  � Orientation$ Vertical=�$��190, 0, 0, 0q����� .R��� -      SelectPokemonButtonStyles#��[  $��10q�$��Bottom=����	#FF898787$��5q�
������ $	��150��$	��150��
 � Tag ��  �� Path$
 Name���� .+��� $��5, 0, 0, 20q����� $ 
ImageFront���  �� TextAlignment$ Center=�$��Bottom=�$��18(�
��������� $��24(���� $
 Name��� �� $�Type : �� ��   TypeColorTextRun#��[ ��� $ 	Type.Name�
 � Tag �� $ 	Type.Name��� -    ��Name$ ButtonStartGame��$��1��  StartGameButtonStyles#��[ $��Center=�$��Center=�$��Start��$��32(����	#FF898787$��5q�
������ ���	#FFBDBBBB$��25, 10q�${�False��� -   $	 GameStartingWindow��$��2�����	#FF181730$
 1��$y�Hidden=�.+��� -    ��Name$ StartingTextCountdown��  MainPokeFontTextBlock#��[ $��Center=�$��Center=�$	��128(�
�������$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 1Q�   	Direction$	 -90Q�   Color$ 
WhiteSmoke��� -   $	 ExitBattleDialogWindow��$��2�����	#99000000$
 1��$y�Hidden=�.+��� 
����������	#FF898787$��5q� �� CornerRadius$ 25��$��Center=�$��Center=�._�� -   $	 ExitBattleDialogBox��$	��350��$	��150��.+���   PokeFontTextBlock#��[ $��20(�$ Center=��� $�Are you sure���� �� $�you want to leave���� -	   $ ExitBattleDialogConfirm��  DialogButtonStyleLeft#��[ $
��Left=�$��Bottom=�
������ $	��180��$��50��$��-5q����	#FF898787$��5q����� #��[ $��Confirm��$��16(��� -
   $ ExitBattleDialogCancel��  DialogButtonStyleRight#��[ $��Right=�$��Bottom=�
������ $	��180��$��50��$��-5q����	#FF898787$��5q����� #��[ $��Cancel��$��16(�� $��0������  �� ImageSource$% ../Assets/battle_area_grass.png��.+��� -    ��Name$ EnemyIndicator�����	#FF898787$��5q�$ 0, 15, 0, 15�����	#FFF0F0F0$	��Top=�$
��Left=�$��15, 15, 0, 0q�$	��400��._��  �� $��1* ��� $��1* �.+��� -   $ EnemyPokeInfo��$��0��$��20(�#��[ $��0, 0, 0, 10q� �� Padding$ 5q��� ��� $ NickName� �� Mode$ OneWay=��� -   $ EnemyPokeInfoLevel��$��0��$��20(�#��[ $��0, 0, 0, 10q�$ 5q�$ Right=��� $	�Lv.�� �� ��� $ Level�$ OneWay=��� $��1��$��HP��$��20(�#��[ $
��Left=�$��Center=�$��20, 15, 0, 0q�� -    �Name$ EnemyHealth��$��1��  	HealthBar#���  $��Center=�$��Right=�$��10��$	��250�� � Minimum$ 0Q� � Maximum$	 100Q�  � Value$	  100Q�$��0, 12, 10, 0q��� -   $ MyIndicator�����	#FF898787$��5q�$ 15, 0, 15, 0�����	#FFF0F0F0$��Bottom=�$��Right=�$��0, 0, 15, 15q�$	��400��._��  �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� -   $ 
MyPokeInfo��$��0��$��20(�#��[ $��0, 0, 0, 10q�$ 5q��� ��� $ NickName�$ OneWay=��� -   $ MyPokeInfoLevel��$��0��$��20(�#��[ $��0, 0, 0, 10q�$ 5q�$ Right=��� $	�Lv.�� �� ��� $ Level�$ OneWay=��� $��1��$��HP��$��20(�#��[ $
��Left=�$��Center=�$��20, 15, 0, 0q�� -   $ MyHealth��$��1��#��[ $��Center=�$��Right=�$��10��$	��250��$ 0Q�$	 100Q�$	  100Q�$��0, 12, 10, 0q��� -   $ MyHealthText��$��2��$��Center=�$��Center=�$��20(�#��[ $��100, 0, 0, 0q��� -   ! ��Name$! MyCurrentHealthText����� $ 	CurrentHP�$ OneWay=� �� $�/�� �� ��� $ MaxHP�$ OneWay=��� $��3�����	#FF898787$��1q����	#FF898787$ 0, 0, 15, 0��" �� Padding$" 1q�$��0, 0, -3, -2q�._�� .+��� $��Center=�$
��Left=�$
��Exp.��
�������#��[ � -   $ MyExperience��  ExperienceBar#��[ $��Center=�$��Right=�$	��250��$��5��
����  �$ 0Q�$	 100Q�$  0Q�$��0, 0, 15, 0q��� -   # ��Name$# MyPokemonImage��$	��350��$	��350��$��Bottom=�$
��Left=�$��180, 0, 0, -100q��� -   $# EnemyPokemonImage��$	��350��$	��350��$	��Top=�$��Right=�$��175, 100q�� $��1��$ � ColumnDefinitions$ �� $��3* ��� $��2* �.+��� ���	#FF7A7A7A$��
0, 5, 0, 5q�$��2������ % �� RelativeTransform% �� & �� Angle$& 90Q�' �� CenterX$	' 0.5Q�( �� CenterY$	( 0.5Q�.��� ) � Color$) 	#FFB0B0B0��* � Offset$	* 0.3Q�� $) 
WhiteSmoke��$	* 0.4Q�� $) 
WhiteSmoke��$	* 0.6Q�� $) 	#FFB0B0B0��$	* 0.7Q�� $��1��.+��� ���	#FF898787$��5q�$ 15�����	#FFF0F0F0$��15q��� + �� Orientation$+ Vertical=�$��30q�.+��� $+ 
Horizontal=�.+��� -   $ ButtonAttack�� 	 GameButtonStyles#��[	 ���	#FF898787$	��2.5q����	#CCDDDDDD$	��Top=�$
��Left=�$	��200������ $��Center=�$��Center=�$ Center=����	#FF636363�� $��20(�$�Attack���� �� $��16(�$�Select an attack���� -   $ ButtonPokemon��#��[	 ���	#FF898787$	��2.5q����	#CCDDDDDD$	��Top=�$��Right=�$	��200��$��26, 0, 0, 0q�${�False������ $��Center=�$��Center=�$ Center=����	#FF636363�� $��20(�$�Pokemon���� �� $��16(�$ �Select a different pokemon���� $+ 
Horizontal=�$��0, 26, 0, 0q�.+��� -   $ ButtonItems��#��[	 ���	#FF898787$	��2.5q����	#CCDDDDDD$	��Top=�$
��Left=�$	��200��${�False������ $��Center=�$��Center=�$ Center=����	#FF636363�� $��20(�$
�Item���� �� $��16(�$�Select an item to use���� -   $ 	ButtonRun��#��[	 ���	#FF898787$	��2.5q����	#CCDDDDDD$	��Top=�$��Right=�$	��200��$��26, 0, 0, 0q����� $��Center=�$��Center=�$ Center=����	#FF636363�� $��20(�$	�Run���� �� $��16(�$�Run away��� $��0��.+��� ���	#FF898787$��5q�$ 15��
�������$��15q�._�� .+�� -   $	 BattleInfoDisplay��$��5q�.+��� -   $ BattleInfoText��$��20(�#��[ $��WrapWithOverflow=�� -   $	 BattleAttackButtonDisplay��$��5q�$y�Hidden=�.+��� -   $ AttacksTemplate������ .R�� $ Vertical=����� .R��� -    #��[	 ���	#FF898787$	��2.5q����	#CCDDDDDD$	��Top=�$
��Left=�$	��200��$��90, 10, 0, 0q� �� $
 Name�$ OneWay=����� $��Center=�$��Center=�$ Center=����	#FF636363�� $��20(���� $
 Name�$ OneWay=��� �� $��16(�$�Type : �� �� $��16(���� $ 	Type.Name�$ OneWay=�