   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Media;assembly=PresentationCoreSystem.Windows.Media  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5       notepad   notepad.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   selfclr-namespace      5   	   Lmed<clr-namespace:System.Windows.Media;assembly=PresentationCore      5	   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit      5
   	   6sys&clr-namespace:System;assembly=mscorlib      5   	   SComponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase      5      -   5          �Name$  
ThisWindow��5   	    � Title$ 
My Notepad��5      $	��400��6   $	��500��6!    � Icon$ Images/icon1.png��6K    � 
ResizeMode$ CanResizeWithGrip=�6c   $	��400��6�   $	��500��6�   $��Center=�6�   $��Center=�5   	   ���	#FF363635 � 	Resources 5         Exit �� Text��%0   &	        �� 5   
   $ Do Something��6'   5       J� CommandBindings 5      )   #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Open��5      6*     5   
   -   5        $	 New��5      6(     5   
   -   5        $
 Save��5      6)     5   
   -   5        # [  5      69    J� InputBindings 5      �� 5   
   
	 �� Key$	 O��6   
 �� 	Modifiers$
 Controlf�6    �� Command$
 Open��61   6B   �� 5    
   $	 N��6   $
 Controlf�6   $	 New��61   �� 5!   
   $	 S��6   $

 Ctrlf�6   $
 Save��6.   �� 5"   
   $	 X��6   $

 Ctrlf�6   # [  6.   .��5*      �  � RowDefinitions 5+   
   �� 5,      $��58 �6   �� 5-      $��25 �6   �� 5.      $��* �6   �� 5/      $��42 �6   .+�52   
   �� $��0��6   ���	#FF363635$��RightToLeft=�66   .+�53      �� $��58��6   
 �� Top$ 0��6    $��Images/play.png��6/   $��UniformToFill=�6I   55      56      �� 58   
   $��1��6   
�������.+�5:      o� -   5        $��mainMenu��5:   %   $��0,0,2,0q�6   $	��Top=�65   
���   �
�������$��20��6y   .@�5<      m� $
��auto��6   $��_File��6)   
���   �.@�5=      m� $
��_New��6   
���   � m� InputGestureText$ Ctrl+N��6@    m� Command$	 New��6Z   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6j   5>      m� 5?      $��_Open��6    
���   �$ Ctrl+O��6B   $
 Open��6\   $ Display=�6l   m� 5C      $��_Save��6   
���   �$ Display=�6A   $ Ctrl+S��6j   $
 Save��6�   m� 5D      -   5        $��_Save As��5D      
���   �$ Display=�6]   �� 5E      m� 5F      -   5        $��_Delete��5F      
���   �$ Display=�6\   m� 5G      $��_Exit��6   
���   �$ Ctrl+X��6A   # [  6\   $ Display=�6|   �� 5H      5J      m� 5M      -	   5        $��_Format��5M      
���   �.@�5O      ��  �� Orientation$ 
Horizontal=�6!   $��Right=�6:   .+�5P      �� $��Font Family  ��6    �� 5R   !   -
   5        $��cmbFontFamily��5R   *    �� SelectedValue$ Times New Roman ��6?   $	��100��6`   $��23��6l   $	��Top=�6x       System.Windows.Media.Fonts   SystemFontFamilies#��Z 5S      5T      5V      �� 5W      $ 
Horizontal=�6!   .+�5X      �� $��Font Size      ��6    �� 5[      -   5        $	��bt1��5[   -   $��30��6"   $��-��68   6X   �� 5\      -   5        $��fsize��5\   "   $��40��6/   $��12��6:   $	��6,3q�6D    �� 
IsReadOnly . 6R   �� 5]      -   5        $	��bt2��5]   ,   $��30��6!   $��+��67   6W   5^      � 5a       � Orientation$ 
Horizontal=�6    .+�5b      �� $��Color ��6    $
��Left=�61   �� 5c      -   5         ��Name$ lstcolor��5c   ?   $��Right=�6#   $	��100��6R    �� Text$ Black��6^   $
��15,5q�6k   $��35,0,0,0q�6z   .@�5d      �� $��Black��6+    �� 
IsSelected . 
���   �6M   �� 5e      $
��Blue��6+   
����  �6:   �� 5f      $	��Red��6+   
���  ��69   �� 5g      $��Yellow��6+   
��� ���6<   �� 5h      $��Green��6+   
��� � �6;   5j      5l      m� 5m      -   5        $��_Reset Font Setting��5m       
���   �$��Center=�6i   $ Display=�6�   6�   5n      m� 5o      -   5        $��About��5o   *   $��About��6   
���   �$��Center=�6^   5q      5s      5v      �� 5w   
   -   5        $��textArea��5w   a   |�.  �� 	IsEnabled .  �� AcceptsReturn . 
�������$
��Auto=�6�   $
��Auto=�6�   
�������
���   ���. $��2��6M   � ContextMenu 5x      �� 5y      .@�5z      m� $	 Cut��6    m� Icon 5{      �� 5|      $��Images/cut.png��6$   5~      m� 5      $
 Copy��6    5�      �� 5�      $��Images/copy.png��6$   5�      m� 5�      $ Paste��6    5�      �� 5�      $��Images/paste.png��6$   5�      5�      5�      �� 5�   
   $��3��6   ���	#FF76B900$��RightToLeft=�65   .+�5�      �� $��42��6   $
��Fill=�6    $��Images/image.jpg��6/   5�      5�      �� 5�   
   $&�� My Notepad WPF(c)CopyRight 2015 ��6   $��3��6;   
���   �$��Center=�6[   $��Center=�6v   $
��Bold"�6�   $��12(�6�   $��LeftToRight=�6�   �� 5�   
   -   5        $��status��5�      $�� ��6   $��Center=�6)   $��1��6D   $��Gothic)�6Q   
�������$��Right=�6x   5�      5�      