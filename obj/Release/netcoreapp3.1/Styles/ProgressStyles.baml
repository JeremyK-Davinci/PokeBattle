   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ProgressBar.Progress  �� Color  ProgressBar.Background  ProgressBar.Border  	HealthBar �� 
TargetType �� Property �� Value �� 
TargetType �Name'    !System.Windows.VisualStateManager    VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard	 g� RepeatBehavior
 �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value �� CornerRadius ��Name �� RadiusX �� RadiusY J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle  ExperienceBar�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      %�  &	        &	      &	 *     &	 ?     7   7  7  &	 K    7   7  7  �� $  	#FF06B025���� $  	#FFE6E6E6���� $  	#FFBCBCBC���� " �.���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � �� �� " �.R�� $ TemplateRoot��   CommonStates��.   Determinate��  Indeterminate��. �� $	 Forever��.��U� $
 	Animation��$V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�.\�  $ 0��$
 0.25Q�  $ 0:0:1��$
 0.25Q�  $ 0:0:2��$
 0.25Q�*� $
 	Animation��$' !(UIElement.RenderTransformOrigin)�.'�  $ 0��$ -0.5,0.5&�  $ 0:0:1��$ 0.5,0.5&�  $ 0:0:2��$ 1.5,0.5&�.+��� #��z��$ 10��#��z��#��z���� $ 
PART_Track��� $ PART_Indicator��$
}�true��$
��Left=�.+��� $ 	Indicator��#��z��$ 10��$ 10���� $ 	Animation��#��z��$ 0.5,0.5&�$ 10��$ 10��z�V� .~��� �� �� T�  P�  �@�Orientation$ Vertical=�. ��� $ TemplateRoot�� �@�LayoutTransform �� $	 -90Q�P�  �@�IsIndeterminate$
 true��. ��� $ 	Indicator�� � y�$ 	Collapsed=��� " �.���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � �� �� " �.R�� $ TemplateRoot��   CommonStates��.   Determinate��  Indeterminate��. �� $	 Forever��.��U� $
 	Animation��$V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�.\�  $ 0��$
 0.25Q�  $ 0:0:1��$
 0.25Q�  $ 0:0:2��$
 0.25Q�*� $
 	Animation��$' !(UIElement.RenderTransformOrigin)�.'�  $ 0��$ -0.5,0.5&�  $ 0:0:1��$ 0.5,0.5&�  $ 0:0:2��$ 1.5,0.5&�.+��� #��z��$ 2��#��z��#��z���� $ 
PART_Track��� $ PART_Indicator��$
}�true��$
��Left=�.+��� $ 	Indicator��#��z��$ 2��$ 2���� $ 	Animation��#��z��$ 0.5,0.5&�$ 2��$ 2��z�V� .~��� �� �� T�  P�  �@�Orientation$ Vertical=�. ��� $ TemplateRoot�� �@�LayoutTransform �� $	 -90Q�P�  �@�IsIndeterminate$
 true��. ��� $ 	Indicator�� � y�$ 	Collapsed=