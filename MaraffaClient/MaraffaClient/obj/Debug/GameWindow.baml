   M S B A M L   `   `   `  ����H  DMaraffaClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MaraffaClientMaraffaClient  5   	       MaraffaClient.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MaraffaClient     5   	   -   5          � Title$  Maraffa��5   	   $��708.5��6   $	��900��6(    � 
ResizeMode$ CanMinimize=�64   ���	#FF52E065 � WindowStartupLocation$ CenterScreen=�6d    � 	Resources 5	         CircleButton �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value
 �� 
TargetType �� Stretch  SemaforoVerde��%-  &	        &	 �    �� 5
   
   " ��6%    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
	 ���� 63   5      P� 5       � �� . . �5      ��  � ��
	 ���� 63   5      .�5      ��  � ��	 5      �� 5      "
 ��6&   .R�5      � .+�5      A� #��z��6&   $
��Auto��6J   $
 Fill=�6X   ���	#FFCDCDCD$
��Auto��6z   �� 5      $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � ��
	 � ���6+   5      ��5   
   	#FF00FF0C��61   5       .��5!      � $	��620��6   $	��740��6    � RowDefinitions 5"   
   �� 5#       � ColumnDefinitions 5%   
   �� 5&      .+�5(   
   �� -   5         ��Name$ 	btn_Card8��5(      $�� ��6$   $
��Left=�6/   $��339,503,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�    K� ZIndex$ 1��6�   ��6�   Z� 6�   �� 5)   
   -   5        $ 	btn_Card9��5)      $�� ��6$   $
��Left=�6/   $��404,503,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� 6�   �� 5*   
   -   5        $ 	btn_Card7��5*      $�� ��6$   $
��Left=�6/   $��274,503,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 10��6�   ��6�   Z� �� 5+   
   -   5        $ 
btn_Card10��5+      $�� ��6%   $
��Left=�60   $��469,503,0,0q�6K   $	��Top=�6`   $��60��6x   $	��107��6�   ���	#FF707070$ 1��6�    J� RenderTransformOrigin$ 	0.5,0.757&�6�   ��6�   Z� �� 5,   
   -   5        $ 	btn_Card6��5,      $�� ��6$   $
��Left=�6/   $��209,503,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� 6�   �� 5-   
   -   5        $ 	btn_Card2��5-      $�� ��6$   $
��Left=�6/   $��274,391,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� �� 5.   
   -   5        $ 	btn_Card5��5.      $�� ��6$   $
��Left=�6/   $��469,391,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� 6�   �� 5/   
   -	   5        $ 	btn_Card3��5/      $�� ��6$   $
��Left=�6/   $��339,391,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� 6�   �� 50   
   -
   5        $ 	btn_Card4��50      $�� ��6$   $
��Left=�6/   $��404,391,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� 6�   �� 51   
   -   5        $ 	btn_Card1��51      $�� ��6$   $
��Left=�6/   $��209,391,0,0q�6J   $	��Top=�6_   $��60��6w   $	��107��6�   $ 1��6�   ��6�   Z� 6�   �� 52   
   -   5        $ btn_Chat��52      $�� ��6#   $
��Left=�6.   $��534,550,0,0q�6I   $	��Top=�6^   $��60��6v   $��60��6�   #���   6�   {�.  ��53      �� 54       �� ImageSource$ ChatBackground.png��6    j� Stretch$ Uniform=�6>   56      �� 57   
   -   5        $ btn_Striscio��57      ���	#FF52E065$��Striscio��6>   $��599,585,81,10q�6Q   6h   �� 58   
   -   5        $ 	btn_Busso��58      ���	#FF52E065$��Busso��6;   $��599,554,81,40q�6K   6b   �� 59   
   -   5        $ btn_Volo��59      ���	#FF52E065$
��Volo��6:   $��599,523,81,71q�6I   6`   �� 5:   
   -   5         ��Name$ 	img_Card1��5:      $
��Left=�6#   $	��107��6>   $��339,270,0,0q�6K   $	��Top=�6`   $��60��6x   $��	Dorso.png��6�   $
��Fill=�6�   �� 5;   
   -   5        $ 	img_Card3��5;      $
��Left=�6#   $	��107��6>   $��
339,93,0,0q�6K   $	��Top=�6_   $��60��6w   $��	Dorso.png��6�   $
��Fill=�6�   �� 5<   
   -   5        $ 	img_Card2��5<      $
��Left=�6#   $	��107��6>   $��404,180,0,0q�6K   $	��Top=�6`   $��60��6x   $
��Fill=�6�   $��	Dorso.png��6�   �� 5=   
   -   5        $ 	img_Card4��5=      $
