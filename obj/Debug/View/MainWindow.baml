   M S B A M L   `   `   `  ����F  BListExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ListExampleListExample  5   	   9!clr-namespace:ListExample.UtilityListExample.Utility  5   	       ListExample.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ListExample     5   	   :localUtility!clr-namespace:ListExample.Utility     5   	     � Title$  Offite Test��5	   	   $	��800��6   $	��400��6*   ��5
      �� 5   
    �� Color# � ��6    � 	Resources 5      +  %ListExample.Utility.DateTimeConverter   DateTimeConverter4  .ListExample.Utility.PriorityIndicatorConverter  PriorityIndicatorConverter/  )ListExample.Utility.StatusToIconConverter  StatusToIconConverter/  )ListExample.Utility.StatusColourConverter  StatusColourConverter��%t   &	        &	      &	 &     &	 9       5   
   6)     5   
   62     5   
   6-     5   
   6-   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.New��5      6^     5   
   -   5        $ ApplicationCommands.Find��5      6\   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �  � ColumnDefinitions 5      �� 5       $��30 �6#   �� 5!      $��* �6#   �� 5"      $��70 �6#   �� 5#      $��30 �6#   .+�5&      �� -   5        $��searchButton��5&      $��0��6)   $��0q�69     FontAwesomeRegular#��[ 6M   $��ApplicationCommands.Find��6~   ��5'      �� 5(      # � ��6&   .��5*      �� $	����6   6.   5+      �� 5-      -   5        $��
searchText��5-      $��1��6(   $��0, 5, 15, 5q�68   .��6M   5.      �� 50      -   5        $��selectViewModel��50      $��2��60   $��0, 5, 15, 5q�6@   .+�51      	� -   5        $��	IssuesChk��51   4    	� 	GroupName$ 	radioList��6   $��Issues��6E   6V   	� 52      -   5        $��RisksChk��52   4   $ 	radioList��6   $��Risks��6D   6T   53      �� 55      -   5        $��refreshButton��55      $��3��6*   $��0q�6:   #��[ 6N   $��ApplicationCommands.New��6   ��56      �� 57      # � ��6&   .��59      �� $	����6   6.   5:      5;      �� 5=   
   -	   5         ��Name$ ticketsList��5=      	 �� SelectionMode$	 Single=�6)   $��Disabled=�6@   $��Stretch=�5>   	   $��1��6.   ��5?      �� 5@      .R�5A      �� .��5B      �� ���	#FFCDCFD6$��
0, 0, 0, 1q�69   ._�5C      � $��Stretch=�6#   $	��100��6A   $��Stretch=�6O   $
��Auto��6k   $��0,0,0,5q�6x    5D   "   �� 5E   &   $��10 �67   �� 5F   &   $	��100 �67   �� 5G   &   $��* �67   .+�5J   "   �� ���	#FFCDCFD6$��1q�6A   $��5,5,0,5q�6U   ���#4e7496._�5L   &   �� 
 ��Name$
 priorityLabel��6,   $�� ��6C   $��Stretch=�6O   $��Stretch=�6t   ��5M   *   `� 5N   .    `� 	Converter# [ 6;   .1�5O   2   ��  �� Path$ priority�6:   6L   �� 5P   2   $ overall_level_of_risk�6:   6Y   5Q   /   5S   '   5T   #   �� 5U   "   $��1��6)   ���	#FFCDCFD6$��1q�6Q   $��5,5,5,5q�6f   ._�5W   &   ��  ��Name$ image��6<   $��0��6,   $��
0, 0, 0, 0q�6K   $
��Auto��6_   $
��Fill=�6l   ��5X   *   �� 5Y   .   $ thumbnailImage�66    �� TargetNullValue 5Z   2   ��5[   6   /Resources/noImage.jpg��6Z   5]   /   5_   '   5`   #   � 5a   "   $��2��6'    5b   &   �� 5c   *   $
��auto �6;   �� 5d   *   $��* �6;    5f   &   �� 5g   *   $��25 �68   �� 5h   *   $
��auto �68   �� 5i   *   $��1* �68   .+�5l   &   �� $
 	ticketNum��6,   $��Center=�6Z   $	��Top=�6~   ��6?   �� *number+6~   �� 5m   &   $
 ticketTitle��6,   $��1��6A   $	��Top=�6Q   .��5n   *   �� $��CharacterEllipsis=�6J   ��64   �� *name+6J   5o   '   � 5p   &   $��1��6,   $��1��69    5q   *   �� 5r   .   $
��Auto �6?   �� 5s   .   $��* �6?   .+�5u   *   ��  �� Orientation$ 
Horizontal=�65   $
��Left=�6N   .+�5w   .   �� $��2,1,2,5q�64     FontAwesome#��[ 6E   $
��Left=�6o   $��Center=�6�   ��5x   2   `� 5z   6   # [ 6C   .1�5{   :   �� $ status�6B   6R   �� 5|   :   $ mitigation_status�6B   6]   5}   7   ��5   2   `� 5�   6   # [ 6C   .1�5�   :   �� $ status�6B   6R   �� 5�   :   $ priority�6B   6T   �� 5�   :   $ mitigation_status�6B   6]   �� 5�   :   $ overall_level_of_risk�6B   6a   5�   7   5�   /   �� 5�   .   $
 owner��64   $
��Left=�6^   $��Center=�6y   $��Center=�6�   $��10(�6�   $��0,1,5,5q�6�   ��6C   �� *owner+6�   5�   +   �� 5�   *   $

 date��60   $��0q�6>   $��1��6I   $��10(�6Z   $��Center=�6h   $��Right=�6�   $��5,0,10,5q�6�   ��5�   .   `� 5�   2   # [  6?   .1�5�   6   �� $ created�6>   6O   5�   3   5�   +   5�   '   �� 5�   &   $

 desc��6,   $��0q�6:   ���	#FFB9B3B3$	��Top=�6]   $��1��6|   $��10(�6�   $��2��6�   ��5�   *   �� 5�   .    �� TextWrapping$
 Wrap=�69   ��6M   �� *desc+5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      