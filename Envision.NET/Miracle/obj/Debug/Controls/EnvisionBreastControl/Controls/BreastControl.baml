   M S B A M L   `   `   `  ����B  >Miracle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:EnvisionBreastControlEnvisionBreastControl  5      )    #EnvisionBreastControl.BreastControl   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      3local#clr-namespace:EnvisionBreastControl    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   !   EnvisionBreastControl.Ruler  -   5          Name$ HorizontalRuler��5      $��1��6/      AutoSize . $
��auto��5         Unit$ Cm=�5         Length$ 14Q�5      }�.    Marks$
 Down=�5         Zoom$ 1Q�5        5   
   -   5        $ VerticalRuler��5      $��0��6-   $��1��6=    . $
��auto��5      $ Cm=�5      $ 14Q�5      }�. $ Up=�5      $ 1Q�5       � LayoutTransform 5!      V� 5"      .~�5#      �� 	 �� ScaleX$	 1Q�6%   
 �� ScaleY$
 1Q�5$   %   �� 5%       �� AngleX$ 0Q�6$    �� AngleY$ 0Q�5&   $   �� 5'       �� Angle$ 90Q�6&   5)      5+      � 5,   
   $��1��6   $��1��6    
�������.+�5.      �� -   5         ��Name$ c1��5.      
�������$	��250��64   $	��250��6@   $	��0,0q�5/   A   $	��Top=�50      $
��Left=�6-    J� Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53         Color$
 Pink��6'   55      �� 56      -   5         ��Name$ lbViewL��56      
���  ��$��50��6:   $��25��6E   $	��Top=�6Q   $
��Left=�6i   $
��Left��57      $	��3,3q�6(   $��20(�65   $��Arial)�6C   $
��Bold"�6V   5:      5<      5=      