��Left=�6#   $	��107��6>   $��274,180,0,0q�6K   $	��Top=�6`   $��60��6x   $��	Dorso.png��6�   $
��Fill=�6�   �� 5>   
   -   5        $ img_Card4_Copy1��5>      $
��Left=�6)   $	��108��6D   $��-104,180,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C       �� Angle$	 162Q�6&   T� 5D      5E      5G      �� 5H   
   -   5        $ img_Card4_Copy2��5H      $
��Left=�6)   $	��108��6D   $��-106,180,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5I      V� 5J      .~�5K      �� �� 5L      �� 5M      $	 146Q�6&   T� 5N      5O      5Q      �� 5R   
   -   5        $ img_Card4_Copy3��5R      $
��Left=�6)   $	��108��6D   $��-106,180,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5S      V� 5T      .~�5U      �� �� 5V      �� 5W      $	 130Q�6&   T� 5X      5Y      5[      �� 5\   
   -   5        $ img_Card4_Copy��5\      $
��Left=�6(   $	��106��6C   $��-104,182,0,0q�6P   $	��Top=�6f   $��60��6~   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5]      V� 5^      .~�5_      �� �� 5`      �� 5a      $	 114Q�6&   T� 5b      5c      5e      �� 5f   
   -   5        $ img_Card4_Copy4��5f      $
��Left=�6)   $	��106��6D   $��-104,182,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5g      V� 5h      .~�5i      �� �� 5j      �� 5k      $ 98Q�6&   T� 5l      5m      5o      �� 5p   
   -   5        $ img_Card4_Copy5��5p      $
��Left=�6)   $	��108��6D   $��-106,180,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5q      V� 5r      .~�5s      �� �� 5t      �� 5u      $ 82Q�6&   T� 5v      5w      5y      �� 5z   
   -   5        $ img_Card4_Copy6��5z      $
��Left=�6)   $	��106��6D   $��-103,182,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5{      V� 5|      .~�5}      �� �� 5~      �� 5      $ 66Q�6&   T� 5�      5�      5�      �� 5�   
   -   5        $ img_Card4_Copy7��5�      $
��Left=�6)   $	��106��6D   $��-105,182,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 50Q�6&   T� 5�      5�      5�      �� 5�   
   -   5        $ img_Card4_Copy8��5�      $
��Left=�6)   $	��106��6D   $��-104,182,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 34Q�6&   T� 5�      5�      5�      �� 5�   
   -   5        $ img_Card4_Copy9��5�      $
��Left=�6)   $	��106��6D   $��-104,182,0,0q�6Q   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 18Q�6&   T� 5�      5�      5�      �� 5�   
   -   5        $ img_Card4_Copy20��5�      $
��Left=�6*   $	��108��6E   $��303,-100,0,0q�6R   $	��Top=�6h   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 252.588Q�6&   T� 5�       T� X$ 42.121Q�6)    T� Y$ -39.791Q�64   5�      5�      �� 5�   
   -   5        $ img_Card4_Copy21��5�      $
��Left=�6*   $	��108��6E   $��301,-100,0,0q�6R   $	��Top=�6h   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 236.588Q�6&   T� 5�      $ 44.142Q�6)   $ -41.791Q�64   5�      5�      �� 5�   
   -    5        $ img_Card4_Copy22��5�      $
��Left=�6*   $	��108��6E   $��301,-100,0,612q�6R   $��Center=�6j   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 220.588Q�6&   T� 5�      $ 44.141Q�6)   $ -41.79Q�64   5�      5�      �� 5�   
   -!   5        $ img_Card4_Copy23��5�      $
��Left=�6*   $	��106��6E   $��303,-98,0,0q�6R   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 204.588Q�6&   T� 5�      $ 42.121Q�6)   $ -39.791Q�64   5�      5�      �� 5�   
   -"   5        $ img_Card4_Copy24��5�      $
��Left=�6*   $	��106��6E   $��303,-98,0,0q�6R   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 188.588Q�6&   T� 5�      $ 42.122Q�6)   $ -39.791Q�64   5�      5�      �� 5�   
   -#   5        $ img_Card4_Copy25��5�      $
��Left=�6*   $	��108��6E   $��301,-100,0,0q�6R   $	��Top=�6h   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 172.588Q�6&   T� 5�      $ 44.142Q�6)   $ -41.791Q�64   5�      5�      �� 5�   
   -$   5        $ img_Card4_Copy26��5�      $
��Left=�6*   $	��106��6E   $��304,-98,0,0q�6R   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 156.588Q�6&   T� 5�      $ 41.111Q�6)   $ -38.791Q�64   5�      5�      �� 5�   
   -%   5        $ img_Card4_Copy27��5�      $
��Left=�6*   $	��106��6E   $��302,-98,0,0q�6R   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 140.588Q�6&   T� 5�      $ 43.131Q�6)   $ -40.791Q�64   5�      5�      �� 5�   
   -&   5        $ img_Card4_Copy28��5�      $
��Left=�6*   $	��106��6E   $��303,-98,0,0q�6R   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 124.588Q�6&   T� 5�      $ 42.121Q�6)   $ -39.791Q�64   5�      5�      �� 5�   
   -'   5        $ img_Card4_Copy29��5�      $
��Left=�6*   $	��106��6E   $��303,-98,0,0q�6R   $	��Top=�6g   $��60��6   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.018,1.138&�6�   z�5�      V� 5�      .~�5�      �� �� 5      �� 5     $ 108.588Q�6&   T� 5     $ 66.397Q�6)   $ -86.49Q�64   5     5     �� 5  
   -(   5        $ img_Card4_Copy10��5     $
��Left=�6*   $	��108��6E   $��707,184,-27,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5     V� 5     .~�5	     �� �� 5
     �� 5     $ 341.589Q�6&   T� 5     $ 81.513Q�6)   $
 1.61Q�64   5     5     �� 5  
   -)   5        $ img_Card4_Copy11��5     $
��Left=�6*   $	��108��6E   $��705,184,-25,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5     V� 5     .~�5     �� �� 5     �� 5     $ 325.589Q�6&   T� 5     $ 85.512Q�6)   $ 1.596Q�64   5     5     �� 5  
   -*   5        $ img_Card4_Copy12��5     $
��Left=�6*   $	��108��6E   $��705,184,-25,328q�6R   $��Center=�6k   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5     V� 5     .~�5     �� �� 5     �� 5     $ 309.589Q�6&   T� 5      $ 85.512Q�6)   $ 1.595Q�64   5!     5#     �� 5$  
   -+   5        $ img_Card4_Copy13��5$     $
��Left=�6*   $	��106��6E   $��707,186,-27,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5%     V� 5&     .~�5'     �� �� 5(     �� 5)     $ 293.589Q�6&   T� 5*     $ 81.513Q�6)   $
 1.61Q�64   5+     5-     �� 5.  
   -,   5        $ img_Card4_Copy14��5.     $
��Left=�6*   $	��106��6E   $��707,186,-27,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5/     V� 50     .~�51     �� �� 52     �� 53     $ 277.589Q�6&   T� 54     $ 81.512Q�6)   $
 1.61Q�64   55     57     �� 58  
   --   5        $ img_Card4_Copy15��58     $
��Left=�6*   $	��108��6E   $��705,184,-25,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�59     V� 5:     .~�5;     �� �� 5<     �� 5=     $ 261.589Q�6&   T� 5>     $ 85.513Q�6)   $ 1.596Q�64   5?     5A     �� 5B  
   -.   5        $ img_Card4_Copy16��5B     $
��Left=�6*   $	��106��6E   $��708,186,-28,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5C     V� 5D     .~�5E     �� �� 5F     �� 5G     $ 245.589Q�6&   T� 5H     $ 79.511Q�6)   $ 1.618Q�64   5I     5K     �� 5L  
   -/   5        $ img_Card4_Copy17��5L     $
��Left=�6*   $	��106��6E   $��706,186,-26,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5M     V� 5N     .~�5O     �� �� 5P     �� 5Q     $ 229.589Q�6&   T� 5R     $ 83.511Q�6)   $ 1.603Q�64   5S     5U     �� 5V  
   -0   5        $ img_Card4_Copy18��5V     $
��Left=�6*   $	��106��6E   $��707,186,-27,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5W     V� 5X     .~�5Y     �� �� 5Z     �� 5[     $ 213.589Q�6&   T� 5\     $ 81.512Q�6)   $ 1.611Q�64   5]     5_     �� 5`  
   -1   5        $ img_Card4_Copy19��5`     $
��Left=�6*   $	��106��6E   $��707,186,-27,0q�6R   $	��Top=�6i   $��60��6�   $��	Dorso.png��6�   $
��Fill=�6�   $ 0.5,1&�6�   z�5a     V� 5b     .~�5c     �� �� 5d     �� 5e     $ 197.589Q�6&   T� 5f     $ 81.511Q�6)   $ 1.609Q�64   5g     5i     �� 5j  
   -2   5         ��Name$ lbl_Messaggio1��5j     $�� ��6(   $
��Left=�63   $��154,309,0,0q�6N   $	��Top=�6c   $	��100��6{   $	��120��6�   $��Center=�6�   $��Center=�6�   $��4,4,5,15q�6�   $��16(�6�   $
��Bold"�6�   ��5k     �� 5l     $ Messaggio.png��6   $ Uniform=�69   5n     �� 5o  
   -3   5        $ lbl_Messaggio2��5o     $�� ��6(   $
��Left=�63   $��675,113,-50,0q�6N   $	��Top=�6e   $	��120��6}   $	��100��6�   $��4,4,5,15q�6�   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   $��16(�6  ��5p     �� 5q     $ Messaggio.png��6   $ Uniform=�69   5s     �� 5t  
   -4   5        $ lbl_Messaggio4��5t     $�� ��6(   $��-50,113,0,0q�63   $	��Top=�6H   $��Center=�6`   $��Center=�6�   $��4,4,5,18q�6�   $��16(�6�   $
��Bold"�6�   $	��100��6�   $
��Left=�6�   $	��120��6  ��5u     �� 5v     $ Messaggio2.png��6   $ Uniform=�6:   5x     �� 5y  
   -5   5        $ lbl_Messaggio3��5y     $�� ��6(   $
��Left=�63   $��
422,33,0,0q�6N   $	��Top=�6b   $	��120��6z   $	��100��6�   $��Center=�6�   $��Center=�6�   $��	10,20,5,5q�6�   $
��Bold"�6�   $��16(�6�   $ 0.5,0.5&�6  z�5z     V� 5{     .~�5|     �� �� 5}     �� 5~     $ -13.199Q�6&   T� 5     5�     ��5�     �� 5�     $ Uniform=�6   $ Messaggio3.png��6/   5�     �� 5�  
   -6   5        $
 img1��5�     $
��Left=�6   $	��107��69   $��209,391,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   {�.  6�   �� 5�  
   -7   5        $
 img2��5�     $
��Left=�6   $	��107��69   $��274,391,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   -8   5        $
 img3��5�     $
��Left=�6   $	��107��69   $��339,391,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   -9   5        $
 img4��5�     $
��Left=�6   $	��107��69   $��404,391,0,0q�6F   $	��Top=�6[   $��60��6s   $
��Fill=�6~   $��	Dorso.png��6�   �� 5�  
   -:   5        $
 img5��5�     $
��Left=�6   $	��107��69   $��469,391,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   -;   5        $
 img6��5�     $
��Left=�6   $	��107��69   $��209,503,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   -<   5        $
 img7��5�     $
��Left=�6   $	��107��69   $��274,503,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   -=   5        $
 img8��5�     $
��Left=�6   $	��107��69   $��339,503,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   ->   5        $
 img9��5�     $
��Left=�6   $	��107��69   $��404,503,0,0q�6F   $	��Top=�6[   $��60��6s   $��	Dorso.png��6~   $
��Fill=�6�   �� 5�  
   -?   5        $ img10��5�     $
��Left=�6   $	��107��6:   $��469,503,0,0q�6G   $	��Top=�6\   $��60��6t   $��	Dorso.png��6   $
��Fill=�6�   �� 5�  
   -@   5        $ btn_Punteggio��5�     $��	Punteggio��6(   $
��Left=�6<   $��129,590,0,0q�6W   $	��Top=�6l   $��75��6�   ���	#FF52E0506�   �� 5�  
   -A   5        $ img_Briscola��5�     $
��Left=�6&   $��60��6A   $��339,205,0,0q�6M   $	��Top=�6b   $��60��6z   �� 5�  
   -B   5        $	 imk��5�     $
��Left=�6   $	��100��68   $��
599,25,0,0q�6E   $	��Top=�6Y   $	��100��6q   �� 5�  
   -C   5        $ btn_None��5�     $�� ��6#   $
��Left=�6.   $��599,492,0,0q�6I   $	��Top=�6^   $��60��6v   ���	#FF52E065$ 1.294,0.967&�6�   $��26��6�   6�   �� 5�  
   -D   5        $ label��5�     $�� ��6   $
��Left=�6*   $��144,451,0,0q�6E   $	��Top=�6Z   $��60��6r   $	��104��6}   ���	#FF5959596�   �� 5�  
   -E   5        $ 	btn_Rosso��5�     $�� ��6$   $
��Left=�6/   $��154,459,0,0q�6J   $	��Top=�6_   $��40��6w   $��40��6�   #���   6�   
���  ��
���   �{�.  ��6�   Z� 6�   �� 5�  
   -F   5        $ 	btn_Verde��5�     $�� ��6$   $
��Left=�6/   $��154,508,0,0q�6J   $	��Top=�6_   $��40��6w   $��40��6�   #���   6�   {�.  ��6�   Z� 6�   5�     5�     